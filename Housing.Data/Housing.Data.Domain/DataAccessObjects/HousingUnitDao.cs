using Housing.Data.Domain.CustomAnnotations;
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
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string HousingUnitName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 1)]
        public string AptNumber { get; set; }

        [Required]
        [Range(1, 6, ErrorMessage = "The unit must not exceed 6 people and should not be 0.")]
        public int MaxCapacity { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string GenderName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string HousingComplexName { get; set; }

        [DefaultDate]
        public DateTime LeaseEndDate { get; set; }

    }
}
