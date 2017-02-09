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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace WeatherWin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataWeather DW = new DataWeather();
        string kharkov = @"https://www.gismeteo.ua/weather-kharkiv-5053/";
        string lyviv = @"https://www.gismeteo.ua/weather-lviv-4949/";
        string odessa = @"https://www.gismeteo.ua/weather-odessa-4982/";
        string kyev = @"https://www.gismeteo.ua/weather-kyiv-4944/";
        string uschgorod = @"https://www.gismeteo.ua/weather-uzhhorod-4969/";

        public MainWindow()
        {
            InitializeComponent();
            Update();
            Off_3_Days();
        }

        public void Update()
        {
            
            DW.DataHTML();
            Town.Text = DW.Town();
            Town3.Text = DW.Town();
            Town5.Text = DW.Town();
            Temperatura.Text = DW.Temperature();
            Osadki.Text = DW.Osadki();
            Speed.Text = DW.Wind();
            Napravl.Text = DW.Napravlenie();
            Davlenie.Text = DW.Davlenie();
            Data.Text = DateTime.Now.ToString("dd.MM.yyyy");
            Date3_1.Text = DW.Data_3();
            Date3_2.Text = DW.Data_3_2();
            Date3_3.Text = DW.Data_3_3();
            TempN1.Text = DW.TempN_1_3();
            TempD1.Text = DW.TempD_1_3();
            TempN2.Text = DW.TempN_2_3();
            TempD2.Text = DW.TempD_2_3();
            TempN3.Text = DW.TempN_3_3();
            TempD3.Text = DW.TempD_3_3();
            Picture();
        }
        void Picture()
        {
            switch (Osadki.Text)
            {
                case "Ясно":
                    ViewImage.Source = new BitmapImage(new Uri(@"Images/Ясно.png", UriKind.Relative));
                    break;
                case "Малооблочно":
                    ViewImage.Source = new BitmapImage(new Uri(@"Images/Малооблочно.png", UriKind.Relative));
                    break;
                case "Пасмурно":
                    ViewImage.Source = new BitmapImage(new Uri(@"Images/Пасмурно.png", UriKind.Relative));
                    break;
                case "Пасмурно, небольшой снег":
                    ViewImage.Source = new BitmapImage(new Uri(@"Images/Пасмурно_снег.png", UriKind.Relative));
                    break;
                default:
                    ViewImage.Source = new BitmapImage(new Uri(@"Images/Пасмурно_Дымка.png", UriKind.Relative));
                    break;
            }
        }
        void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            DW.DataWeatherTown(lyviv);
            Update();
        }
        void Kharkov_Click(object sender, RoutedEventArgs e)
        {
            DW.DataWeatherTown(kharkov);
            Update();
        }
        void Kyev_Click(object sender, RoutedEventArgs e)
        {
            DW.DataWeatherTown(kyev);
            Update();
        }
        void Odessa_Click(object sender, RoutedEventArgs e)
        {
            DW.DataWeatherTown(odessa);
            Update();
        }
        void Uschorod_Click(object sender, RoutedEventArgs e)
        {
            DW.DataWeatherTown(uschgorod);
            Update();
        }

        void day1_Click(object sender, RoutedEventArgs e)
        {
            On_1_Day();
            Off_3_Days();
        }
        void days3_Click(object sender, RoutedEventArgs e)
        {
            On_3_Days();
            Off_1_Day();
        }
        private void On_1_Day()
        {
            ViewImage.Opacity = 1;
            Temperatura.Opacity = 2;
            Osadki.Opacity = 2;
            Davlenie.Opacity = 2;
            Napravl.Opacity = 2;
            Speed.Opacity = 2;
            Data.Opacity = 2;
            Town.Opacity = 2;
            textBlock1.Opacity = 2;
            textBlock2.Opacity = 2;
            textBlock3.Opacity = 2;
            textBlock4.Opacity = 2;
            textBlock5.Opacity = 2;
            textBlock7.Opacity = 2;
        }
        private void Off_1_Day()
        {
            ViewImage.Opacity = 0;
            Temperatura.Opacity = 0;
            Osadki.Opacity = 0;
            Davlenie.Opacity = 0;
            Napravl.Opacity = 0;
            Speed.Opacity = 0;
            Data.Opacity = 0;
            Town.Opacity = 0;
            textBlock1.Opacity = 0;
            textBlock2.Opacity = 0;
            textBlock3.Opacity = 0;
            textBlock4.Opacity = 0;
            textBlock5.Opacity = 0;
            textBlock7.Opacity = 0;
        }
        private void On_3_Days()
        {
            Town3.Opacity = 2;
            image1_3.Opacity = 1;
            image2_3.Opacity = 1;
            image3_3.Opacity = 1;
            Date3_1.Opacity = 2;
            Date3_2.Opacity = 2;
            Date3_3.Opacity = 2;
            TempN1.Opacity = 2;
            TempN2.Opacity = 2;
            TempN3.Opacity = 2;
            TempD1.Opacity = 2;
            TempD2.Opacity = 2;
            TempD3.Opacity = 2;
        }
        private void Off_3_Days()
        {
            Town3.Opacity = 0;
            image1_3.Opacity = 0;
            image2_3.Opacity = 0;
            image3_3.Opacity = 0;
            Date3_1.Opacity = 0;
            Date3_2.Opacity = 0;
            Date3_3.Opacity = 0;
            TempN1.Opacity = 0;
            TempN2.Opacity = 0;
            TempN3.Opacity = 0;
            TempD1.Opacity = 0;
            TempD2.Opacity = 0;
            TempD3.Opacity = 0;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
