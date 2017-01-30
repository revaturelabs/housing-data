﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class HousingUnitDao
    {
        public HousingUnitDao() {
        }
        public HousingUnitDao( string name, string apt, int max, string gender, int complex)
        {
         //   HousingUnitId = id;
            HousingUnitName = name;
            AptNumber = apt;
            MaxCapacity = max;
            Gender = gender;
            HousingComplexId = complex;
        }
       // public int HousingUnitId { get; set; }
        public string HousingUnitName { get; set; }
        public string AptNumber { get; set; }
        public int MaxCapacity { get; set; }
        public string Gender { get; set; }
        public int HousingComplexId { get; set; }
  
    }
}
