﻿using Palashicheva_402_ProkatCars.ApplicationData;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = ProkatEntities.GetContext().User.FirstOrDefault(x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Введите верные данные чтобы войти!", "Ошибка авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Успешный вход как администратор",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.DostupRole = 1;
                            AppFrame.MainFrame.Navigate(new MainPage());
                            break;
                        case 2:
                            MessageBox.Show("Успешный вход как пользователь",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.DostupRole = 2;
                            AppFrame.MainFrame.Navigate(new MainPage());
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Успешный вход как гость",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            AppFrame.DostupRole = 0;
            AppFrame.MainFrame.Navigate(new MainPage());
        }
    }
}
