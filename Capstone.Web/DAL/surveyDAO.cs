using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class surveyDAO : ISurveyDAO
    {
        private readonly string connectionString;

        public surveyDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql =
@"INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel); Select @@Identity;";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.Email);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);


                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }
        }
        public List<Survey> GetSurveys()
        {
            List<Survey> surveys = new List<Survey>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * from survey_result JOIN park on park.parkCode = survey_result.parkCode", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        surveys.Add(RowToObject(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return surveys;
        }

        public List<SurveyResponse> GetTopParks()
        {
            List<SurveyResponse> responses = new List<SurveyResponse>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT COUNT(survey_result.parkCode) as votes, park.parkName, survey_result.parkCode from survey_result JOIN park on park.parkCode = survey_result.parkCode group by parkName, survey_result.parkCode order by votes desc, parkName asc, parkCode", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        responses.Add(ResponseToObject(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return responses;
        }

        private SurveyResponse ResponseToObject(SqlDataReader reader)
        {
            SurveyResponse rs = new SurveyResponse();

        
            rs.ParkCode = Convert.ToString(reader["parkCode"]);
            rs.ParkName = Convert.ToString(reader["parkName"]);
            rs.VotesForPark = Convert.ToInt32(reader["votes"]);


            //s.Email = Convert.ToString(reader["emailAddress"]);
            //s.State = Convert.ToString(reader["state"]);
            //s.ActivityLevel = Convert.ToString(reader["activityLevel"]);

            return rs;
        }



        private Survey RowToObject(SqlDataReader reader)
        {
            Survey s = new Survey();

            s.SurveyId = Convert.ToInt32(reader["surveyId"]);
            s.ParkCode = Convert.ToString(reader["parkCode"]);
            s.Email = Convert.ToString(reader["emailAddress"]);
            s.State = Convert.ToString(reader["state"]);
            s.ActivityLevel = Convert.ToString(reader["activityLevel"]);

            return s;
        }
    }
}
