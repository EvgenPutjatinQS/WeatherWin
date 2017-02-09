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
        string data_3 = @"<dl class=""date wrap(?<1>.*)""><dt>(?<1>.*)</dt><dd>(?<data_3>.*)</dd></dl>";
        string temp_3 = @"<div class=""temp""><span class='value m_temp c'>(?<data_3>.*)</span><span class='value m_temp f' style='display:none'>(?<data_1>.*)</span>..<em><span class='value m_temp c'>(?<data_2>.*)</span><span";
        Match match, match_temp;
        Regex reg, temp_reg;
        public DataWeather()
        {
            getDataHTML = WebRequest.Create(@"https://www.gismeteo.ua/weather-kharkiv-5053/");
        }

        public void DataWeatherTown(string town)
        {
            getDataHTML = WebRequest.Create(town);
        }
        
        public string DataHTML()
        {
            Stream stream = getDataHTML.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            dataHTML = sr.ReadToEnd();  
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
        public string Data_3()
        {
            string data;
            reg = new Regex(data_3);
            match = reg.Match(dataHTML);
            data = match.Groups["data_3"].Value;
            return data;
        }
        public string Data_3_2()
        {
            string data;
            match = match.NextMatch();
            data = match.Groups["data_3"].Value;
            return data;
        }
        public string Data_3_3()
        {
            string data;
            match = match.NextMatch();
            data = match.Groups["data_3"].Value;
            return data;
        }

        public string TempN_1_3()
        {
            string pattern = "&minus;";
            string repattern = "-";
            temp_reg = new Regex(temp_3);
            match_temp = temp_reg.Match(dataHTML);
            string data = match_temp.Groups["data_3"].Value;
            string temp = Regex.Replace(data, pattern, repattern);
            return temp;
        }
        public string TempD_1_3()
        {
            string pattern = "&minus;";
            string repattern = "-";
            temp_reg = new Regex(temp_3);
            match_temp = temp_reg.Match(dataHTML);
            string data = match_temp.Groups["data_2"].Value;
            string temp = Regex.Replace(data, pattern, repattern);
            return temp;
        }
        public string TempN_2_3()
        {
            string pattern = "&minus;";
            string repattern = "-";
            match_temp = match_temp.NextMatch();
            string data = match_temp.Groups["data_3"].Value;
            string temp = Regex.Replace(data, pattern, repattern);
            return temp;
        }
        public string TempD_2_3()
        {
            string pattern = "&minus;";
            string repattern = "-";
            string data = match_temp.Groups["data_2"].Value;
            string temp = Regex.Replace(data, pattern, repattern);
            return temp;
        }
        public string TempN_3_3()
        {
            string pattern = "&minus;";
            string repattern = "-";
            match_temp = match_temp.NextMatch();
            string data = match_temp.Groups["data_3"].Value;
            string temp = Regex.Replace(data, pattern, repattern);
            return temp;
        }
        public string TempD_3_3()
        {
            string pattern = "&minus;";
            string repattern = "-";
            string data = match_temp.Groups["data_2"].Value;
            string temp = Regex.Replace(data, pattern, repattern);
            return temp;
        }
    }
}
