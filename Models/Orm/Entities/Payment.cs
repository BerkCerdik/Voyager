using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Voyager.Models.Orm.Entities
{
    public class Payment : BaseEntity
    {
        public double Price { get; set; }
        public List<Trip> Trips { get; set; }

    }
}