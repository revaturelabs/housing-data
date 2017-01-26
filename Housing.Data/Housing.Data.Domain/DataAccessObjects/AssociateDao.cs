using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class AssociateDao
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Batch { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public bool HasCar { get; set; }
        public bool HasKeys { get; set; }
    }
}
