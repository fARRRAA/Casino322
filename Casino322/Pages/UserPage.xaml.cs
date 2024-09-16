using Casino322.DB;
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

namespace Casino322.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private MainWindow _mainWindow;
        private Users _user;

        public UserPage(MainWindow mw, Users user)
        {
            InitializeComponent();
            _mainWindow = mw;
            _user = user;
            txtName.Text = user.Name;
            txtLogin.Text = user.Login;
            txtPassword.Password = user.Password;
            txtBalance.Text = user.Balance.HasValue ? $"Баланс: {user.Balance} ₽" : $"Баланс: 0 ₽";
            checkAdmin();
        }

        private void ButtonRedact_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var login = txtLogin.Text;
            var password = txtPassword.Password;


            var User = ConnectionDB.db.Users.FirstOrDefault(x => x.Login == _user.Login && x.Password == _user.Password && x.Id_User == _user.Id_User);


            if (User != null)
            {
                User.Login = login;
                User.Password = password;
                User.Name = name;
                ConnectionDB.db.SaveChanges();
                MessageBox.Show("Редактирование прошло успешно");
                txtName.Text = name;
                txtLogin.Text = login;
                txtPassword.Password = password;
            }
            else
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        public void checkAdmin()
        {
            if (_user.Role != "admin")
            {
                AdminPanelBtn.Height = 0;
                AdminPanelBtn.Width = 0;
                AdminPanelBtn.Visibility = Visibility.Collapsed;

            }
        }

        public string trim(String str)
        {

            string[] parts = str.Split(new[] { ':' }, 2);
            if (parts.Length > 1)
            {
                string result = parts[1].Trim();
                return result;
            }
            return str;
        }


        private void PayClick_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(CountPay.Text) || string.IsNullOrEmpty(typePay.SelectedValue.ToString()) || string.IsNullOrEmpty(MethodPay.SelectedValue.ToString()))
            {
                MessageBox.Show("Заполните поля");
                return;
            }
            var type = trim(typePay.SelectedValue.ToString());
            var method = trim(MethodPay.SelectedValue.ToString());

            string[] parts = type.Split(new[] { ':' }, 2);
            if (parts.Length > 1)
            {
                string result = parts[1].Trim();
                type = result;

            }
            string[] parts1 = method.Split(new[] { ':' }, 2);
            if (parts.Length > 1)
            {
                string result = parts[1].Trim();
                method = result;

            }


            var count = Convert.ToInt32(CountPay.Text);
            if (type == "Списание" && _user.Balance < 1)
            {
                MessageBox.Show("Баланс нулевой, нельзя выполнить операцию");
                return;
            }
            var tempPay = new Payments()
            {
                TypePay = type,
                MethodPay = method,
                Count = count,
                Users = _user
            };

            if (type == null || method == null || count > 0)
            {
                if (count > _user.Balance && type == "Списание")
                {
                    MessageBox.Show("Слишком большая сумма");
                    return;
                }
                ConnectionDB.db.Payments.Add(tempPay);
                ConnectionDB.db.SaveChanges();
                MessageBox.Show("Операция прошла успешно");
            }
            var User = ConnectionDB.db.Users.FirstOrDefault(x => x.Login == _user.Login && x.Password == _user.Password && x.Id_User == _user.Id_User);

            if (type == "Оплата")
            {
                if (!User.Balance.HasValue)
                {
                    User.Balance = 0;
                    ConnectionDB.db.SaveChanges();
                }

                User.Balance += count;
                ConnectionDB.db.SaveChanges();
                txtBalance.Text = $"Баланс: {User.Balance} ₽";
            }
            if (type == "Списание")
            {
                if (!User.Balance.HasValue)
                {
                    User.Balance = 0;
                    ConnectionDB.db.SaveChanges();
                }
                ConnectionDB.db.SaveChanges();
                User.Balance -= count;

                ConnectionDB.db.SaveChanges();
                txtBalance.Text = $"Баланс: {User.Balance} ₽";
            }
        }

        private void RoulPlay_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.NavigationService.Navigate(new RoulettePlay(_mainWindow, _user));
        }

        private void AdminPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.NavigationService.Navigate(new AdminPage(_mainWindow, _user));
        }

        private void StatsBtn_Click(object sender, RoutedEventArgs e)
        {
            var stats = new UserStats(_user);
            stats.ShowDialog();
        }
    }
}
