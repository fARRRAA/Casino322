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
using Casino322.DB;
namespace Casino322.Pages
{
    /// <summary>
    /// Логика взаимодействия для Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        private MainWindow _mainWindow;
        public Signup(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

        }

        private void signin_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.NavigationService.Navigate(new Signin(_mainWindow));
        }

        private void ButtonSignup_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var login = txtLogin.Text;
            var password = txtPassword.Password;
            var temp = new Users()
            {
                Name = name,
                Login = login,
                Password = password,
                Role = "admin"
            };

            var check = ConnectionDB.db.Users.FirstOrDefault(x=>x.Login==login && x.Password==password);
            if (check != null)
            {
                MessageBox.Show("Такой юзер уже есть"); 
            }
            else
            {
                ConnectionDB.db.Users.Add(temp);
                ConnectionDB.db.SaveChanges();
                MessageBox.Show("Юзер успешно добавился");
                _mainWindow.MainFrame.NavigationService.Navigate(new UserPage(_mainWindow, temp));

            }
        }
    }
}
