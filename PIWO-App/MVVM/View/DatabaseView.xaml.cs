using Microsoft.EntityFrameworkCore;
using PIWO_App.Core;
using PIWO_Core;
using PIWO_Core.Interfaces;
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
    /// Interaction logic for DatabaseView.xaml
    /// </summary>
    public partial class DatabaseView : UserControl
    {
        public DatabaseView()
        {
            InitializeComponent();
        }


        private void RadioButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IAlcoholContext alcohol = AlcoholContext.GetAlcohol();
            dataBaseView.ItemsSource = alcohol.Alcohols.Local.ToObservableCollection();

        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            IAlcoholContext alcohol = AlcoholContext.GetAlcohol();
            switch (radioButton.Content.ToString())
            {
                case "Alcohols":
                    dataBaseView.ItemsSource = alcohol.Alcohols.Local.ToObservableCollection();
                    break;
                case "Purchases":
                    dataBaseView.ItemsSource = alcohol.Purchases.Local.ToObservableCollection();
                    break;
                case "Shops":
                    dataBaseView.ItemsSource = alcohol.Shops.Local.ToObservableCollection();
                    break;
                case "Cities":
                    dataBaseView.ItemsSource = alcohol.Cities.Local.ToObservableCollection();
                    break;
            }
        }
    }
}
