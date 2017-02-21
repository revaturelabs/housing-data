using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string HousingUnitName { get; set; }

        [Required]
        public string AptNumber { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        [Required]
        public string GenderName { get; set; }

        [Required]
        public string HousingComplexName { get; set; }

        public DateTime LeaseEndDate { get; set; }

    }
}
