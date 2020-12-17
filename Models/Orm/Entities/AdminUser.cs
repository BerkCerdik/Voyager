using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Orm.Entities
{
    public class AdminUser : User
    {
        public string Roles { get; set; }

        public DateTime LastLoginDate { get; set; }
    }
}
