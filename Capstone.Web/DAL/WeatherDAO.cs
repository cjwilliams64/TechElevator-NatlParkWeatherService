using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherDAO : IWeatherDAO
    {
        private string connectionString;

        public WeatherDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public List<Weather> GetFiveDayForecast(string parkCode)
        {
            List<Weather> fiveDayForecast = new List<Weather>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM weather where parkCode = @parkCode ORDER BY fiveDayForecastValue", connection);
                    command.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        fiveDayForecast.Add(MapRowToWeather(reader));
                    }
                }
            }
            catch (SqlException)
            {
                fiveDayForecast = new List<Weather>();
            }
            return fiveDayForecast;
        }



        public Weather GetWeather(string parkCode)
        {
            Weather weather = new Weather();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM weather where parkCode = @parkCode", connection);

                    command.Parameters.AddWithValue("@parkCode", parkCode);

                    //JOIN park on park.parkCode = weather.parkCode

                    SqlDataReader reader = command.ExecuteReader();

                   while (reader.Read())
                    {
                        weather = MapRowToWeather(reader);
                    }
                }
            }
            catch 
            {
                weather = new Weather();
            }
            return weather;
        }

        private Weather MapRowToWeather(SqlDataReader reader)
        {
            Weather weather = new Weather();
            weather.ParkCode = Convert.ToString(reader["parkCode"]);
            weather.FiveDayForecast = Convert.ToInt32(reader["fiveDayForecastValue"]);
            weather.Low = Convert.ToInt32(reader["low"]);
            weather.High = Convert.ToInt32(reader["high"]);
            weather.Forecast = Convert.ToString(reader["forecast"]);
           


            return weather;



            //partly cloudy is two words!
        }

        //private Park MapRowToPark(SqlDataReader reader)
        //{
        //    Park park = new Park();

        //    park.ParkCode = Convert.ToString(reader["parkCode"]);
        //    park.ParkName = Convert.ToString(reader["parkName"]);
        //    park.State = Convert.ToString(reader["state"]);
        //    park.Description = Convert.ToString(reader["parkDescription"]);
        //    park.Acreage = Convert.ToInt32(reader["acreage"]);
        //    park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
        //    park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
        //    park.Campsites = Convert.ToInt32(reader["numberOfCampsites"]);
        //    park.Climate = Convert.ToString(reader["climate"]);
        //    park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
        //    park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
        //    park.Quote = Convert.ToString(reader["inspirationalQuote"]);
        //    park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
        //    park.EntryFee = Convert.ToDecimal(reader["entryFee"]);
        //    park.AnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

        //    return park;

        //}
    }
}

