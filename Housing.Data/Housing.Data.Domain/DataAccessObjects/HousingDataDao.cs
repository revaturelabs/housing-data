using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class HousingDataDao
    {
        public int HousingDataId { get; set; }
        public int AssociateId { get; set; }
        public int HousingUnitId { get; set; }
        public System.DateTime MoveInDate { get; set; }
        public System.DateTime MoveOutDate { get; set; }
    }
}
