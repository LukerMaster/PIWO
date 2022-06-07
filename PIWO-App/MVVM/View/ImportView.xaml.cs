using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using PIWO_Core;
using PIWO_Core.Interfaces;
using PIWO_Core.FileParsing;
using PIWO_Core.FileParsing.Strategies;
using PIWO_App.Core;
using Microsoft.EntityFrameworkCore;

namespace PIWO_App.MVVM.View
{
    /// <summary>
    /// Interaction logic for ImportView.xaml
    /// </summary>
    public partial class ImportView : UserControl
    {
        public ImportView()
        {
            InitializeComponent();
        }
        private FileType checkFileType()
        {
            if (YAMLRadio.IsChecked == true)
                return FileType.Yaml;
            return FileType.Xml;
        }

        private string setFilter()
        {
            if (YAMLRadio.IsChecked == true)
                return "YAML|*.yaml"; 
            return "XML|*.xml";
        }

     

        private void openFileBtnClick(object sender, RoutedEventArgs e)
        {
            IAlcoholContext alcoholContext = AlcoholContext.GetAlcohol();
            IFileManager fileManager = Api.CreateFileManager(checkFileType());
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = setFilter();

            if (openFileDialog.ShowDialog() == true)
            {
                if (cities.IsChecked == true)
                    fileManager.AddFromFile(openFileDialog.FileName, alcoholContext.Cities);
                else if (shops.IsChecked == true)
                    fileManager.AddFromFile(openFileDialog.FileName, alcoholContext.Shops);
                else if(purchases.IsChecked == true)
                     fileManager.AddFromFile(openFileDialog.FileName, alcoholContext.Purchases);
                else if (alcohols.IsChecked == true)
                    fileManager.AddFromFile(openFileDialog.FileName, alcoholContext.Alcohols);
                alcoholContext.SaveChanges();
            }


        }
    }
}
