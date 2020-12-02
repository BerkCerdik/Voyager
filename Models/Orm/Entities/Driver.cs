using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Orm.Entities
{
    public class Driver : User
    {
        public DateTime Experience { get; set; }

        public string Plate { get; set; }

        public Trip Trip { get; set; }

        public Payment Payment { get; set; }

    }
}