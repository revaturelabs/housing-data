﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class HousingDataDao
    {
        public HousingDataDao() { }
        public HousingDataDao(int assoc, string name, int unit, DateTime moveIn, DateTime moveOut)
        {
           // HousingDataId = id;
            Name = name;
            AssociateId = assoc;
            HousingUnitId = unit;
            MoveInDate = moveIn;
            MoveOutDate = moveOut;
        }
       // public int HousingDataId { get; set; }
        public string Name { get; set; }
        public int AssociateId { get; set; }
        public int HousingUnitId { get; set; }
        public System.DateTime MoveInDate { get; set; }
        public System.DateTime MoveOutDate { get; set; }
    }
}
