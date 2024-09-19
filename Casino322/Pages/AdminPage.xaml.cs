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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private MainWindow _mainWindow;
        private Users _user;
        public AdminPage(MainWindow mw, Users user)
        {
            InitializeComponent();
            _mainWindow = mw;
            _user = user;
            ListGames.ItemsSource = ConnectionDB.db.Games.ToList();
            ListPayments.ItemsSource = ConnectionDB.db.Payments.ToList();
            ListSessions.ItemsSource = ConnectionDB.db.Session.ToList();
            ListUsers.ItemsSource = ConnectionDB.db.Users.ToList();
            ChanceEdit.Visibility = Visibility.Collapsed;
            ChanceEdit.Opacity = 0;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChanceEdit.Visibility = Visibility.Visible;
            ChanceEdit.Opacity = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int? chance =Convert.ToInt32(txtChance.Text);
            if (!chance.HasValue)
            {
                return;
            }
            var user = ListUsers.SelectedItem as Users;
            var temp = ConnectionDB.db.Users.FirstOrDefault(x => x.Id_User == user.Id_User);
            temp.Chance = chance.Value;
            ConnectionDB.db.SaveChanges();
            ListUsers.ItemsSource = ConnectionDB.db.Users.ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.NavigationService.Navigate(new UserPage(_mainWindow, _user));
        }
    }
}
