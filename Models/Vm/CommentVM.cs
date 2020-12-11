using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Voyager.Models.Orm.Entities;

namespace Voyager.Models.Vm
{
    public class CommentVM
    {
        public int ID { get; set; }
        public string PassengerName { get; set; }
        public string PassengerLastname { get; set; }
        public string DriverName { get; set; }
        public string DriverLastname { get; set; }      
        public int TripID { get; set; }
        public string Content { get; set; }
        public int Point { get; set; }

        [ForeignKey("TripID")]
        public Trip Trip { get; set; }
    }
}
