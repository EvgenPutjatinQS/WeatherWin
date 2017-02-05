using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WeatherWin
{
    class Town
    {
        private ArrayList towns = new ArrayList();

        public void AddTown(string town)
        {
            towns.Add(town);
        }
        
    }
}
