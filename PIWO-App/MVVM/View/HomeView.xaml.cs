using System;
using System.Collections.Generic;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void kolor_1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border temp = sender as Border;
            Random r = new Random();

            Color c = new Color();
            c.R = (byte)r.Next(255);
            c.G = (byte)r.Next(255);
            c.B = (byte)r.Next(255);
            c.A = 255;
            temp.Background = new SolidColorBrush(c);
        }
    }
}
