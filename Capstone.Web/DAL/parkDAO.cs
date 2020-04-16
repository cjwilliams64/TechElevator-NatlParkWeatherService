using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.DAL
{
    public class parkDAO : IParkDAO
    {

        private string connectionString;

        public parkDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public IList<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM park", connection);

                    //order by parkName 

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        parks.Add(MapRowToPark(reader));
                    }
                }
            }
            catch
            {
                parks = new List<Park>();
            }
            return parks;
        }

        public Park GetParkDetail(string parkCode)
        {
            Park park = new Park();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM park where parkCode = @parkCode", connection);
                    command.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        park = MapRowToPark(reader);
                    }
                }
            }
            catch
            {
                park = new Park();

            }
            return park;
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            Park park = new Park();

            park.ParkCode = Convert.ToString(reader["parkCode"]);
            park.ParkName = Convert.ToString(reader["parkName"]);
            park.State = Convert.ToString(reader["state"]);
            park.Description = Convert.ToString(reader["parkDescription"]);
            park.Acreage = Convert.ToInt32(reader["acreage"]);
            park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
            park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
            park.Campsites = Convert.ToInt32(reader["numberOfCampsites"]);
            park.Climate = Convert.ToString(reader["climate"]);
            park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
            park.Quote = Convert.ToString(reader["inspirationalQuote"]);
            park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            park.EntryFee = Convert.ToDecimal(reader["entryFee"]);
            park.AnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return park;

        }

        public List<SelectListItem> GetParkList()
        {
            List<SelectListItem> parkList = new List<SelectListItem>();

            try

            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM park");
                  

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        SelectListItem park = new SelectListItem();

                        park.Text = Convert.ToString(reader["parkName"]);
                        park.Value = Convert.ToString(reader["parkCode"]);

                        parkList.Add(park);
                    }
                }
            }
            catch
            {
                parkList = new List<SelectListItem>();

            }

            return parkList;
        }
        //private Weather MapRowToWeather(SqlDataReader reader)
        //{
        //    Weather weather = new Weather();
        //    weather.ParkCode = Convert.ToString(reader["parkCode"]);
        //    weather.FiveDayForecast = Convert.ToInt32(reader["fiveDayForecastValue"]);
        //    weather.Low = Convert.ToInt32(reader["low"]);
        //    weather.High = Convert.ToInt32(reader["high"]);
        //    weather.Forecast = Convert.ToString(reader["forecast"]);

        //    return weather;
        //}
    }
}
