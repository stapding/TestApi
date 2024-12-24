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
using System.Windows.Shapes;
using WebApplicationAbonents.Models;

namespace WpfAppAbonents
{
    /// <summary>
    /// Логика взаимодействия для ListAbonents.xaml
    /// </summary>
    public partial class ListAbonents : Window
    {
        public User currentUser = (User)Application.Current.Properties["currentUser"];
        public ListAbonents()
        {
            InitializeComponent();

            userNameTB.Content = currentUser.Name;

            if (currentUser.Role == "user")
            {
                addBTN.Visibility = Visibility.Hidden;
                changeBTN.Visibility = Visibility.Hidden;
                removeBTN.Visibility = Visibility.Hidden;
            }

            foreach (var item in Api.GetAbonents().Result)
            {
                abonentsList.Items.Add(item);
            }
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(searchTB.Text))
            {
                if (searchToLB.SelectedIndex == 0)
                {
                    abonentsList.Items.Clear();
                    foreach (var item in Api.SearchPhoneAbonents(searchTB.Text).Result)
                    {
                        abonentsList.Items.Add(item);
                    }
                }
                else
                {
                    abonentsList.Items.Clear();
                    foreach (var item in Api.SearchSurnameAbonents(searchTB.Text).Result)
                    {
                        abonentsList.Items.Add(item);
                    }
                }
            }
            else
            {
                abonentsList.Items.Clear();
                foreach (var item in Api.GetAbonents().Result)
                {
                    abonentsList.Items.Add(item);
                }
            }
        }

        private void removeBTN_Click(object sender, RoutedEventArgs e)
        {
            if (abonentsList.SelectedItem != null)
            {
                Abonent currentAbonent = (Abonent)abonentsList.SelectedItem;
                var abonentToDelete = Api.DeleteAbonent(currentAbonent.Id);
                if (abonentToDelete != null)
                {
                    abonentsList.Items.Clear();
                    foreach (var item in Api.GetAbonents().Result)
                    {
                        abonentsList.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка в удалении");
                }
            }
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["Action"] = "Добавить";
            ChangeAddWindow changeAddWindow = new ChangeAddWindow();
            changeAddWindow.Show();
            this.Close();
        }

        private void changeBTN_Click(object sender, RoutedEventArgs e)
        {
            if (abonentsList.SelectedItem != null)
            {
                Application.Current.Properties["currentAbonent"] = (Abonent)abonentsList.SelectedItem;
                Application.Current.Properties["Action"] = "Изменить";
                ChangeAddWindow changeAddWindow = new ChangeAddWindow();
                changeAddWindow.Show();
                this.Close();
            }
            
        }
    }
}
