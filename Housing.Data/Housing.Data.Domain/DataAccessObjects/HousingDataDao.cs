using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.DataAccessObjects
{
    public class HousingDataDao
    {
        CRUD.AccessHelper ah = new CRUD.AccessHelper();
        public HousingDataDao() { }

        //Ctor for non new dao
        public HousingDataDao(string assocEmail, string unitName, DateTime moveIn, DateTime moveOut, string altId)
        {                       
            AssociateEmail = assocEmail;
            HousingUnitName = unitName;
            MoveInDate = moveIn;
            MoveOutDate = moveOut;
            HousingDataAltId = altId;        
        }

        //ctor for new dao
        public HousingDataDao(string assocEmail, string unitName, DateTime moveIn, DateTime moveOut)
        {           
            AssociateEmail = assocEmail;
            HousingUnitName = unitName;
            MoveInDate = moveIn;
            MoveOutDate = moveOut;
            HousingDataAltId = CRUD.AccessHelper.GetRandomHexNumber();  //gets random hex number of length 8
            while(ah.GetHousingData().Where(m => m.HousingDataAltId.Equals(HousingDataAltId)).Count() > 0)
            {
                HousingDataAltId = CRUD.AccessHelper.GetRandomHexNumber();  //repeat random number generation until unique

            }
        }

        // public int HousingDataId { get; set; }
        public string AssociateEmail { get; set; }
        public string HousingUnitName { get; set; }
        public System.DateTime MoveInDate { get; set; }
        public System.DateTime MoveOutDate { get; set; }
        public string HousingDataAltId { get; set; }
    }
}
