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

        [ForeignKey("TripID")]
        public Trip Trip { get; set; }


    }
}
