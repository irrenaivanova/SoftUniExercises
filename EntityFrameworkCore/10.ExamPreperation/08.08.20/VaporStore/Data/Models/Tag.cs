﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.Data.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameTag> GameTags { get; set;}
    }
}
