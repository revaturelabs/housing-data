using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class BatchDao
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Instructor { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public string Technology { get; set; }
    }
}
