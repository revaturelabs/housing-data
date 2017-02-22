using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Housing.Data.Domain.CRUD
{
    public partial class AccessHelper
    {

        #region updates

        /// <summary>
        /// Update Gender entry
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public bool UpdateGender(string oldId, GenderDao g)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(oldId) && g != null)
                {
                    Gender newGender = mapper.MapToEntity(g);
                    Gender old = ef.GetGenders().FirstOrDefault(a => a.Name.Equals(oldId));
                    newGender.GenderId = old.GenderId;
                    logger.Debug("testing update gender list in Data Access, item{0} ", newGender.Name);
                    logger.Log(LogLevel.Debug, "update log from genders update");
                    return ef.UpdateGender(old, newGender);                  
                    
                }
                logger.Error("Error occured in update gender crud");
                logger.Log(LogLevel.Error, "Update of gender failed, object was null");
                return false;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Update gender crud");
                logger.Log(LogLevel.Error, "Update of gender failed, exception occurred");
                return false;
            }
        }

        /// <summary>
        /// update batch entry
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool UpdateBatch(string oldBatch, BatchDao b)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(oldBatch) && b != null)
                {
                    Batch batch = mapper.MapToEntity(b);
                    Batch old = ef.GetBatches().FirstOrDefault(a => a.Name.Equals(oldBatch));
                    batch.BatchId = old.BatchId;
                    logger.Debug("testing update Batch list in Data Access, batch{0} ", batch.Name);
                    logger.Log(LogLevel.Debug, "update log from batches update");
                    return ef.UpdateBatch(old, batch);                   
                }
                logger.Error("Error occured in insert batch crud");
                logger.Log(LogLevel.Error, "Insertion of batch failed, object was null");
                return false;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Insert batch crud");
                logger.Log(LogLevel.Error, "Insert of batch failed, exception occurred");
                return false;
            }
        }
        /// <summary>
        /// update Associate
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if update successful</returns>
        public bool UpdateAssociate(string old, AssociateDao assoc)
        {
            try
            {
                Associate asc;
                Associate oldAssoc;
                if (!string.IsNullOrWhiteSpace(old) && assoc != null)
                {
                    asc = mapper.MapToEntity(assoc);
                    oldAssoc = ef.GetAssociates().FirstOrDefault(a => a.Email.Equals(old));
                    asc.AssociateId = oldAssoc.AssociateId;
                    logger.Debug("testing update associate list in Data Access, asc{0} ", asc.Email);
                    logger.Log(LogLevel.Debug, "update log from associate update");
                    return ef.UpdateAssociate(oldAssoc, asc);                    
                }
                logger.Error("Error occured in update associate crud");
                logger.Log(LogLevel.Error, "Update of associate failed, object was null");
                return false;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Update associate crud");
                logger.Log(LogLevel.Error, "Update of associate failed, exception occurred");
                return false;
            }
        }

        /// <summary>
        /// update HousingComplex 
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>true if update successful</returns>
        public bool UpdateHousingComplex(string oldComplex, HousingComplexDao hc)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(oldComplex) && hc != null)
                {
                    HousingComplex plex = mapper.MapToEntity(hc);
                    HousingComplex old = ef.GetHousingComplexes().FirstOrDefault(a => a.Name.Equals(oldComplex));
                    plex.HousingComplexId = old.HousingComplexId;
                    logger.Debug("testing update Housing Complex list in Data Access, plex{0} ", plex.Name);
                    logger.Log(LogLevel.Debug, "update log from housing complex update");
                    return ef.UpdateHousingComplex(old, plex);                    
                }
                logger.Error("Error occured in update housing complex crud");
                logger.Log(LogLevel.Error, "Update of complex failed, object was null");
                return false;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in update housing complex crud");
                logger.Log(LogLevel.Error, "Update of housing complex failed, exception occurred");
                return false;
            }
        }

        /// <summary>
        /// update HousingUnit
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>true if update successful</returns>
        public bool UpdateHousingUnit(string oldUnit, HousingUnitDao hu)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(oldUnit) && hu != null)
                {
                    HousingUnit unit = mapper.MapToEntity(hu);
                    HousingUnit old = ef.GetHousingUnits().FirstOrDefault(a => a.HousingUnitName.Equals(oldUnit));
                    unit.HousingUnitId = old.HousingUnitId;
                    logger.Debug("testing update housing unit list in Data Access, unit{0} ", unit.HousingUnitName);
                    logger.Log(LogLevel.Debug, "update log from housing unit update");
                    return ef.UpdateHousingUnit(old, unit);                    
                }
                logger.Error("Error occured in update housing unit crud");
                logger.Log(LogLevel.Error, "Update of housing unit failed, object was null");
                return false;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in update housing unit crud");
                logger.Log(LogLevel.Error, "Update of housing unit failed, exception occurred");
                return false;
            }
        }

        /// <summary>
        /// update HousingData entry
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>true if update successful</returns>
        public bool UpdateHousingData(string oldData, HousingDataDao hd)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(oldData) && hd != null)
                {
                    HousingData hde = mapper.MapToEntity(hd);
                    HousingData old = ef.GetHousingData().FirstOrDefault(a => a.HousingDataAltId.Equals(oldData));
                    hde.HousingDataId = old.HousingDataId;
                    logger.Debug("testing update housing data list in Data Access, hde{0} ", hde.HousingUnit.HousingUnitName);
                    logger.Log(LogLevel.Debug, "update log from housing data update");
                    return ef.UpdateHousingData(old,hde);                   
                }
                logger.Error("Error occured in update housing data crud");
                logger.Log(LogLevel.Error, "Update of housing data failed,object was null");
                return false;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in update housing data crud");
                logger.Log(LogLevel.Error, "Update of housing data failed, exception occurred");
                return false;
            }
        }
        #endregion
    }
}
