using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Vm
{
    public class TripVM
    {
        public int ID { get; set; }
        public string PassengerName { get; set; }
        public string PassengerLastname { get; set; }
        public string DriverName { get; set; }
        public string DriverLastname { get; set; }
        public double Price{ get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
    }
}
