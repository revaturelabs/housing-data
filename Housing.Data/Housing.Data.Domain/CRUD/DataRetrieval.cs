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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region data retrieval 

        /// <summary>
        /// gets active AssociateDao's
        /// </summary>
        /// <returns>List<AssociateDao></returns>
        public List<AssociateDao> GetAssociates()
        {
            try
            {
                logger.Debug("testing get associate in Data Access");
                logger.Log(LogLevel.Debug, "update log from associate get");
                var associates = db.Associates.ToList();
                var result = new List<AssociateDao>();
                foreach (var item in associates)
                {
                    if (item.Active)
                    {
                        logger.Debug("testing get associate list in Data Access, item{0} ", item.Email);
                        logger.Log(LogLevel.Debug, "update log from associate get");
                        result.Add(mapper.MapToDao(item));
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in get Associate crud");
                logger.Log(LogLevel.Error, "Retrieval of Associate failed, a{0} ");
                throw;
            }

        }

        /// <summary>
        /// gets active BatchDAOs
        /// </summary>
        /// <returns>List<BatchDao></returns>
        public List<BatchDao> GetBatches()
        {
            try
            {
                var batches = db.Batches.ToList();
                var result = new List<BatchDao>();
                foreach (var item in batches)
                {
                    if (item.Active)
                    {
                        logger.Debug("testing get Batch list in Data Access, item{0} ", item.Name);
                        logger.Log(LogLevel.Debug, "update log from batches get");
                        result.Add(mapper.MapToDao(item));
                    }
                }
                logger.Info("Batches retrieved");
                logger.Log(LogLevel.Info, "Retrieval of Batches suceeded, a{0} ");
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in get Batches crud");
                logger.Log(LogLevel.Error, "Retrieval of Batches failed, a{0} ");
                throw;
            }
        }

        /// <summary>
        /// gets active GenderDAOs
        /// </summary>
        /// <returns>List<GenderDao></returns>
        public List<GenderDao> GetGenders()
        {
            try
            {
                var genders = db.Genders.ToList();
                var result = new List<GenderDao>();
                foreach (var item in genders)
                {
                    if (item.Active)
                    {
                        logger.Debug("testing get gender list in Data Access, item{0} ", item.Name);
                        logger.Log(LogLevel.Debug, "update log from genders get");
                        result.Add(mapper.MapToDao(item));
                    }
                }
                logger.Info("Genders get suceeded");
                logger.Log(LogLevel.Info, "Retrieval of Genders suceeded, a{0} ");
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in get Batches crud");
                logger.Log(LogLevel.Error, "Retrieval of Batches failed, a{0} ");
                throw;
            }
        }

        /// <summary>
        /// gets active HousingComplexDAOs
        /// </summary>
        /// <returns>List<HousingComplexDao></returns>
        public List<HousingComplexDao> GetHousingComplexes()
        {
            try
            {
                var complexes = db.HousingComplexes.ToList();
                var result = new List<HousingComplexDao>();
                foreach (var item in complexes)
                {
                    if (item.Active)
                    {
                        logger.Debug("testing get complex list in Data Access, item{0} ", item.Name);
                        logger.Log(LogLevel.Debug, "update log from housingcomplex get");
                        result.Add(mapper.MapToDao(item));
                    }
                }
                logger.Info("Housing complex gotten");
                logger.Log(LogLevel.Info, "Retrieval of housing complex suceeded, a{0} ");
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in get Housing complex crud");
                logger.Log(LogLevel.Error, "Retrieval of housing complex failed, a{0} ");
                throw;
            }
        }

        /// <summary>
        /// gets active HousingUnitDAOs
        /// </summary>
        /// <returns>List<HousingUnitDao></HousingUnit></returns>
        public List<HousingUnitDao> GetHousingUnits()
        {
            try
            {
                var units = db.HousingUnits.ToList();
                var result = new List<HousingUnitDao>();
                foreach (var item in units)
                {
                    if (item.Active)
                    {
                        logger.Debug("testing get housing unit list in Data Access, item{0} ", item.HousingUnitName);
                        logger.Log(LogLevel.Debug, "update log from housing units get");
                        result.Add(mapper.MapToDao(item));
                    }
                }
                logger.Info("Housing units gotten");
                logger.Log(LogLevel.Info, "Retrieval of housing units suceeded, a{0} ");
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in get Housing units crud");
                logger.Log(LogLevel.Error, "Retrieval of housing units failed, a{0} ");
                throw;
            }
        }

        /// <summary>
        /// gets active HousingDataDAOs
        /// </summary>
        /// <returns>List<HousingDataDao></HousingDataDao></returns>
        public List<HousingDataDao> GetHousingData()
        {
            try
            {
                var data = db.HousingDatas.ToList();
                var result = new List<HousingDataDao>();
                foreach (var item in data)
                {
                    if (item.Active)
                    {
                        logger.Debug("testing get housing data list in Data Access, item{0} ", item.HousingDataAltId);
                        logger.Log(LogLevel.Debug, "update log from housing data get");
                        result.Add(mapper.MapToDao(item));
                    }
                }
                logger.Info("housing data list gotten");
                logger.Log(LogLevel.Info, "Retrieval of housing data suceeded");
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in get Housing data crud");
                logger.Log(LogLevel.Error, "Retrieval of housing data failed, a{0} ");
                throw;
            }
        }

        /// <summary>
        /// gets active HousingUnits with given HousingComplexName
        /// </summary>
        /// <returns>List<HousingUnitDao></returns>
        public List<HousingUnitDao> GetUnitsByComplex(string complexName)
        {
            try
            {
                var result = new List<HousingUnitDao>();
                if (complexName != null)
                {                    
                    var activeAssocHouse = db.HousingUnits.Where(m => m.Active == true).ToList();
                    var units = activeAssocHouse.Where(m => m.HousingComplex.Name.Equals(complexName));
                    foreach (var item in units)
                    {
                        if (item.Active)
                        {
                            logger.Debug("testing get housing unit by complex list in Data Access, item{0} ", item.AptNumber, "item{1} ",item.HousingUnitName);
                            logger.Log(LogLevel.Debug, "update log from housing data get");
                            result.Add(new HousingUnitDao(item.AptNumber, item.HousingUnitName, item.MaxCapacity,
                                 mapper.genders.Find(g => g.GenderId == item.GenderId).Name,
                                 mapper.housingUnits.Find(m => m.HousingComplex.Name.Equals(complexName)).HousingComplex.Name));
                        }
                    }                    
                }
                logger.Info("Housing unit by complex list gotten");
                logger.Log(LogLevel.Info, "Retrieval of housing unit by complex list suceeded");
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in get Housing unit by complex list crud");
                logger.Log(LogLevel.Error, "Retrieval of housing unit by complex list failed, a{0} ");
                throw;
            }
        }

        /// <summary>
        /// gets active HousingData with given HousingUnitName
        /// </summary>
        /// <returns>List<HousingDataDao></returns>
        public List<HousingDataDao> GetDataByUnit(string housingUnitName)
        {
            try
            {
                var result = new List<HousingDataDao>();
                if (housingUnitName != null)
                {
                    var data = db.HousingDatas.ToList().Where(x => x.HousingUnit.HousingUnitName.Equals(housingUnitName));
                    foreach (var item in data)
                    {
                        if (item.Active)
                        {
                            logger.Debug("testing get housing data by unit list in Data Access, item{0} ", item.HousingUnit.HousingUnitName);
                            logger.Log(LogLevel.Debug, "update log from housing data by unit get");
                            result.Add(new HousingDataDao(item.Associate.Email, item.HousingUnit.HousingUnitName, item.MoveInDate, item.MoveOutDate, item.HousingDataAltId));
                        }
                    }                    
                }
                logger.Info("Housing data by unit gotten");
                logger.Log(LogLevel.Info, "Retrieval of housing data by unit suceeded");
                return result;
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in get Housing data by unit crud");
                logger.Log(LogLevel.Error, "Retrieval of housing data by unit failed, a{0} ");
                throw;
            }
        }


        //helper function for generating hex id's        
        public static string GetRandomHexNumber()
        {
            int length = 8;
            Random rand = new Random();
            byte[] buf = new byte[length / 2];
            rand.NextBytes(buf);
            string res = String.Concat(buf.Select(x => x.ToString("X2")).ToArray());
            if (length % 2 == 0)
            {
                return res;
            }                
            return res + rand.Next(16).ToString("X");
        }

        #endregion
    }
}
