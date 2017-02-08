using Housing.Data.Domain.DataAccessObjects;
using NLog;
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
                    logger.Debug("testing delete of gender in Data Access");
                    logger.Log(LogLevel.Debug, "update log from gender delete g{0}", g.Name);
                    db.Genders.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    logger.Error("Error occured in delete gender crud");
                    logger.Log(LogLevel.Error, "Deleting of gender failed, g{0} ", g.Name);
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete gender crud");
                logger.Log(LogLevel.Error, "Deleting of gender failed, a{0} ");
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
                    logger.Debug("testing delete of batch in Data Access");
                    logger.Log(LogLevel.Debug, "update log from batch delete b{0}", b.Name);
                    db.Batches.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    logger.Error("Error occured in delete batch crud");
                    logger.Log(LogLevel.Error, "Deleting of batch failed, b{0} ", b.Name);
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete batch crud");
                logger.Log(LogLevel.Error, "Deleting of batch failed, a{0} ");
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
                    logger.Debug("testing delete of associate in Data Access");
                    logger.Log(LogLevel.Debug, "update log from associate delete t{0}", t.Email);
                    db.Associates.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    logger.Error("Error occured in delete associate crud");
                    logger.Log(LogLevel.Error, "Deleting of associate failed, assoc{0} ", assoc.Email);
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete associate crud");
                logger.Log(LogLevel.Error, "Deleting of associate failed, a{0} ");
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
                    logger.Debug("testing delete of housing complex in Data Access");
                    logger.Log(LogLevel.Debug, "update log from housing complex delete h{0}", h.Name);
                    db.HousingComplexes.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    logger.Error("Error occured in delete housing complex crud");
                    logger.Log(LogLevel.Error, "Deleting of complex failed, hc{0} ", hc.Name);
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete housing complex crud");
                logger.Log(LogLevel.Error, "Deleting of housing complex failed, hc{0} ");
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
                    logger.Debug("testing delete of housing unit in Data Access");
                    logger.Log(LogLevel.Debug, "update log from housing unit delete u{0}", u.HousingUnitName);
                    db.HousingUnits.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    logger.Error("Error occured in delete housing unit crud");
                    logger.Log(LogLevel.Error, "Deleting of housing unit failed, hu{0} ", hu.HousingUnitName);
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete housing unit crud");
                logger.Log(LogLevel.Error, "Deleting of housing unit failed, a{0} ");
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
                    logger.Debug("testing delete of housing data in Data Access");
                    logger.Log(LogLevel.Debug, "update log from housing data delete d{0}", d.HousingUnit.HousingUnitName);
                    db.HousingDatas.Remove(toDelete);
                    return db.SaveChanges() > 0; 
                }
                else
                {
                    logger.Error("Error occured in delete housing data crud");
                    logger.Log(LogLevel.Error, "Deleting of housing data failed, g{0} ", hd.HousingUnitName);
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete housing data crud");
                logger.Log(LogLevel.Error, "Deleting of housing data failed, a{0} ");
                throw;
            }
        }
    #endregion
  }
}
