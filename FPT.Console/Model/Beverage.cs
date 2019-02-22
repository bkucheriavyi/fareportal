﻿using System.Collections.Generic;

namespace FPT.ConsoleApp
{
    public class Beverage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AdditiveGroup Group {get; set;}

        public List<Additive> Additives { get; set; }
    }
}