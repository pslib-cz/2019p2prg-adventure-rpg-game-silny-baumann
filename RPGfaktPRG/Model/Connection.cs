using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGfaktPRG.Model
{
    public class Connection
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="from">Id of location we want to leave.</param>
        /// <param name="to">Id of location we want to enter.</param>
        /// <param name="description">Room description.</param>
        /// <param name="condition">Additional condition required for succesfull movement.</param>
        public Connection(Room from, Room to, string description)
        {
            From = from;
            To = to;
            Description = description;
        }


        public Room From { get; set; }
        public Room To { get; set; }
        public string Description { get; set; }
    }
}
