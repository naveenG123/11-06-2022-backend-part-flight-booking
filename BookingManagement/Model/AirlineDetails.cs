using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Model
{
    public class AirlineDetails
    {
        public int id { get; set; }
        public string AirlineNo { get; set; }
        public string Logo { get; set; }
        public string AirlineName { get; set; }
        public string Address { get; set; }
        public int status { get; set; }
    }
}
