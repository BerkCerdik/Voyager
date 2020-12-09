
using System.Collections.Generic;

namespace Voyager.Models.Orm.Entities
{
    public class Passenger : User
    {
        public string PaymentMethod{ get; set; }

        public List<Trip> Trips{ get; set; }

    }
}
