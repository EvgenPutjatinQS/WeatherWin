using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WeatherWin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataWeather DW = new DataWeather();

        public MainWindow()
        {
            InitializeComponent();
            DW.DataHTML();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Town.Text = DW.Town();
            Temperature.Text = DW.Temperature();
            osadki.Text = DW.Osadki();
            speed.Text = DW.Wind();
            Napravlenie.Text = DW.Napravlenie();
            davlenie.Text = DW.Davlenie();
        }
    }
}
