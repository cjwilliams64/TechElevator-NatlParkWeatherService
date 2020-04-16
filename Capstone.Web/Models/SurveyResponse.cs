using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResponse
    {
        public Survey survey { get; set; }
        /// <summary>
        /// the code assigned to the park that the user decided to vote on
        /// </summary>
        public string ParkCode { get; set; }


        /// <summary>
        /// the name of the park
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// the count of votes for a particular park
        /// </summary>
        public int VotesForPark { get; set; }
      
    }
}
