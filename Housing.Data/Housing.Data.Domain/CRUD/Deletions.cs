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
                    var toDelete = ef.GetGenders().FirstOrDefault((m => m.GenderId == gender.GenderId));
                    logger.Debug("testing delete of gender in Data Access");
                    logger.Log(LogLevel.Debug, "update log from gender delete g{0}", g.Name);
                    return ef.DeleteGender(toDelete);
                    
                }
                else
                {
                    logger.Error("Error occured in delete gender crud");
                    logger.Log(LogLevel.Error, "Deleting of gender failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete gender crud");
                logger.Log(LogLevel.Error, "Deleting of gender failed, exception occurred");
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
                    var toDelete = ef.GetBatches().FirstOrDefault(m => m.BatchId == batch.BatchId);
                    logger.Debug("testing delete of batch in Data Access");
                    logger.Log(LogLevel.Debug, "update log from batch delete b{0}", b.Name);
                    return ef.DeleteBatch(toDelete);
                }
                else
                {
                    logger.Error("Error occured in delete batch crud");
                    logger.Log(LogLevel.Error, "Deleting of batch failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete batch crud");
                logger.Log(LogLevel.Error, "Deleting of batch failed, exception occurred");
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
                    var toDelete = ef.GetAssociates().FirstOrDefault(m => m.AssociateId == t.AssociateId);
                    logger.Debug("testing delete of associate in Data Access");
                    logger.Log(LogLevel.Debug, "update log from associate delete t{0}", t.Email);
                    return ef.DeleteAssociate(toDelete);


                   
                }
                else
                {
                    logger.Error("Error occured in delete associate crud");
                    logger.Log(LogLevel.Error, "Deleting of associate failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete associate crud");
                logger.Log(LogLevel.Error, "Deleting of associate failed, exception occurred");
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
                    var toDelete = ef.GetHousingComplexes().FirstOrDefault(m => m.HousingComplexId == h.HousingComplexId);
                    logger.Debug("testing delete of housing complex in Data Access");
                    logger.Log(LogLevel.Debug, "update log from housing complex delete h{0}", h.Name);
                    return ef.DeleteHousingComplex(toDelete);


                    
                }
                else
                {
                    logger.Error("Error occured in delete housing complex crud");
                    logger.Log(LogLevel.Error, "Deleting of complex failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete housing complex crud");
                logger.Log(LogLevel.Error, "Deleting of housing complex failed, exception occurred ");
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
                    var toDelete = ef.GetHousingUnits().FirstOrDefault(m => m.HousingUnitId == u.HousingUnitId);
                    logger.Debug("testing delete of housing unit in Data Access");
                    logger.Log(LogLevel.Debug, "update log from housing unit delete u{0}", u.HousingUnitName);
                    return ef.DeleteHousingUnit(toDelete);


                   
                }
                else
                {
                    logger.Error("Error occured in delete housing unit crud");
                    logger.Log(LogLevel.Error, "Deleting of housing unit failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete housing unit crud");
                logger.Log(LogLevel.Error, "Deleting of housing unit failed, exception occurred");
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
                    var toDelete = ef.GetHousingData().FirstOrDefault(m => m.HousingDataId == d.HousingDataId);
                    toDelete.AssociateId = null;
                    toDelete.HousingUnitId = null;
                    logger.Debug("testing delete of housing data in Data Access");
                    logger.Log(LogLevel.Debug, "update log from housing data delete d{0}", d.HousingUnit.HousingUnitName);
                    return ef.DeleteHousingData(toDelete);


                  
                }
                else
                {
                    logger.Error("Error occured in delete housing data crud");
                    logger.Log(LogLevel.Error, "Deleting of housing data failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in delete housing data crud");
                logger.Log(LogLevel.Error, "Deleting of housing data failed, exception occurred");
                throw;
            }
        }
    #endregion
  }
}
