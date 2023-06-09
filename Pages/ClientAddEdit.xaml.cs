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
    /// Логика взаимодействия для ClientAddEdit.xaml
    /// </summary>
    public partial class ClientAddEdit : Page
    {
        private Client _current = new Client();

        public ClientAddEdit(Client selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;

            DataContext = _current;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_current.Familiya) || tbFamiliya.Text.Any(Char.IsDigit))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_current.Name) || tbName.Text.Any(Char.IsDigit))
                errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(_current.Otchestvo) || tbOtchestvo.Text.Any(Char.IsDigit))
                errors.AppendLine("Введите отчество");
            if (_current.DateBirth.Year < 1930)
                errors.AppendLine("Укажите дату рождения");
            if (string.IsNullOrWhiteSpace(_current.Passport) || !tbPassport.IsMaskFull)
                errors.AppendLine("Проверьте! Паспорт должен состоять из серии(4 цифры) и номера(6 цифр)");
            if (string.IsNullOrWhiteSpace(_current.Address))
                errors.AppendLine("Введите адрес");
            if (string.IsNullOrWhiteSpace(_current.PhoneNumber) || !tbPhoneNumber.IsMaskFull)
                errors.AppendLine("Введите номер телефона");
            if (string.IsNullOrWhiteSpace(_current.SeriesNumberLicense) || !tbSeriesNumberLicense.IsMaskFull)
                errors.AppendLine("Введите серию(4 цифры) и номер(6 цифр) водительского удостоверения");
            if (_current.DateDriverLicense.Year < 2012)
                errors.AppendLine("Укажите дату выдачи водительского удостоверения");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (_current.IdClient == 0)
                ProkatEntities.GetContext().Client.Add(_current);

            try
            {
                ProkatEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
