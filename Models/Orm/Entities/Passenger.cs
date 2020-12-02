
namespace Voyager.Models.Orm.Entities
{
    public class Passenger : User
    {
        public string PaymentMethod{ get; set; }

        public Trip Trip{ get; set; }
        public Payment Payment{ get; set; }

    }
}
