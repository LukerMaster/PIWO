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
        private string checkFileType()
        {
            if (XMLRadio.IsChecked == true)
                return "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            else if (YAMLRadio.IsChecked == true)
                return "YAML files (*.yaml)|*.yaml|All files (*.*)|*.*";
            return "All files(*.*) | *.* ";
        }

        private void openFileBtnClick(object sender, RoutedEventArgs e)
        {
            IAlcoholContext alcoholContext = AlcoholContext.GetAlcohol();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = checkFileType();
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }
    }
}
