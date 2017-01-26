using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class HousingDataDao
    {
        public HousingDataDao() { }
        public HousingDataDao(AssociateDao assoc, HousingUnitDao unit, DateTime moveIn, DateTime moveOut)
        {
            Associate = assoc;
            HousingUnit = unit;
            MoveInDate = moveIn;
            MoveOutDate = moveOut;
        }
        public AssociateDao Associate { get; set; }
        public HousingUnitDao HousingUnit { get; set; }
        public System.DateTime MoveInDate { get; set; }
        public System.DateTime MoveOutDate { get; set; }
    }
}
