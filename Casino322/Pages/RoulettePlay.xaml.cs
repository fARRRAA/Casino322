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
    /// Логика взаимодействия для RoulettePlay.xaml
    /// </summary>
    public partial class RoulettePlay : Page
    {

        private MainWindow _mainWindow;
        private Users _user;
        public RoulettePlay(MainWindow mw, Users user)
        {
            InitializeComponent();
            _mainWindow = mw;
            _user = user;
        }
    }
}
