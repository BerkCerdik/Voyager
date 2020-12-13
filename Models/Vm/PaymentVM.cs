using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Entities;

namespace Voyager.Models.Vm
{
    public class PaymentVM
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
