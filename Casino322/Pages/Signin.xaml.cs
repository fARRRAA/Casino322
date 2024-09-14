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
using System.Xml.Linq;
using Casino322.DB;
namespace Casino322.Pages
{
    /// <summary>
    /// Логика взаимодействия для Signin.xaml
    /// </summary>
    public partial class Signin : Page
    {
        private MainWindow _mainWindow;
        public Signin(MainWindow mw)
        {
            _mainWindow = mw;
            InitializeComponent();
            txtLogin.Text = "fara";
            txtPassword.Password = "123";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.NavigationService.Navigate(new Signup(_mainWindow));
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            var login = txtLogin.Text;
            var password = txtPassword.Password;
            var temp = new Users()
            {
                Login = login,
                Password = password,
                Role = "admin"
            };

            var check = ConnectionDB.db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (check == null)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else
            {
                _mainWindow.MainFrame.NavigationService.Navigate(new UserPage(_mainWindow,check));
                var up = new UserPage(_mainWindow, check);
                
            }
        }
    }
}
