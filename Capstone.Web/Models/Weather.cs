using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        /// <summary>
        /// A short string that uniquely identifies a park
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// The forecast day.  Today is day 1, tomorrow is day 2, etc. 
        /// </summary>
        public int FiveDayForecast { get; set; }


        //public string DayofTheWeek
        //{
        //    get
        //    {
               
        //        return dayOfWeek;
        //    }
        //}


        /// <summary>
        /// The expected low temperature in  degrees Fahrenheit 
        /// </summary>
        public int Low { get; set; }

        /// <summary>
        /// The expected high temperature in degrees Fahrenheit
        /// </summary>
        public int High { get; set; }

        /// <summary>
        /// The expected weather.  
        ///possible values: sunny, partly cloudy, cloudy, rain, thunderstorms, snow
        /// </summary>
        public string Forecast { get; set; }


        //see #3. messages need to be added for forecast and temperature

        public string ForecastMessage
        {
            get
            {
                string message = "";

                if (Forecast == "snow")
                {
                    message = "Pack Snowshoes and wear warm clothes!";
                }
                else if (Forecast == "rain")
                {
                    message = "Pack an Umbrella, various rain gear, and wear waterproof shoes! Stay dry!";
                }
                else if (Forecast == "thunderstorms")
                {
                    message = "Seek Shelter and avoid hiking on exposed ridges!";
                }
                else if (Forecast == "sunny")
                {
                    message = "Pack sunblock!";
                }

                return message;
            }

        }

        public string TempMessage
        {
            get
            {
                string tempMessage = "";

                if (High > 75)
                {
                    tempMessage = "Bring an extra gallon of water";
                }

                else if (High - Low <= 20)
                {
                    tempMessage = "Wear breathable layers";
                }
                else if (Low < 20)
                {
                    tempMessage = "Warning: Dangers of exposure to frigid temperatures";

                }
                return tempMessage;
            }
        }
        public double CelciusConvert
        {
            get
            {
                double cHigh = (High * 1.8) + 32;
                double cLow = (Low * 1.8) + 32;

                return 0;
            }
        }
    }
}


