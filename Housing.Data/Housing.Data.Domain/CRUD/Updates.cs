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
        public bool UpdateAssociate(string old, AssociateDao assoc)
        {
            try
            {
                Associate asc;
                Associate oldAssoc;
                if (!string.IsNullOrWhiteSpace(old) && assoc != null)
                {
                    asc = mapper.MapToEntity(assoc);
                    oldAssoc = db.Associates.FirstOrDefault(a => a.Email.Equals(old));
                    asc.AssociateId = oldAssoc.AssociateId;                    
                    db.Entry(oldAssoc).CurrentValues.SetValues(asc);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// update HousingComplex 
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>true if update successful</returns>
        public bool UpdateHousingComplex(string oldComplex, HousingComplexDao hc)
        {
            try
            {                
                if (!string.IsNullOrWhiteSpace(oldComplex) && hc != null)
                {
                    HousingComplex plex = mapper.MapToEntity(hc);
                    HousingComplex old = db.HousingComplexes.FirstOrDefault(a => a.Name.Equals(oldComplex));
                    plex.HousingComplexId = old.HousingComplexId;
                    db.Entry(old).CurrentValues.SetValues(plex);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// update HousingUnit
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>true if update successful</returns>
        public bool UpdateHousingUnit(string oldUnit, HousingUnitDao hu)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(oldUnit) && hu != null)
                {
                    HousingUnit unit = mapper.MapToEntity(hu);
                    HousingUnit old = db.HousingUnits.FirstOrDefault(a => a.HousingUnitName.Equals(oldUnit));
                    unit.HousingUnitId = old.HousingUnitId;
                    db.Entry(old).CurrentValues.SetValues(unit);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// update batch entry
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool UpdateBatch(string oldBatch, BatchDao b)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(oldBatch) && b != null)
                {
                    Batch batch = mapper.MapToEntity(b);
                    Batch old = db.Batches.FirstOrDefault(a => a.Name.Equals(oldBatch));
                    batch.BatchId = old.BatchId;
                    db.Entry(old).CurrentValues.SetValues(batch);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Update Gender entry
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public bool UpdateGender(string oldId, GenderDao g)
        {
            try
            {                
                if (!string.IsNullOrWhiteSpace(oldId) && g != null)
                {
                    Gender newGender = mapper.MapToEntity(g);
                    Gender old = db.Genders.FirstOrDefault(a => a.Name.Equals(oldId));
                    newGender.GenderId = old.GenderId;
                    db.Entry(old).CurrentValues.SetValues(newGender);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// update HousingData entry
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>true if update successful</returns>
        public bool UpdateHousingData(string oldData, HousingDataDao hd)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(oldData) && hd != null)
                {
                    HousingData hde = mapper.MapToEntity(hd);
                    HousingData old = db.HousingDatas.FirstOrDefault(a => a.HousingDataAltId.Equals(oldData));
                    hde.HousingDataId = old.HousingDataId;
                    db.Entry(old).CurrentValues.SetValues(hde);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
    }
}
