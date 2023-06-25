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
    /// Логика взаимодействия для FeedbackAddEdit.xaml
    /// </summary>
    public partial class FeedbackAddEdit : Page
    {
        private Feedback _current = new Feedback();

        public FeedbackAddEdit(Feedback selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;

            DataContext = _current;
            ComboStar.ItemsSource = ProkatEntities.GetContext().Star.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_current.Sender))
                errors.AppendLine("Введите ФИО");
            if (string.IsNullOrWhiteSpace(_current.Text))
                errors.AppendLine("Введите текст отзыва");
            if (_current.Star == null)
                errors.AppendLine("Пожалуйста укажите количество звёзд");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (_current.IdFeedback == 0)
                ProkatEntities.GetContext().Feedback.Add(_current);

            try
            {
                ProkatEntities.GetContext().SaveChanges();
                MessageBox.Show("Отзыв успешно сохранен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
