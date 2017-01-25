using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.CRUD
{
    public partial class AccessHelper
    {

        private readonly HousingDB_DevEntities db;
        public static AccessMapper mapper = new AccessMapper();

        /// <summary>
        /// constructor
        /// </summary>
        public AccessHelper()
        {
            db = new HousingDB_DevEntities();
        }

        #region insertions
        /// <summary>
        /// insert Associate into the DB
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertAssociate(AssociateDao assoc)
        {
            //map to EF object 
            //set Active bit to true 
            return true;
        }

        /// <summary>
        /// insert HousingComplex into the DB
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingComplex(HousingComplexDao hc)
        {
            //map to EF object 
            //set Active bit to true 
            return true;
        }

        /// <summary>
        /// insert HousingUnit into the DB
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingUnit(HousingUnitDao hu)
        {
            //map to EF object 
            //set Active bit to true 
            return true;
        }

        /// <summary>
        /// insert HousingData entry into the DB
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingData(HousingDataDao hd)
        {
            //map to EF object 
            //set Active bit to true 
            //check gender match between Associate, Unit
            //check that Unit occupancy is not exceeded using length of HousingDataByUnit result and current date
            return true;
        }

        #endregion
    }
}
