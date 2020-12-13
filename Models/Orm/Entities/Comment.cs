using System.ComponentModel.DataAnnotations.Schema;

namespace Voyager.Models.Orm.Entities
{
    public class Comment : BaseEntity
    {
        // PascalCase -> TripId
        // CamelCase -> tripId
        // C# code conventions 
        public int TripID { get; set; }
        public string Content { get; set; }
        public int Point { get; set; }
        public int DriverID { get; set; }
        public int PassengerID { get; set; }

        [ForeignKey("TripID")]
        public Trip Trip { get; set; }
        [ForeignKey("PassengerID")]
        public Passenger Passenger { get; set; }

        [ForeignKey("DriverID")]
        public Driver Driver { get; set; }

        


    }
}
