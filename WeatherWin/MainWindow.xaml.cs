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
        string kharkov = "https://www.gismeteo.ua/weather-kharkiv-5053/";
        DataWeather DW = new DataWeather("kharkov");
        //Town towns = new Town();

        public MainWindow()
        {
            InitializeComponent();
            DW.DataHTML();
            Town.Text = DW.Town();
            Temperature.Text = DW.Temperature();
            osadki.Text = DW.Osadki();
            speed.Text = DW.Wind();
            Napravlenie.Text = DW.Napravlenie();
            davlenie.Text = DW.Davlenie();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Add("Львов");
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Львов")
            {
                string lyvov = "https://www.gismeteo.ua/weather-lviv-4949/";
                test.Text = comboBox1.SelectedItem.ToString();

            }
        }
    }
}
