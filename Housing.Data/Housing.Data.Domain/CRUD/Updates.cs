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
                Associate old = db.Associates.FirstOrDefault(a => a.AssociateId == asc.AssociateId);

                if (old != null)
                {
                    db.Entry(old).CurrentValues.SetValues(asc);
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
                HousingComplex old = db.HousingComplexes.FirstOrDefault(a => a.HousingComplexId == plex.HousingComplexId);
                if (old != null)
                {
                    db.Entry(old).CurrentValues.SetValues(plex);
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

                HousingUnit old = db.HousingUnits.FirstOrDefault(a => a.HousingUnitId == unit.HousingUnitId);
                if (old != null)
                {
                    db.Entry(old).CurrentValues.SetValues(unit);
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
        /// update batch entry
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool UpdateBatch(BatchDao b)
        {
            try
            {
                Batch batch = mapper.MapToEntity(b);

                Batch old = db.Batches.FirstOrDefault(a => a.BatchId == batch.BatchId);
                if (old != null)
                {
                    db.Entry(old).CurrentValues.SetValues(batch);
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
        /// Update Gender entry
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public bool UpdateGender(GenderDao g)
        {
            try
            {
                Gender gender = mapper.MapToEntity(g);

                Gender old = db.Genders.FirstOrDefault(a => a.GenderId == gender.GenderId);
                if (old != null)
                {
                    db.Entry(old).CurrentValues.SetValues(gender);
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
                HousingData old = db.HousingDatas.FirstOrDefault(a => a.HousingDataId == hd.HousingDataId);

                //awaiting updated HousingDataDao merge to fix this
                //HousingData old = db.HousingDatas.FirstOrDefault(a => a.HousingUnit.AptNumber == hd.ApartmentNumber && a.Associate.Email == hd.AssociateEmail && a.HousingUnit.HousingComplex.Name == hd.ComplexName);
                if (old != null)
                {
                    db.Entry(old).CurrentValues.SetValues(hde);
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
