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
        public HousingUnitDao( string apt, int max, string gender, HousingComplexDao complex)
        {
            AptNumber = apt;
            MaxCapacity = max;
            Gender = gender;
            HousingComplex = complex;
        }
        
        public string AptNumber { get; set; }
        public int MaxCapacity { get; set; }
        public string Gender { get; set; }
        public HousingComplexDao HousingComplex { get; set; }

    }
}
