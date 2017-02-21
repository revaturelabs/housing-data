using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Housing.Data.Domain.Helper;

namespace Housing.Data.Domain.CRUD
{
    public partial class AccessHelper
    {

        private static readonly HousingDB_DevEntities db = new HousingDB_DevEntities();
        public static AccessMapper mapper=new AccessMapper(db);
        private static IEF ef;
        /// <summary>
        /// ctor for AccessHelper creates reference for db and mapper
        /// </summary>
        static AccessHelper()
        {           
                       
        }
        public AccessHelper()
        {
            ef = new EF(db); 
        }

        public AccessHelper(IEF ief)
        {            
            ef = ief;
        }


        #region insertions

        /// <summary>
        /// insert gender into the DB
        /// </summary>
        /// <param name="gender"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertGender(GenderDao gender)
        {
            try
            {
                if (gender != null)
                {
                    //map to EF object 
                    var itm = mapper.MapToEntity(gender);
                    //set Active bit to true 
                    itm.Active = true;
                    logger.Debug("testing insert of gender in Data Access");
                    logger.Log(LogLevel.Debug, "update log from gender insert itm{0}", itm.Name);
                    //insert into db
                    return ef.InsertGender(itm);                   
                }
                else
                {
                    logger.Error("Error occured in insert gender crud");
                    logger.Log(LogLevel.Error, "Insertion of gender failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Insert gender crud");
                logger.Log(LogLevel.Error, "Inserting of gender failed, exception occurred");
                throw;
            }
        }

        /// <summary>
        /// insert batch into the DB
        /// </summary>
        /// <param name="batch"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertBatch(BatchDao batch)
        {
            try
            {
                if (batch != null)
                {
                    //map to EF object 
                    var itm = mapper.MapToEntity(batch);
                    //set Active bit to true 
                    itm.Active = true;
                    logger.Debug("testing insert of batch in Data Access");
                    logger.Log(LogLevel.Debug, "update log from batch insert batch{0}", batch.Name);
                    //insert into db
                    return ef.InsertBatch(itm);                 
                }
                else
                {
                    logger.Error("Error occured in insert batch crud");
                    logger.Log(LogLevel.Error, "Insertion of batch failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Insert batch crud");
                logger.Log(LogLevel.Error, "Insert of batch failed, exception occurred");
                throw;
            }
        }

        /// <summary>
        /// insert Associate into the DB
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertAssociate(AssociateDao assoc)
        {
            try
            {
                if (assoc != null)
                {
                    //map to EF object 
                    var itm = mapper.MapToEntity(assoc);
                    //set Active bit to true 
                    itm.Active = true;
                    logger.Debug("testing insert of associate in Data Access");
                    logger.Log(LogLevel.Debug, "update log from associate insert itm{0}", itm.Email);
                    //insert into db
                    return ef.InsertAssociate(itm);                    
                }
                else
                {
                    logger.Error("Error occured in insert associate crud");
                    logger.Log(LogLevel.Error, "Insert of associate failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Insert associate crud");
                logger.Log(LogLevel.Error, "Insert of associate failed, exception occurred");
                throw;
            }
        }

        /// <summary>
        /// insert HousingComplex into the DB
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingComplex(HousingComplexDao hc)
        {
            try
            {
                if (hc != null)
                {
                    //map to EF object 
                    var itm = mapper.MapToEntity(hc);
                    //set Active bit to true 
                    itm.Active = true;
                    logger.Debug("testing insert of housing complex in Data Access");
                    logger.Log(LogLevel.Debug, "update log from housing complex insert itm{0}", itm.Name);
                    //insert into db
                    return ef.InsertHousingComplex(itm);
                }
                else
                {
                    logger.Error("Error occured in insert housing complex crud");
                    logger.Log(LogLevel.Error, "Insert of complex failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in insert housing complex crud");
                logger.Log(LogLevel.Error, "Insert of housing complex failed, exception occurred");
                throw;
            }
        }

        /// <summary>
        /// insert HousingUnit into the DB
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingUnit(HousingUnitDao hu)
        {
            try
            {
                if (hu != null)
                {
                    //map to EF object 
                    var itm = mapper.MapToEntity(hu);
                    //set Active bit to true 
                    itm.Active = true;
                    logger.Debug("testing insert of housing unit in Data Access");
                    logger.Log(LogLevel.Debug, "update log from housing unit insert itm{0}", itm.HousingUnitName);
                    //insert into db
                    return ef.InsertHousingUnit(itm);
                }
                else
                {
                    logger.Error("Error occured in insert housing unit crud");
                    logger.Log(LogLevel.Error, "Insert of housing unit failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in insert housing unit crud");
                logger.Log(LogLevel.Error, "Insert of housing unit failed, exception occurred");
                throw;
            }
        }

        /// <summary>
        /// insert HousingData entry into the DB
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingData(HousingDataDao hd)
        {
            try
            {
                if (hd != null)
                {
                    //map to EF object 
                    var itm = mapper.MapToEntity(hd);
                    //set Active bit to true 
                    itm.Active = true;
                    //get associate object from db
                    var assoc = ef.GetAssociates().FirstOrDefault(m => m.Email.Equals(itm.Associate.Email));
                    //get housingUnit object from db
                    var activeAssocHouse = ef.GetHousingUnits().Where(m => m.Active == true).ToList();
                    var assocHouse = activeAssocHouse.Where(m => m.HousingComplex.Name.Equals(itm.HousingUnit.HousingComplex.Name)).FirstOrDefault();
                    //check gender match between Associate, Unit
                    var genderMatch = assoc.Gender.Equals(assocHouse.Gender);
                    //check that Unit occupancy is not exceeded
                    //get number of assoc assigned to unit
                    var dataReturnedByStoredProcedure = ef.GetDataByUnit(assocHouse.HousingUnitId).Where(m => m.Active == true);
                    //continue insert if gender and capacity are OK
                    if (genderMatch && (dataReturnedByStoredProcedure.Count() < assocHouse.MaxCapacity))
                    {
                        logger.Debug("testing insert housing data by unit list in Data Access, itm{0} ", itm.HousingUnit.HousingUnitName);
                        logger.Log(LogLevel.Debug, "update log from housing data by unit insert");
                        //insert into db
                        return ef.InsertHousingData(itm);
                    }
                    //return false if else
                    else
                        logger.Error("Error occured in insert housing data crud");
                    logger.Log(LogLevel.Error, "Insert of housing data failed, gender did not match", hd.HousingUnitName);
                    return false;
                }
                else
                {
                    logger.Error("Error occured in insert housing data crud");
                    logger.Log(LogLevel.Error, "Insertion of housing data failed, object was null");
                    return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in insert housing data crud");
                logger.Log(LogLevel.Error, "Insert of housing data failed, exception occurred");
                throw;
            }
        }
        #endregion
    }
}
