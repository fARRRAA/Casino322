using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Casino322.DB;
namespace Casino322.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoulettePlay.xaml
    /// </summary>
    public partial class RoulettePlay : Page
    {
        private MainWindow _mainWindow;
        private Users _user;
        public int Bet = 0;
        public int Result;
        public int? Stavka = null;
        public int Winnings = 0;
        public int Games = 0;
        public string stavkaColor;
        public List<int> fishka = new List<int>();
        public List<int> reds = new List<int>() { 1, 3, 5, 7, 9, 12, 14, 16, 18, 21, 23, 25, 27, 30, 32, 34, 36 };
        public List<int> blacks = new List<int>() { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

        public DateTime SessionStart=DateTime.Now;
        public RoulettePlay(MainWindow mw, Users user)
        {
            InitializeComponent();
            _mainWindow = mw;
            _user = user;
            txtBet.Text = $"Ваша Ставка: {Bet}";
            txtBalance.Text = $"Ваш Баланс: {_user.Balance}";
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = new Session()
            {
                Start=SessionStart,
                Session_End=DateTime.Now,
                User_Id= _user.Id_User,
                Games_Count=Games,
                Winnig_Count=Winnings
            };
            ConnectionDB.db.Session.Add(temp);
            ConnectionDB.db.SaveChanges();
            _mainWindow.MainFrame.NavigationService.Navigate(new UserPage(_mainWindow, _user));
        }
        private void Bet1_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            fishka.Add(1);
        }
        private void Bet5_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            fishka.Add(5);
        }
        private void Bet10_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            fishka.Add(10);
        }
        private void Bet20_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            fishka.Add(20);
        }
        private void Bet50_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            fishka.Add(50);
        }
        private void Bet100_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            fishka.Add(100);
        }
        private void Bet500_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            fishka.Add(500);
        }
        private void Bet1000_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            txtBet.Text = $"Ваша Ставка: {Bet}";
            fishka.Add(1000);
        }
        private void Bet5000_Click(object sender, RoutedEventArgs e)
        {
            fishka.Clear();
            txtBet.Text = $"Ваша Ставка: {Bet}";
            fishka.Add(5000);
        }
        public async Task SpinWheel()
        {
            int angle = 0;
            int duration = 3000;
            int stepAngle = 10;
            int interval = 20;
            Timer timer = new Timer((o) =>
            {
                angle -= stepAngle;
                Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
                {
                    wheel.RenderTransformOrigin = new Point(0.5, 0.5);
                    wheel.RenderTransform = new RotateTransform(angle);
                });
            }, null, 0, interval);
            await Task.Delay(duration);
            timer.Dispose();
        }
        private async void SpinBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Games > 0)
            {
                GridsClear();
                Bet = 0;
                if (string.IsNullOrEmpty(stavkaColor) && Stavka.HasValue)
                {
                    Stavka = 0;
                }
                stavkaColor = "";
                txtBet.Text = "Ваша ставка: ";
                txtStavka.Text = "Ваше число: ";
                GridsClear();
                txtRes.Text = "";
            }
            txtResult.Text = $"Выпавшее число: ";
            if (Bet < 1 || !Stavka.HasValue)
            {
                if (string.IsNullOrEmpty(stavkaColor))
                {
                    MessageBox.Show("Сделайте ставку");
                    return;
                }
            }
            await SpinWheel();
            var random = new Random();
            Result = random.Next(0, 36);
            txtResult.Text = $"Выпавшее число: {Result}";
            //обработка результата
            int winMoney = 0;
            var User = ConnectionDB.db.Users.FirstOrDefault(x => x.Login == _user.Login && x.Password == _user.Password && x.Id_User == _user.Id_User);
            if (Stavka == Result && Stavka.HasValue && string.IsNullOrEmpty(stavkaColor))
            {
                winMoney = Bet * 2;
                User.Balance += winMoney;
                ConnectionDB.db.SaveChanges();
                txtBalance.Text = $"Ваш Баланс: {User.Balance}";
                Winnings++;
            }
            if (Stavka != Result && Stavka.HasValue && string.IsNullOrEmpty(stavkaColor))
            {
                winMoney = 0;
                User.Balance -= Bet;
                ConnectionDB.db.SaveChanges();
                txtBalance.Text = $"Ваш Баланс: {User.Balance}";
            }
            string win1 = "";
            if (!string.IsNullOrEmpty(stavkaColor) && !Stavka.HasValue)
            {
                if (stavkaColor == "red")
                {
                    if (reds.Contains(Result))
                    {
                        winMoney += Bet * 2;
                        User.Balance += winMoney;
                        ConnectionDB.db.SaveChanges();
                        txtBalance.Text = $"Ваш Баланс: {User.Balance}";
                        Winnings++;
                        txtRes.Text = "Вы Выиграли";
                        txtRes.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2BFF00"));
                        win1 = "Победа";
                    }
                    else
                    {
                        winMoney = 0;
                        User.Balance -= Bet;
                        ConnectionDB.db.SaveChanges();
                        txtBalance.Text = $"Ваш Баланс: {User.Balance}";
                        txtRes.Text = "Вы Проиграли";
                        txtRes.Foreground = Brushes.Red;
                        win1 = "Поражение";
                    }
                }
                if (stavkaColor == "black")
                {
                    if (blacks.Contains(Result))
                    {
                        winMoney += Bet * 2;
                        User.Balance += winMoney;
                        ConnectionDB.db.SaveChanges();
                        txtBalance.Text = $"Ваш Баланс: {User.Balance}";
                        Winnings++;
                        txtRes.Text = "Вы Выиграли";
                        txtRes.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2BFF00"));
                        win1 = "Победа";
                    }
                    else
                    {
                        winMoney = 0;
                        User.Balance -= Bet;
                        ConnectionDB.db.SaveChanges();
                        txtBalance.Text = $"Ваш Баланс: {User.Balance}";
                        txtRes.Text = "Вы Проиграли";
                        txtRes.Foreground = Brushes.Red;
                        win1 = "Поражение";
                    }
                }
            }
            string win = "";
            if (string.IsNullOrEmpty(stavkaColor) && Stavka.HasValue)
            {
                win = Stavka == Result ? win = "Победа" : "Поражение";
                if (win == "Поражение")
                {
                    txtRes.Text = "Вы Проиграли";
                    txtRes.Foreground = Brushes.Red;
                }
                else
                {
                    txtRes.Text = "Вы Выиграли";
                    txtRes.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2BFF00"));
                }
            }
            if (!string.IsNullOrEmpty(stavkaColor) && !Stavka.HasValue)
            {
                var tempGames = new Games()
                {
                    Game_Date = DateTime.Now,
                    Game_Stavka = Convert.ToString(stavkaColor),
                    Game_Bet = Bet,
                    Game_Result = Convert.ToString(Result),
                    Win = win1,
                    Win_Count = winMoney,
                    User_Id = User.Id_User
                };
                ConnectionDB.db.Games.Add(tempGames);
                ConnectionDB.db.SaveChanges();
            }
            if (Stavka.HasValue)
            {
                var tempGames = new Games()
                {
                    Game_Date = DateTime.Now,
                    Game_Stavka = Convert.ToString(Stavka),
                    Game_Bet = Bet,
                    Game_Result = Convert.ToString(Result),
                    Win = win,
                    Win_Count = winMoney,
                    User_Id = User.Id_User
                };
                ConnectionDB.db.Games.Add(tempGames);
                ConnectionDB.db.SaveChanges();
            }
            Games++;
            if (string.IsNullOrEmpty(stavkaColor) && Stavka.HasValue)
            {
                Stavka = 0;
            }
            stavkaColor = "";
            txtBet.Text = "Ваша ставка: ";
            txtStavka.Text = "Ваше число: ";
            GridsClear();
        }
        private Image addImage(int value, Grid grid)
        {
            Image Img = new Image();
            Img.Source = new BitmapImage(new Uri($@"pack://application:,,,/Images/Bets/Bet{value}.png"));
            Img.Height = 25;
            Img.Width = 25;
            Img.SetValue(Grid.ColumnProperty, grid.Children.Count);
            return Img;
        }
        private void zero_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 0;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 0;
            zeroGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void one_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 1;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 1;
            oneGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void two_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 2;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 2;
            twoGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void three_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 3;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 3;
            threeGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void four_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 4;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 4;
            fourGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void five_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 5;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 5;
            fiveGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void six_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 6;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 6;
            sixGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void seven_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 7;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 7;
            sevenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void eight_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 8;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 8;
            eightGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void nine_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 9;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 9;
            nineGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void ten_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 10;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 10;
            tenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void eleven_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 11;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 11;
            elevenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twelve_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 12;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 12;
            twelveGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void thirteen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 13;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 13;
            thirteenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void fourtheen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 14;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 14;
            fourtheenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void fiftheen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 15;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 15;
            fiftheenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void sixtheen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 16;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 16;
            sixtheenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void seventheen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 17;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 17;
            seventheenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void eighteen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 18;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 18;
            eighteenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void ninghteen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 19;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 19;
            ninghteenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twenty_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 20;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 20;
            twentyGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentyone_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 21;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 21;
            twentyoneGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentytwo_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 22;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 22;
            twentytwoGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentythree_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 23;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 23;
            twentythreeGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentyfour_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 24;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 24;
            twentyfourGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentyfive_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 25;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 25;
            twentyfiveGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentysix_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 26;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 26;
            twentysixGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentyseven_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 27;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 27;
            twentysevenGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentyeight_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 28;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 28;
            twentyeightGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void twentynine_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 29;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 29;
            twentynineGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void thirty_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 30;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 30;
            thirtyGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void thirtyone_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 31;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 31;
            thirtyoneGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void thirtytwo_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 32;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 32;
            thirtytwoGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void thirtythree_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 33;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 33;
            thirtythreeGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void thirtyfour_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 34;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 34;
            thirtyfourGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void thirtyfive_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 35;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 35;
            thirtyfiveGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void thirtysix_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(stavkaColor))
            {
                return;
            }
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            var temp = 36;
            if (Stavka.HasValue && Stavka != temp)
            {
                MessageBox.Show("Поставить можно только на одно число");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            Stavka = 36;
            thirtysixGrid.Children.Add(addImage(fishka[0], oneGrid));
            txtStavka.Text = $"Ваше число: {Stavka}";
        }
        private void redBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Stavka.HasValue)
            {
                return;
            }
            var temp = "red";
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            if (!string.IsNullOrEmpty(stavkaColor) && stavkaColor != temp)
            {
                MessageBox.Show("Поставить можно только на одно число или цвет");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            stavkaColor = "red";
            redGrid.Children.Add(addImage(fishka[0], redGrid));
            txtStavka.Text = $"Ваше число: {stavkaColor}";
        }
        private void blackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Stavka.HasValue)
            {
                return;
            }
            var temp = "black";
            if (fishka.Count == 0)
            {
                MessageBox.Show("Сделайте ставку");
                return;
            }
            if (!string.IsNullOrEmpty(stavkaColor) && stavkaColor != temp)
            {
                MessageBox.Show("Поставить можно только на одно число или цвет");
                return;
            }
            if (fishka[0] >= 1)
            {
                Bet += fishka[0];
                txtBet.Text = $"Ваша Ставка: {Bet}";
            }
            stavkaColor = "black";
            blackGrid.Children.Add(addImage(fishka[0], blackGrid));
            txtStavka.Text = $"Ваше число: {stavkaColor}";
        }
        public void GridsClear()
        {
            zeroGrid.Children.Clear();
            oneGrid.Children.Clear();
            twoGrid.Children.Clear();
            threeGrid.Children.Clear();
            fourGrid.Children.Clear();
            fiveGrid.Children.Clear();
            sixGrid.Children.Clear();
            sevenGrid.Children.Clear();
            eightGrid.Children.Clear();
            nineGrid.Children.Clear();
            tenGrid.Children.Clear();
            elevenGrid.Children.Clear();
            twelveGrid.Children.Clear();
            thirteenGrid.Children.Clear();
            fourtheenGrid.Children.Clear();
            fiftheenGrid.Children.Clear();
            sixtheenGrid.Children.Clear();
            seventheenGrid.Children.Clear();
            eighteenGrid.Children.Clear();
            ninghteenGrid.Children.Clear();
            twentyGrid.Children.Clear();
            twentyoneGrid.Children.Clear();
            twentythreeGrid.Children.Clear();
            twentyfourGrid.Children.Clear();
            twentyfiveGrid.Children.Clear();
            twentysixGrid.Children.Clear();
            twentysevenGrid.Children.Clear();
            twentyeightGrid.Children.Clear();
            twentynineGrid.Children.Clear();
            thirtyGrid.Children.Clear();
            thirtyoneGrid.Children.Clear();
            thirtytwoGrid.Children.Clear();
            thirtythreeGrid.Children.Clear();
            thirtyfourGrid.Children.Clear();
            thirtyfiveGrid.Children.Clear();
            twentysixGrid.Children.Clear();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
