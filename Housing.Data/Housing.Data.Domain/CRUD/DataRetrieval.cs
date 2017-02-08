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
        #region data retrieval 

        /// <summary>
        /// gets active AssociateDao's
        /// </summary>
        /// <returns>List<AssociateDao></returns>
        public List<AssociateDao> GetAssociates()
        {
            try
            {
                var associates = db.Associates.ToList();
                var result = new List<AssociateDao>();
                foreach (var item in associates)
                {
                    if (item.Active)
                    {
                        result.Add(mapper.MapToDao(item));
                    }
                }
                return result;
            }
            catch (Exception e)
            {

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
                        result.Add(mapper.MapToDao(item));
                    }
                }
                return result;
            }
            catch (Exception e)
            {

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
                        result.Add(mapper.MapToDao(item));
                    }
                }
                return result;
            }
            catch (Exception e)
            {

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
                        result.Add(mapper.MapToDao(item));
                    }
                }
                return result;
            }
            catch (Exception e)
            {

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
                        result.Add(mapper.MapToDao(item));
                    }
                }
                return result;
            }
            catch (Exception e)
            {

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
                        result.Add(mapper.MapToDao(item));
                    }
                }
                return result;
            }
            catch (Exception e)
            {

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
                            result.Add(new HousingUnitDao(item.AptNumber, item.HousingUnitName, item.MaxCapacity,
                                 mapper.genders.Find(g => g.GenderId == item.GenderId).Name,
                                 mapper.housingUnits.Find(m => m.HousingComplex.Name.Equals(complexName)).HousingComplex.Name));
                        }
                    }                    
                }
                return result;
            }
            catch (Exception e)
            {

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
                            result.Add(new HousingDataDao(item.Associate.Email, item.HousingUnit.HousingUnitName, item.MoveInDate, item.MoveOutDate, item.HousingDataAltId));
                        }
                    }                    
                }
                return result;
            }
            catch (Exception e)
            {

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
