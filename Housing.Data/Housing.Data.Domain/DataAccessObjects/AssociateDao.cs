using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Data.Domain.CustomAnnotations;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class AssociateDao
    {        
        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string GenderName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string BatchName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 7)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinimumAgeValidation(minimumAge:18)]       
        public DateTime DateOfBirth { get; set; }

        public bool HasCar { get; set; }

        public bool HasKeys { get; set; }

        public bool NeedsHousing { get; set; }
    }
}
