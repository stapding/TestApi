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
    /// Логика взаимодействия для ChangeAddWindow.xaml
    /// </summary>
    public partial class ChangeAddWindow : Window
    {
        public string currentAction = Application.Current.Properties["Action"].ToString();
        public ChangeAddWindow()
        {
            InitializeComponent();
            if (currentAction == "Добавить")
            {
                mainField.Content = "Добавление абонента";
                actionBTN.Content = currentAction;
            }
            else
            {
                Abonent currentAbonent = (Abonent)Application.Current.Properties["currentAbonent"];
                nameTB.Text = currentAbonent.Name;
                phoneTB.Text = currentAbonent.Phone;
                addressTB.Text = currentAbonent.Address;
                surnameTB.Text = currentAbonent.Surname;
                pochtaTB.Text = currentAbonent.Pochta;
                patronymicTB.Text = currentAbonent.Patronymic;
            }
        }

        private void returnBTN_Click(object sender, RoutedEventArgs e)
        {
            ListAbonents listAbonents = new ListAbonents();
            listAbonents.Show();
            this.Close();
        }

        private void authBTN_Click(object sender, RoutedEventArgs e)
        {
            if (currentAction == "Добавить")
            {
                var user = Api.AddAbonent(nameTB.Text, phoneTB.Text, addressTB.Text, surnameTB.Text, pochtaTB.Text, patronymicTB.Text).Result;
            }
            else
            {
                Abonent currentAbonent = (Abonent)Application.Current.Properties["currentAbonent"];
                var user = Api.EditAbonent(currentAbonent.Id,nameTB.Text, phoneTB.Text, addressTB.Text, surnameTB.Text, pochtaTB.Text, patronymicTB.Text).Result;

            }
        }

        private void actionBTN_Click(object sender, RoutedEventArgs e)
        {
            if (currentAction == "Добавить")
            {
                Api.AddAbonent(nameTB.Text, phoneTB.Text, addressTB.Text, surnameTB.Text, pochtaTB.Text, patronymicTB.Text);
                MessageBox.Show("Успех!");
            }
            else
            {
                Abonent currentAbonent = (Abonent)Application.Current.Properties["currentAbonent"];
                Api.EditAbonent(currentAbonent.Id, nameTB.Text, phoneTB.Text, addressTB.Text, surnameTB.Text, pochtaTB.Text, patronymicTB.Text);
                MessageBox.Show("Успех!");
            }
        }
    }
}
