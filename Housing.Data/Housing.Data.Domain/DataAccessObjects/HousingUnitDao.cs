﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class HousingUnitDao
    {
        public int HousingUnitId { get; set; }
        public string AptNumber { get; set; }
        public int MaxCapacity { get; set; }
        public String Gender { get; set; }
        public int HousingComplexId { get; set; }
  
    }
}
