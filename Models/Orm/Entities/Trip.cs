using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Orm.Entities
{
    public class Trip : BaseEntity
    {
        
        public int PassengerID { get; set; }
        public int DriverID { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public double Price { get; set; }

        public Comment Comment { get; set; }

        [ForeignKey("PassengerID")]
        public Passenger Passenger{ get; set; }

        [ForeignKey("DriverID")]
        public Driver Driver{ get; set; }

        public Payment Payment { get; set; }



    }
}