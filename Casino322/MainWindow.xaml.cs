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
using Casino322.Pages;

namespace Casino322
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(new StartPage(this));
            WMP.URL = "C:\\Users\\Ильдар\\source\\repos\\Casino322\\Casino322\\Music\\lasvegas.mp3";
            WMP.settings.volume = 1; 
            WMP.controls.play();
        }
    }
}
