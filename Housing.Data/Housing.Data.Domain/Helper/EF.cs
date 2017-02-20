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
        private static readonly HousingDB_DevEntities db;

        bool IEF.DeleteAssociate(AssociateDao assoc)
        {
            throw new NotImplementedException();
        }

        bool IEF.DeleteBatch(BatchDao b)
        {
            throw new NotImplementedException();
        }

        bool IEF.DeleteGender(GenderDao g)
        {
            throw new NotImplementedException();
        }

        bool IEF.DeleteHousingComplex(HousingComplexDao hc)
        {
            throw new NotImplementedException();
        }

        bool IEF.DeleteHousingData(HousingDataDao hd)
        {
            throw new NotImplementedException();
        }

        bool IEF.DeleteHousingUnit(HousingUnitDao hu)
        {
            throw new NotImplementedException();
        }

        public List<Associate> GetAssociates()
        {
            return db.Associates.ToList();
        }

        public List<Batch> GetBatches()
        {
            return db.Batches.ToList();
        }

        //public List<HousingData> GetDataByUnit(string housingUnitName)
        //{
        //    return db.HousingData_By_Unit(housingUnitName);
        //}

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

        bool IEF.InsertAssociate(AssociateDao assoc)
        {
            throw new NotImplementedException();
        }

        bool IEF.InsertBatch(BatchDao batch)
        {
            throw new NotImplementedException();
        }

        bool IEF.InsertGender(GenderDao gender)
        {
            throw new NotImplementedException();
        }

        bool IEF.InsertHousingComplex(HousingComplexDao hc)
        {
            throw new NotImplementedException();
        }

        bool IEF.InsertHousingData(HousingDataDao hd)
        {
            throw new NotImplementedException();
        }

        bool IEF.InsertHousingUnit(HousingUnitDao hu)
        {
            throw new NotImplementedException();
        }

        bool IEF.UpdateAssociate(string old, AssociateDao assoc)
        {
            throw new NotImplementedException();
        }

        bool IEF.UpdateBatch(string oldBatch, BatchDao b)
        {
            throw new NotImplementedException();
        }

        bool IEF.UpdateGender(string oldId, GenderDao g)
        {
            throw new NotImplementedException();
        }

        bool IEF.UpdateHousingComplex(string oldComplex, HousingComplexDao hc)
        {
            throw new NotImplementedException();
        }

        bool IEF.UpdateHousingData(string oldData, HousingDataDao hd)
        {
            throw new NotImplementedException();
        }

        bool IEF.UpdateHousingUnit(string oldUnit, HousingUnitDao hu)
        {
            throw new NotImplementedException();
        }
    }
}
