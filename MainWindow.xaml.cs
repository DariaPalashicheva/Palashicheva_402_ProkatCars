using Palashicheva_402_ProkatCars.ApplicationData;
using Palashicheva_402_ProkatCars.Pages;
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

namespace Palashicheva_402_ProkatCars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
            AppFrame.MainFrame = MainFrame;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                BtnCar.Visibility = Visibility.Visible;
                BtnClient.Visibility = Visibility.Visible;
                BtnRent.Visibility = Visibility.Visible;
                BtnBrand.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
                BtnCar.Visibility = Visibility.Hidden;
                BtnClient.Visibility = Visibility.Hidden;
                BtnRent.Visibility = Visibility.Hidden;
                BtnBrand.Visibility = Visibility.Hidden;
            }
        }

        private void BtnCar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CarPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientPage());
        }
    }
}
