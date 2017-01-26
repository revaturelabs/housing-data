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

    #region updates

    /// <summary>
    /// update Associate
    /// </summary>
    /// <param name="assoc"></param>
    /// <returns>true if update successful</returns>
    public bool UpdateAssociate(AssociateDao assoc)
    {
      try
      {
        var a = db.Associates.FirstOrDefault(s => s.AssociateId == assoc.AssociateId);
        if (a != null)
        {
          db.Entry(a).CurrentValues.SetValues(assoc);
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
    /// update HousingComplex 
    /// </summary>
    /// <param name="hc"></param>
    /// <returns>true if update successful</returns>
    public bool UpdateHousingComplex(HousingComplexDao hc)
    {
      try
      {
        var h = db.HousingComplexes.FirstOrDefault(a => a.HousingComplexId == hc.HousingComplexId);
        if (h != null)
        {
          db.Entry(h).CurrentValues.SetValues(hc);
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
    /// update HousingUnit
    /// </summary>
    /// <param name="hu"></param>
    /// <returns>true if update successful</returns>
    public bool UpdateHousingUnit(HousingUnitDao hu)
    {
      try
      {
        HousingUnit unit = new HousingUnit();
        unit = mapper.MapToEntity(hu);
       unit = db.HousingUnits.FirstOrDefault(a => a.HousingUnitId == hu.HousingUnitId);
        if (unit != null)
        {
          db.Entry(unit).CurrentValues.SetValues(hu);
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
    /// update HousingData entry
    /// </summary>
    /// <param name="hd"></param>
    /// <returns>true if update successful</returns>
    public bool UpdateHousingData(HousingDataDao hd)
    {
      try
      {
        var d = db.HousingDatas.FirstOrDefault(a => a.HousingDataId == hd.HousingDataId);
        if (d != null)
        {
          db.Entry(d).CurrentValues.SetValues(hd);
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
