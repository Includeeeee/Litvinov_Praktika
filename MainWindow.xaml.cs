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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();

            window.Show();
            this.Hide();
        }

        private void Windows_Clos(object sender, TextChangedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void log_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            var login = log.Text;
            var Password = password.Password;
            var context = new ApplicationContext();
            var user = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password.Password);
            if (user == null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return;
            }


            MessageBox.Show("Вы успешно авторизовались");
                var window = new Window2();
                window.Show();
                this.Hide();
        }
    }
}