using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class BatchDao
    {
        //public int BatchId { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Technology { get; set; }
    }
}
