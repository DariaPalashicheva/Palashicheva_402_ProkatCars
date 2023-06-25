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
    /// Логика взаимодействия для FeedbackPage.xaml
    /// </summary>
    public partial class FeedbackPage : Page
    {
        public FeedbackPage()
        {
            InitializeComponent();
            DGrid.ItemsSource = ProkatEntities.GetContext().Feedback.ToList();
            if (AppFrame.DostupRole == 0)
            {
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
                Column.Visibility = Visibility.Collapsed;
            }
            if (AppFrame.DostupRole == 1)
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                Column.Visibility = Visibility.Visible;
            }
            if (AppFrame.DostupRole == 2)
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                Column.Visibility = Visibility.Visible;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ProkatEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = ProkatEntities.GetContext().Feedback.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new FeedbackAddEdit((sender as Button).DataContext as Feedback));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.Navigate(new FeedbackAddEdit(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = DGrid.SelectedItems.Cast<Feedback>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить выбранные данные?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ProkatEntities.GetContext().Feedback.RemoveRange(ForRemoving);
                    ProkatEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    DGrid.ItemsSource = ProkatEntities.GetContext().Feedback.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
