using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            while (ah.GetHousingData().Where(m => m.HousingDataAltId.Equals(HousingDataAltId)).Count() > 0)
            {
                HousingDataAltId = CRUD.AccessHelper.GetRandomHexNumber();  //repeat random number generation until unique

            }
        }

        [Required]
        public string AssociateEmail { get; set; }

        [Required]
        public string HousingUnitName { get; set; }

        public DateTime MoveInDate { get; set; }

        public DateTime MoveOutDate { get; set; }

        public string HousingDataAltId { get; set; }
    }
}
