using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Casino322.DB;
namespace Casino322.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserStats.xaml
    /// </summary>
    public partial class UserStats : Window
    {
        private Users _user;
        public UserStats(Users user)
        {
            InitializeComponent();
            _user = user;
            getGames();
            getPayments();
        }

        public void getGames()
        {
            List<Games> games = new List<Games>();
            string connectionString = "Server=(localdb)\\Local;Database=Casino;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"select * from Games where user_Id = {_user.Id_User}";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Games game = new Games
                    {
                        Game_Id = (int)reader["Game_Id"],
                        Game_Date = (DateTime)reader["Game_Date"],
                        Game_Stavka = reader["Game_Stavka"].ToString(),
                        Game_Result = reader["game_Result"].ToString(),
                        Game_Bet = (int)reader["game_Bet"],
                        Win = reader["Win"].ToString(),
                        Win_Count = (int)reader["Win_Count"],
                        User_Id =_user.Id_User
                    };
                    games.Add(game);
                }
            }
            ListGames.ItemsSource = games;

        }

        public void getPayments()
        {
            List<Payments> payments = new List<Payments>();
            string connectionString = "Server=(localdb)\\Local;Database=Casino;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"select * from Payments where User_Id = {_user.Id_User}";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Payments payment = new Payments
                    {
                        Payment_Id = (int)reader["Payment_Id"],
                        TypePay = reader["TypePay"].ToString(),
                        MethodPay = reader["MethodPay"].ToString(),
                        User_Id = _user.Id_User,
                        Count = (int)reader["Count"]
                    };

                    payments.Add(payment);
                }
            }
            ListPayments.ItemsSource = payments;

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
