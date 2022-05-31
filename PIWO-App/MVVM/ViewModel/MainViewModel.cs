using PIWO_App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIWO_Core;
using PIWO_Core.Interfaces;

namespace PIWO_App.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public HomeViewModel HomeVm { get; set; }
        public ImportViewModel ImportVm { get; set; }
        public ExportViewModel ExportVm { get; set; }
        public DatabaseViewModel DatabaseVm { get; set; }
        public ConnectionViewModel ConnectionVm { get; set; }
        public IDbManager dbManager;

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ImportViewCommand { get; set; }
        public RelayCommand ExportViewCommand { get; set; }
        public RelayCommand DatabaseViewCommand { get; set; }

        public RelayCommand ConnectionViewCommand { get; set; }

        public RelayCommand Command { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            ImportVm = new ImportViewModel();
            ExportVm = new ExportViewModel();
            DatabaseVm = new DatabaseViewModel();
            ConnectionVm = new ConnectionViewModel();   
            dbManager = Api.CreateDbManager();
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            ImportViewCommand = new RelayCommand(o =>
            {
                CurrentView = ImportVm;
            });

            ExportViewCommand = new RelayCommand(o =>
            {
                CurrentView = ExportVm;
            });

            DatabaseViewCommand = new RelayCommand(o =>
            {
                CurrentView = DatabaseVm;
            });

            Command = new RelayCommand(o =>
            {

            });

            ConnectionViewCommand = new RelayCommand(o =>
            {
                CurrentView = ConnectionVm;
            });
        }
    }
}
