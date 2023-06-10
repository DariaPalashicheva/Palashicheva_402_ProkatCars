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
            }

            else
            {
                BtnBack.Visibility = Visibility.Hidden;
                BtnCar.Visibility = Visibility.Collapsed;
                BtnClient.Visibility = Visibility.Collapsed;
                BtnRent.Visibility = Visibility.Collapsed;
                BtnBrand.Visibility = Visibility.Collapsed;
                BtnUser.Visibility = Visibility.Collapsed;
                BtnFeedback.Visibility = Visibility.Collapsed;
                BtnFeedbackAdd.Visibility = Visibility.Collapsed;
                return;
            }

            if (AppFrame.DostupRole == 0)
            {
                BtnCar.Visibility = Visibility.Visible;
                BtnFeedbackAdd.Visibility = Visibility.Visible;
            }
            if (AppFrame.DostupRole == 1)
            {
                BtnCar.Visibility = Visibility.Visible;
                BtnClient.Visibility = Visibility.Visible;
                BtnRent.Visibility = Visibility.Visible;
                BtnBrand.Visibility = Visibility.Visible;
                BtnUser.Visibility = Visibility.Visible;
                BtnFeedback.Visibility = Visibility.Visible;
            }
            if (AppFrame.DostupRole == 2)
            {
                BtnCar.Visibility = Visibility.Visible;
                BtnClient.Visibility = Visibility.Visible;
                BtnRent.Visibility = Visibility.Visible;
                BtnBrand.Visibility = Visibility.Visible;
                BtnFeedback.Visibility = Visibility.Visible;
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

        private void BtnRent_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RentPage());
        }

        private void BtnBrand_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BrandPage());
        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new UserPage());
        }

        private void BtnFeedback_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new FeedbackPage());
        }

        private void BtnFeedbackAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new FeedbackAddEdit(null));
        }
    }
}
