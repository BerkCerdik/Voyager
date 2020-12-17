using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Orm.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string IconName { get; set; }

    }
}
