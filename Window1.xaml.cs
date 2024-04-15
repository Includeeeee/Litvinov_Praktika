using System;
using System.Collections.Generic;
using System.IO.Pipes;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private List<char> _specialSumb = new List<char>()
        {
              '+','!','-','=',',','.','/',';',':','`','<','>','?','#'
        };
        private List<char> _Sobachka = new List<char>()
        {
            '@'
        };

        public char X { get; private set; }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            var login = lgm.Text;
            var Email = eml.Text;
            var pass = psww.Text;
            var password = pwd.Text;
            var context = new ApplicationContext();
            var user = context.Users.FirstOrDefault(X => X.Login == login && X.Email == eml.Text);
            if (user is not null)
            {
                MessageBox.Show("Такой пользовательно уже зарегистрирован");
                return;
            }
            if (!Email.Any(x => _Sobachka.Contains(x)))
            {
                eml.Text = ("Некорректная почта");
                if (pass.Length > 5)
                {
                    RedLine2.Visibility = Visibility.Hidden;
                    Vivod2.Text = ("Пароли не совпадают");
                    return;
                }
                else
                {
                    RedLine2.Visibility = Visibility.Hidden;
                }
                if (!pass.Any(XmlDataProvider => _specialSumb.Contains(X)))
                {
                    RedLine2.Visibility = Visibility.Visible;
                    Vivod2.Text = ("Пароли не совпадают");
                    return ;
                }
            }
            var user1 = new user_exists { Login = login, Password = pass, Email = Email };
            context.Users.Add(user1);
            context.SaveChanges();
            MessageBox.Show("хелло");
            {
                MainWindow window = new();

                window.Show();
                this.Hide();
            }


           

            

        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void eml_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void psww_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void eml_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
