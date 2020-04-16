using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        /// <summary>
        /// A short string that uniquely identifies a park
        /// </summary>
        public string ParkCode { get; set; }

        /// <summary>
        /// the name of the park
        /// </summary>
        public string ParkName { get; set; }

        /// <summary>
        /// the state in which the park is located
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///The size of the park in acres
        /// </summary>
        public int Acreage { get; set; }

        /// <summary>
        ///The park’s elevation above sea level (in feet)
        /// </summary>
        public int ElevationInFeet { get; set; }

        // is a 'real' in sql a double in C#? be sure
        /// <summary>
        /// The combined length of all hiking trails in the park 
        /// </summary>
        public double MilesOfTrail { get; set; }

        /// <summary>
        /// The total number of campsites available for visitors in the park 
        /// </summary>
        public int Campsites { get; set; }

        /// <summary>
        /// A generate description of the park’s climate (e.g. “Desert”)
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// The year the park joined the National Park System 
        /// </summary>
        public int YearFounded { get; set; }

        /// <summary>
        /// The average number of visitors to the park on a annual basis
        /// </summary>
        public int AnnualVisitorCount { get; set; }

        /// <summary>
        /// A famous quote related to the park
        /// </summary>
        public string Quote { get; set; }

        /// <summary>
        /// The person to whom the quote is attributed
        /// </summary>
        public string QuoteSource { get; set; }

        /// <summary>
        /// A description of the park 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The cost to enter the park in dollars. Starts with a dollar sign. (e.g. $10) 
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// The number of different animal species that can be found within park boundaries
        /// </summary>
        public int AnimalSpecies { get; set; }

        // name of park image???---they are named by park code in local folder. 
    }
}
