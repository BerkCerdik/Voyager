﻿using System;

namespace Voyager.Models.Orm.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}