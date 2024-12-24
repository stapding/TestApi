using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppAbonents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void regBTN_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void authBTN_Click(object sender, RoutedEventArgs e)
        {
            var user = Api.Auth(emailTB.Text, passwordTB.Text).Result;
            if (user != null)
            {
                Application.Current.Properties["currentUser"] = user;
                ListAbonents listAbonents = new ListAbonents();
                listAbonents.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Введите корректные данные");
            }
        }
    }
}