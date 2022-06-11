using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Model
{
    public class InventoryDetails
    {
        [Key]
        public int id { get; set; }
        public string FlightNo { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int BusinessClassSeat { get; set; }
        public int NonBusinessClassSeat { get; set; }
        public double Price { get; set; }
        public int NoOfRows { get; set; }
        public int Meal { get; set; }

    }

}

