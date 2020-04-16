using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DetailViewModel
    {
        public Park Park { get; set; }

        public List<Weather> FiveDayForecast { get; set; }

        public Weather weather {get; set;}

        public bool isFahrenheit { get; set; }

        public string TemperatureSetting { get; set; }
    }
}
