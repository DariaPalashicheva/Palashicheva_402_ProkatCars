using Palashicheva_402_ProkatCars.ApplicationData;
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

namespace Palashicheva_402_ProkatCars.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPageRole1.xaml
    /// </summary>
    public partial class MainPageRole1 : Page
    {
        public MainPageRole1()
        {
            InitializeComponent();
        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new UserPage());
        }
    }
}
