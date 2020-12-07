using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Vm
{
    public class TripVM
    {
        public int ID { get; set; }
        public int PassengerID { get; set; }
        public int DriverID { get; set; }
        public double Price{ get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
    }
}
