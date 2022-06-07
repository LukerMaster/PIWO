using Microsoft.Win32;
using PIWO_App.Core;
using PIWO_Core;
using PIWO_Core.Interfaces;
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

namespace PIWO_App.MVVM.View
{
    /// <summary>
    /// Interaction logic for ExportView.xaml
    /// </summary>
    public partial class ExportView : UserControl
    {
        public ExportView()
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


        private void saveFileBtnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            IAlcoholContext alcoholContext = AlcoholContext.GetAlcohol();
            IFileManager fileManager = Api.CreateFileManager(checkFileType());
            saveFileDialog.Filter = setFilter();
            if (saveFileDialog.ShowDialog() == true)
            {
                if (cities.IsChecked == true)
                    fileManager.SaveToFile(saveFileDialog.FileName, alcoholContext.Cities);
                else if (shops.IsChecked == true)
                    fileManager.SaveToFile(saveFileDialog.FileName, alcoholContext.Shops);
                else if (purchases.IsChecked == true)
                    fileManager.SaveToFile(saveFileDialog.FileName, alcoholContext.Purchases);
                else if (alcohols.IsChecked == true)
                    fileManager.SaveToFile(saveFileDialog.FileName, alcoholContext.Alcohols);
                alcoholContext.SaveChanges();
            }
        }
    }
}
