using System;
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
        public HousingUnitDao( string name, string apt, int max, string genderName, string complexName)
        {
         //   HousingUnitId = id;
            HousingUnitName = name;
            AptNumber = apt;
            MaxCapacity = max;
            GenderName = genderName;
            HousingComplexName = complexName;
        }
       // public int HousingUnitId { get; set; }
        public string HousingUnitName { get; set; }
        public string AptNumber { get; set; }
        public int MaxCapacity { get; set; }
        public string GenderName { get; set; }
        public string HousingComplexName { get; set; }
  
    }
}
