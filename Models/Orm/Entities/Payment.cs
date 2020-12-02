using System.ComponentModel.DataAnnotations.Schema;

namespace Voyager.Models.Orm.Entities
{
    public class Payment : BaseEntity
    {
        public int TripID { get; set; }
        public double Price { get; set; }

        [ForeignKey("TripID")]
        public Trip Trip{ get; set; }


    }
}