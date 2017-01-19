using Housing.Data.Domain;
using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain
{
    public class AccessHelper
    {
        private readonly HousingDB_DevEntities db;

        /// <summary>
        /// constructors
        /// </summary>
        public AccessHelper()
        {
            db = new HousingDB_DevEntities();
        }
        public AccessHelper(HousingDB_DevEntities db)
        {
            this.db = db;
        }

        #region data retrieval 
        /// <summary>
        /// return active Associates as DAOs
        /// </summary>
        /// <returns></returns>
        public List<AssociateDao> GetAssociates()
        {
            var associates = db.Associates.ToList();
            //check active
            //map to Dao
            //add to list
            //return list

        }

        /// <summary>
        /// return active Batches as DAOs
        /// </summary>
        /// <returns></returns>
        public List<BatchDao> GetBatches()
        {
            var batches = db.Batches.ToList();
        }

        /// <summary>
        /// return active Genders as DAOs
        /// </summary>
        /// <returns></returns>
        public List<GenderDao> GetGenders()
        {
            var genders = db.Genders.ToList();
        }

        /// <summary>
        /// return active HousingComplexes as DAOs
        /// </summary>
        /// <returns></returns>
        public List<HousingComplexDao> GetHousingComplexes()
        {
            var complexes = db.HousingComplexes.ToList();
        }

        /// <summary>
        /// return active HousingUnits as DAOs
        /// </summary>
        /// <returns></returns>
        public List<HousingUnitDao> GetHousingUnits()
        {
            var units = db.HousingUnits.ToList();
        }

        /// <summary>
        /// return active HousingData as DAOs
        /// </summary>
        /// <returns></returns>
        public List<HousingDataDao> GetHousingData()
        {
            var data = db.HousingDatas.ToList();
        }

        /// <summary>
        /// all active HousingUnits associated with given HousingComplexId
        /// </summary>
        /// <returns>List(HousingUnitDao)</returns>
        public List<HousingUnitDao> GetUnitsByComplex(int id)
        {
            
        }

        /// <summary>
        /// all active HousingData associated with given HousingUnitId
        /// </summary>
        /// <returns>List(HousingDataDao)</returns>
        public List<HousingDataDao> GetDataByUnit(int id)
        {

        }

       
        #endregion
        #region insertions

        /// <summary>
        /// Add a new HousingComplex to the database
        /// </summary>
        /// <param name="complex"></param>
        /// <returns>bool, success = true, failure = false</returns>
        public bool InsertHousingComplex(HousingComplexDao complex)
        {
            ///map to entity
            //set active bit to true 
            ActiveBit = true;
            try
            {
                db.Apartment.Add(apt);
                if (db.SaveChanges() == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add a new HousingUnit to the database
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>bool, success = true, failure = false</returns>
        public bool InsertHousingUnit(HousingUnitDao unit)
        {
            ///map to entity
            //set active bit to true 
            ActiveBit = true;
            try
            {
                db.Apartment.Add(apt);
                if (db.SaveChanges() == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Add a new HousingData to the database
        /// </summary>
        /// <param name="data"></param>
        /// <returns>bool, success = true, failure = false</returns>
        public bool InsertHousingData(HousingDataDao data)
        {
            ///map to entity
            ///check gender, occupancy
            //set active bit to true 
            ActiveBit = true;
            try
            {
                db.Apartment.Add(apt);
                if (db.SaveChanges() == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
        #region UpdateGrace

        /// <summary>
        /// Will update the Apartment in the database
        /// </summary>
        /// <param name="apt"></param>
        /// <returns>return true if object found</returns>
        public bool UpdateApartment(Apartment apt)
        {
            try
            {
                var oldapt = db.Apartment.FirstOrDefault(a => a.RoomID == apt.RoomID);
                if (oldapt != null)
                {
                    db.Entry(oldapt).CurrentValues.SetValues(apt);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Will update HousingComplex in database
        /// </summary>
        /// <param name="housecom"></param>
        /// <returns>return true if object found</returns>
        public bool UpdateHousingComplex(HousingComplex housecom)
        {
            try
            {
                var oldhousecom = db.HousingComplex.FirstOrDefault(h => h.HotelID == housecom.HotelID);
                if (oldhousecom != null)
                {
                    db.Entry(oldhousecom).CurrentValues.SetValues(housecom);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Will update HousingData in database
        /// </summary>
        /// <param name="housedata"></param>
        /// <returns>return true if object found</returns>
        public bool UpdateHousingData(HousingData housedata)
        {
            try
            {
                var oldhousedata = db.HousingData.FirstOrDefault(h => h.AssociateID == housedata.AssociateID);
                if (oldhousedata != null)
                {
                    db.Entry(oldhousedata).CurrentValues.SetValues(housedata);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Will update Status in the database
        /// </summary>
        /// <param name="stat"></param>
        /// <returns>return true if object found</returns>
        public bool UpdateStatus(Status stat)
        {
            try
            {
                var oldstat = db.HousingData.FirstOrDefault(s => s.StatusID == stat.StatusID);
                if (oldstat != null)
                {
                    db.Entry(oldstat).CurrentValues.SetValues(stat);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
        #region DeleteGrace
        /// <summary>
        /// Will delet the Apartment by setting Active bit
        /// </summary>
        /// <param name="apt"></param>
        /// <returns>return true if object found</returns>
        public bool DeleteApartment(Apartment apt)
        {
            try
            {
                var oldapt = db.Apartment.FirstOrDefault(a => a.RoomID == apt.RoomID);
                if (oldapt != null)
                {
                    apt = oldapt;
                    apt.ActiveBit = false;
                    db.Entry(oldapt).CurrentValues.SetValues(apt);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Will delete HousingComplex by setting Active bit
        /// </summary>
        /// <param name="housecom"></param>
        /// <returns>return true if object found</returns>
        public bool DeleteHousingComplex(HousingComplex housecom)
        {
            try
            {
                var oldhousecom = db.HousingComplex.FirstOrDefault(h => h.HotelID == housecom.HotelID);
                if (oldhousecom != null)
                {
                    housecom = oldhousecom;
                    housecom.ActiveBit = false;
                    db.Entry(oldhousecom).CurrentValues.SetValues(housecom);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Will delete HousingData by setting StatusID to Red (3)
        /// </summary>
        /// <param name="housedata"></param>
        /// <returns>return true if object found</returns>
        public bool DeleteHousingData(HousingData housedata)
        {
            try
            {
                var oldhousedata = db.HousingData.FirstOrDefault(h => h.AssociateID == housedata.AssociateID);
                if (oldhousedata != null)
                {
                    housedata = oldhousedata;
                    housedata.StatusID = 3;
                    db.Entry(oldhousedata).CurrentValues.SetValues(housedata);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }



        #endregion
    }
}
