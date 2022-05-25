﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIWO_Core.Database.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public City? City { get; set; }
    }
}
