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
                Associate asc = mapper.MapToEntity(assoc);
                asc = db.Associates.FirstOrDefault(s => s.AssociateId == assoc.AssociateId);
                if (asc != null)
                {
                    db.Entry(asc).CurrentValues.SetValues(assoc);
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
                HousingComplex plex = mapper.MapToEntity(hc);
                plex = db.HousingComplexes.FirstOrDefault(a => a.HousingComplexId == hc.HousingComplexId);
                if (plex != null)
                {
                    db.Entry(plex).CurrentValues.SetValues(hc);
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
                HousingUnit unit = mapper.MapToEntity(hu);
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
                HousingData hde = mapper.MapToEntity(hd);
                hde = db.HousingDatas.FirstOrDefault(a => a.HousingDataId == hd.HousingDataId);
                if (hde != null)
                {
                    db.Entry(hde).CurrentValues.SetValues(hd);
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
