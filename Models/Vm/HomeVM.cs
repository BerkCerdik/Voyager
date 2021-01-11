using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Entities;

namespace Voyager.Models.Vm
{
    public class HomeVM
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public List<Driver> Drivers { get; set; }

        public int DriverID { get; set; }

    }
}
