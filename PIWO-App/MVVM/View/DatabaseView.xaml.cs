using Microsoft.EntityFrameworkCore;
using PIWO_App.Core;
using PIWO_Core;
using PIWO_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PIWO_Core.Database.Entities;
using System.Windows.Threading;

namespace PIWO_App.MVVM.View
{
    /// <summary>
    /// Interaction logic for DatabaseView.xaml
    /// </summary>
    public partial class DatabaseView : UserControl
    {
        public List<Alcohol> Alcohols { get; set; }
        public List<City> Cities{ get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Shop> Shops { get; set; }
        public DatabaseView()
        {
            InitializeComponent();
            if (AlcoholContext.IsReady)
            {
                IAlcoholContext alcohol = AlcoholContext.GetAlcohol();

                Alcohols = alcohol.Alcohols.ToList<Alcohol>();
                Cities = alcohol.Cities.ToList<City>();
                Shops = alcohol.Shops.ToList<Shop>();
                Purchases = alcohol.Purchases.ToList<Purchase>();
                dataBaseView.ItemsSource = Alcohols;
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    MessageBox.Show("Nie podłączono bazy danych (A Bartka potrącił samochód).");
                }));
            }
                
        }


        private void RadioButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            IAlcoholContext alcohol = AlcoholContext.GetAlcohol();
            dataBaseView.ItemsSource = alcohol.Alcohols.Local.ToObservableCollection();
         /*   var info = alcohol.Alcohols.ToList();
            foreach (var a in info)
            {
                Trace.WriteLine(a.Id);
                Trace.WriteLine(a.Name);
                Trace.WriteLine(a.Voltage);
            }*/

        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            IAlcoholContext alcohol = AlcoholContext.GetAlcohol();
            switch (radioButton.Content.ToString())
            {
                case "Alcohols":
                    dataBaseView.ItemsSource = Alcohols;
                    break;
                case "Purchases":
                    dataBaseView.ItemsSource = Purchases;
                    break;
                case "Shops":
                    dataBaseView.ItemsSource = Shops;
                    break;
                case "Cities":
                    dataBaseView.ItemsSource = Cities;
                    break;
            }
        }
    }
}
