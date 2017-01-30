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
        /// return active Associates as DAOs
        /// </summary>
        /// <returns></returns>
        public List<AssociateDao> GetAssociates()
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

        /// <summary>
        /// return active Batches as DAOs
        /// </summary>
        /// <returns></returns>
        public List<BatchDao> GetBatches()
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

        /// <summary>
        /// return active Genders as DAOs
        /// </summary>
        /// <returns></returns>
        public List<GenderDao> GetGenders()
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

        /// <summary>
        /// return active HousingComplexes as DAOs
        /// </summary>
        /// <returns></returns>
        public List<HousingComplexDao> GetHousingComplexes()
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

        /// <summary>
        /// return active HousingUnits as DAOs
        /// </summary>
        /// <returns></returns>
        public List<HousingUnitDao> GetHousingUnits()
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

        /// <summary>
        /// return active HousingData as DAOs
        /// </summary>
        /// <returns></returns>
        public List<HousingDataDao> GetHousingData()
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

        /// <summary>
        /// all active HousingUnits associated with given HousingComplexId
        /// </summary>
        /// <returns>List(HousingUnitDao)</returns>
        public List<HousingUnitDao> GetUnitsByComplex(int id)
        {
            var result = new List<HousingUnitDao>();
            var units = db.HousingUnits.ToList().Where(b => b.HousingUnitId == id);
            foreach (var item in units)
            {
                if (item.Active)
                {
                    result.Add(new HousingUnitDao(item.AptNumber, item.HousingUnitName, item.MaxCapacity,
                         mapper.genders.Find(g => g.GenderId == item.GenderId).Name, item.HousingComplexId));
                }
            }
            return result;
        }

        /// <summary>
        /// all active HousingData associated with given HousingUnitId
        /// </summary>
        /// <returns>List(HousingDataDao)</returns>
        public List<HousingDataDao> GetDataByUnit(int id)
        {
            var result = new List<HousingDataDao>();
            var data = db.HousingDatas.ToList().Where(x => x.HousingUnitId == id );
            foreach (var item in data)
            {
                if (item.Active)
                {
                    result.Add(new HousingDataDao(item.Associate.Email, item.HousingUnit.HousingUnitName, item.MoveInDate, item.MoveOutDate, item.HousingDataAltId));
                }
            }
            return result;
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
                return res;
            return res + rand.Next(16).ToString("X");
        }

        #endregion
    }
}
