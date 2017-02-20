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
        IQueryable<HousingData_By_Unit_Result> GetDataByUnit(int housingUnitName);
      
        bool DeleteGender(Gender g);
        bool DeleteBatch(Batch b);
        bool DeleteAssociate(Associate assoc);
        bool DeleteHousingComplex(HousingComplex hc);
        bool DeleteHousingUnit(HousingUnit hu);
        bool DeleteHousingData(HousingData hd);

        bool InsertGender(Gender gender);
        bool InsertBatch(Batch batch);
        bool InsertAssociate(Associate assoc);
        bool InsertHousingComplex(HousingComplex hc);
        bool InsertHousingUnit(HousingUnit hu);
        bool InsertHousingData(HousingData hd);

        bool UpdateGender(Gender old, Gender g);
        bool UpdateBatch(Batch old, Batch b);
        bool UpdateAssociate(Associate old, Associate assoc);
        bool UpdateHousingComplex(HousingComplex old, HousingComplex hc);
        bool UpdateHousingUnit(HousingUnit old, HousingUnit hu);
        bool UpdateHousingData(HousingData old, HousingData hd);


    }
}
