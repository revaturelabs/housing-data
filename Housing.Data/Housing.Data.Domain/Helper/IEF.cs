using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.Helper
{
    public interface IEF
    {
        List<Gender> GetGenders();
        List<Batch> GetBatches();
        List<Associate> GetAssociates();
        List<HousingComplex> GetHousingComplexes();
        List<HousingUnit> GetHousingUnits();
        List<HousingData> GetHousingData();
        //List<HousingUnit> GetUnitsByComplex(string complexName);
        //List<HousingData> GetDataByUnit(string housingUnitName);
        bool DeleteGender(GenderDao g);
        bool DeleteBatch(BatchDao b);
        bool DeleteAssociate(AssociateDao assoc);
        bool DeleteHousingComplex(HousingComplexDao hc);
        bool DeleteHousingUnit(HousingUnitDao hu);
        bool DeleteHousingData(HousingDataDao hd);
        bool InsertGender(GenderDao gender);
        bool InsertBatch(BatchDao batch);
        bool InsertAssociate(AssociateDao assoc);
        bool InsertHousingComplex(HousingComplexDao hc);
        bool InsertHousingUnit(HousingUnitDao hu);
        bool InsertHousingData(HousingDataDao hd);
        bool UpdateGender(string oldId, GenderDao g);
        bool UpdateBatch(string oldBatch, BatchDao b);
        bool UpdateAssociate(string old, AssociateDao assoc);
        bool UpdateHousingComplex(string oldComplex, HousingComplexDao hc);
        bool UpdateHousingUnit(string oldUnit, HousingUnitDao hu);
        bool UpdateHousingData(string oldData, HousingDataDao hd);


    }
}
