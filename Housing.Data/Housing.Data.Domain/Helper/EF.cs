using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Housing.Data.Domain.DataAccessObjects;

namespace Housing.Data.Domain.Helper
{
    public class EF : IEF
    {
        /// <summary>
        /// 
        /// </summary>
        private HousingDB_DevEntities db;

        public EF() {
            db = new HousingDB_DevEntities();
        }

        #region Deletes

        public bool DeleteAssociate(Associate assoc)
        {
            db.Associates.Remove(assoc);
            return db.SaveChanges() > 0;
        }

        public bool DeleteBatch(Batch b)
        {
            db.Batches.Remove(b);
            return db.SaveChanges() > 0;
        }

        public bool DeleteGender(Gender g)
        {
            db.Genders.Remove(g);
            return db.SaveChanges() > 0;
        }

        public bool DeleteHousingComplex(HousingComplex hc)
        {
            db.HousingComplexes.Remove(hc);
            return db.SaveChanges() > 0;
        }

        public bool DeleteHousingData(HousingData hd)
        {
            db.HousingDatas.Remove(hd);
            return db.SaveChanges() > 0;
        }

        public bool DeleteHousingUnit(HousingUnit hu)
        {
            db.HousingUnits.Remove(hu);
            return db.SaveChanges() > 0;
        }

        #endregion

        #region Gets

        public List<Associate> GetAssociates()
        {
            return db.Associates.ToList();
        }

        public List<Batch> GetBatches()
        {
            return db.Batches.ToList();
        }

        public IQueryable<HousingData_By_Unit_Result> GetDataByUnit(int housingUnitName)
        {
            return db.HousingData_By_Unit(housingUnitName);
        }

        public List<Gender> GetGenders()
        {
            return db.Genders.ToList();
        }

        public List<HousingComplex> GetHousingComplexes()
        {
            return db.HousingComplexes.ToList();
        }

        public List<HousingData> GetHousingData()
        {
            return db.HousingDatas.ToList();
        }

        public List<HousingUnit> GetHousingUnits()
        {
            return db.HousingUnits.ToList();
        }

        //public List<HousingUnit> GetUnitsByComplex(string complexName)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region Inserts

        public bool InsertAssociate(Associate assoc)
        {
            db.Associates.Add(assoc);
            return db.SaveChanges() > 0;
        }

        public bool InsertBatch(Batch batch)
        {
            db.Batches.Add(batch);
            return db.SaveChanges() > 0;
        }

        public bool InsertGender(Gender gender)
        {
            db.Genders.Add(gender);
            return db.SaveChanges() > 0;
        }

        public bool InsertHousingComplex(HousingComplex hc)
        {
            db.HousingComplexes.Add(hc);
            return db.SaveChanges() > 0;
        }

        public bool InsertHousingData(HousingData hd)
        {
            db.HousingDatas.Add(hd);
            return db.SaveChanges() > 0;
        }

        public bool InsertHousingUnit(HousingUnit hu)
        {
            db.HousingUnits.Add(hu);
            return db.SaveChanges() > 0;
        }

        #endregion

        #region Updates

        public bool UpdateAssociate(Associate old, Associate assoc)
        {
            db.Entry(old).CurrentValues.SetValues(assoc);
            return db.SaveChanges() > 0;
        }

        public bool UpdateBatch(Batch old, Batch b)
        {
            db.Entry(old).CurrentValues.SetValues(b);
            return db.SaveChanges() > 0;            
        }

        public bool UpdateGender(Gender old, Gender g)
        {
            db.Entry(old).CurrentValues.SetValues(g);
            return db.SaveChanges() > 0;
        }

        public bool UpdateHousingComplex(HousingComplex old, HousingComplex hc)
        {
            db.Entry(old).CurrentValues.SetValues(hc);
            return db.SaveChanges() > 0;
        }

        public bool UpdateHousingData(HousingData old, HousingData hd)
        {
            db.Entry(old).CurrentValues.SetValues(hd);          
            return db.SaveChanges() > 0;
        }

        bool IEF.UpdateHousingUnit(HousingUnit old, HousingUnit hu)
        {
            db.Entry(old).CurrentValues.SetValues(hu);            
            return db.SaveChanges() > 0;
        }

        #endregion
    }
}
