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
using PIWO_Core;
using PIWO_App.Core;
using PIWO_Core.Interfaces;

namespace PIWO_App.MVVM.View
{
    /// <summary>
    /// Interaction logic for ConnectionView.xaml
    /// </summary>
    public partial class ConnectionView : UserControl
    {
        private string _login;
        private string _password;
        private string _name;
        private string _server;
        private string _port;
        public ConnectionView()
        {
            InitializeComponent();
        }

        private void connectBtnClick(object sender, RoutedEventArgs e)
        {
            _login = login.Text;
            _password = password.Text;
            _name = name.Text;
            _server = server.Text;
            _port = port.Text;
            AlcoholContext.CreateContext(_login, _password, _server, _name, _port);

        }
    }
}
