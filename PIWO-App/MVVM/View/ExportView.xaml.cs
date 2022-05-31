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
        private string checkFileType()
        {
            if (XMLRadio.IsChecked == true)
                return "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            else if (YAMLRadio.IsChecked == true)
                return "YAML files (*.yaml)|*.yaml|All files (*.*)|*.*";
            return "All files(*.*) | *.* ";
        }

        private void saveFileBtnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = checkFileType();
            if (saveFileDialog.ShowDialog() == true)
            {

                string filename = saveFileDialog.FileName;
                File.WriteAllText(filename, txtEditor.Text);
            }
        }
    }
}
