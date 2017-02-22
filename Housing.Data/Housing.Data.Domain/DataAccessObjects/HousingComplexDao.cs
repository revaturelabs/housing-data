using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class HousingComplexDao
    {
        [Required]

        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 7)]
        public string PhoneNumber { get; set; }
    }
}
