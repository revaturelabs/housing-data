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
        /// Deletes a gender
        /// </summary>
        /// <param name="g"></param>
        /// <returns>true if successful</returns>
        public bool DeleteGender(GenderDao g)
        {
            try
            {
                if (g != null)
                {
                    Gender gender = mapper.MapToEntity(g);
                    var toDelete = db.Genders.Where(m => m.GenderId == gender.GenderId).FirstOrDefault();
                    db.Genders.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Delete a batch
        /// </summary>
        /// <param name="b"></param>
        /// <returns>true if successful</returns>
        public bool DeleteBatch(BatchDao b)
        {
            try
            {
                if (b != null)
                {
                    Batch batch = mapper.MapToEntity(b);
                    var toDelete = db.Batches.Where(m => m.BatchId == batch.BatchId).FirstOrDefault();
                    db.Batches.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        
        /// <summary>
        /// delete an Associate
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if deletion successful</returns>
        public bool DeleteAssociate(AssociateDao assoc)
        {
            try
            {
                if (assoc != null)
                {
                    Associate t = mapper.MapToEntity(assoc);
                    var toDelete = db.Associates.Where(m => m.AssociateId == t.AssociateId).FirstOrDefault();
                    db.Associates.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// delete a HousingComplex 
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>true if deletion successful</returns>
        public bool DeleteHousingComplex(HousingComplexDao hc)
        {
            try
            {
                if (hc != null)
                {
                    HousingComplex h = mapper.MapToEntity(hc);
                    var toDelete = db.HousingComplexes.Where(m => m.HousingComplexId == h.HousingComplexId).FirstOrDefault();
                    db.HousingComplexes.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// delete a HousingUnit
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>true if deletion successful</returns>
        public bool DeleteHousingUnit(HousingUnitDao hu)
        {
            try
            {
                if (hu != null)
                {
                    HousingUnit u = mapper.MapToEntity(hu);
                    var toDelete = db.HousingUnits.Where(m => m.HousingUnitId == u.HousingUnitId).FirstOrDefault();
                    db.HousingUnits.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        
        /// <summary>
        /// delete a HousingData entry
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>true if deletion successful</returns>
        public bool DeleteHousingData(HousingDataDao hd)
        {
            try
            {
                if (hd != null)
                {
                    HousingData d = mapper.MapToEntity(hd);
                    var toDelete = db.HousingDatas.Where(m => m.HousingDataId == d.HousingDataId).FirstOrDefault();
                    toDelete.AssociateId = null;
                    toDelete.HousingUnitId = null;
                    db.HousingDatas.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    #endregion
  }
}
