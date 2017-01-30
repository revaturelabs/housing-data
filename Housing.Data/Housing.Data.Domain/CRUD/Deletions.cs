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
        #region deletions 

        /// <summary>
        /// delete Associate
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if deletion successful</returns>
        public bool DeleteAssociate(AssociateDao assoc)
        {
            Associate t = mapper.MapToEntity(assoc);
            db.Associates.Remove(t);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// delete HousingComplex 
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>true if deletion successful</returns>
        public bool DeleteHousingComplex(HousingComplexDao hc)
        {
            HousingComplex h = mapper.MapToEntity(hc);
            db.HousingComplexes.Remove(h);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// delete HousingUnit
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>true if deletion successful</returns>
        public bool DeleteHousingUnit(HousingUnitDao hu)
        {
            HousingUnit u = mapper.MapToEntity(hu);
            db.HousingUnits.Remove(u);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Delete batch
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool DeleteBatch(BatchDao b)
        {
            Batch batch = mapper.MapToEntity(b);
            db.Batches.Remove(batch);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Delete Gender
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public bool DeleteGender(GenderDao g)
        {
            Gender gender = mapper.MapToEntity(g);
            var toDelete = db.Genders.Where(m => m.GenderId == gender.GenderId).FirstOrDefault();
            db.Genders.Remove(toDelete);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// delete HousingData entry
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>true if deletion successful</returns>
        public bool DeleteHousingData(HousingDataDao hd)
        {
            HousingData d = mapper.MapToEntity(hd);
            db.HousingDatas.Remove(d);
            return db.SaveChanges() > 0;
        }
    #endregion
  }
}
