using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace WeatherWin
{
    class DataWeather
    {
        WebRequest getDataHTML;

        string dataHTML, temperature, town, osadki, wind, naprav, davlenie;
        public DataWeather()
        {
            getDataHTML = WebRequest.Create(@"https://www.gismeteo.ua/weather-kharkiv-5053/");
            //getDataHTML = WebRequest.Create(@"https://www.gismeteo.ua/weather-lviv-4949/");
        }

        public void DataWeatherTown(string town)
        {
            getDataHTML = WebRequest.Create(town);
        }
        
        public string DataHTML()
        {
            try
            {
                Stream stream = getDataHTML.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                dataHTML = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                
            }   
            return dataHTML;
        }

        public string Town()
        {
            town = new Regex(@"<h2 class=""typeM"">(?<town>.*)</h2>").Match(dataHTML).Groups["town"].Value;

            return town;
        }
        public string Temperature()
        {
            string pattern = "&minus;";
            string repattern = "-";
            temperature = new Regex(@"<dd class='value m_temp c'>(?<temperature>.*)<span class=""meas"">&deg;C</span></dd>").Match(dataHTML).Groups["temperature"].Value;
            string temp = Regex.Replace(temperature, pattern, repattern);
            return temp;
        }
        public string Osadki()
        {
            osadki = new Regex(@"<td>(?<osadki>.*)</td>").Match(dataHTML).Groups["osadki"].Value;

            return osadki;
        }
        public string Wind()
        {
            wind = new Regex(@"<dd class='value m_wind ms' style='display:inline'>(?<wind>.*)<span class=""unit"">м/с</span></dd>").Match(dataHTML).Groups["wind"].Value;
            return wind;
        }
        public string Davlenie()
        {
            davlenie = new Regex(@"<dd class='value m_press torr'>(?<davlenie>.*)<span class=""unit"">мм рт. ст.</span></dd>").Match(dataHTML).Groups["davlenie"].Value;
            return davlenie;
        }
        public string Napravlenie()
        {
            naprav = new Regex(@"<dt>(?<naprav>.*)</dt>").Match(dataHTML).Groups["naprav"].Value;
            return naprav;
        }
    }
}
