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
                Associate asc = mapper.MapToEntity(assoc);
                Associate oldAssoc = db.Associates.FirstOrDefault(a => a.Email.Equals(old));

                if (old != null)
                {
                    asc.AssociateId = oldAssoc.AssociateId;
                    //asc.Active = oldAssoc.Active;
                    //asc.Batch = oldAssoc.Batch;
                    //asc.BatchId = oldAssoc.BatchId;
                    //asc.DateOfBirth = oldAssoc.DateOfBirth;
                    //asc.Email = oldAssoc.Email;
                    //asc.FirstName = oldAssoc.FirstName;
                    //asc.Gender = oldAssoc.Gender;
                    //asc.GenderId = oldAssoc.GenderId;
                    //asc.HasCar = oldAssoc.HasCar;
                    //asc.HasKeys = oldAssoc.HasKeys;
                    //asc.LastName = oldAssoc.LastName;
                    //asc.PhoneNumber = oldAssoc.PhoneNumber;
                    //db.Entry()
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
                HousingComplex plex = mapper.MapToEntity(hc);
                HousingComplex old = db.HousingComplexes.FirstOrDefault(a => a.Name.Equals(oldComplex));
                if (old != null)
                {
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
                HousingUnit unit = mapper.MapToEntity(hu);
                HousingUnit old = db.HousingUnits.FirstOrDefault(a => a.HousingUnitName.Equals(oldUnit));

                if (old != null)
                {
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
                Batch batch = mapper.MapToEntity(b);
                Batch old = db.Batches.FirstOrDefault(a => a.Name.Equals(oldBatch));

                if (old != null)
                {
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
                Gender newGender = mapper.MapToEntity(g);

                Gender old = db.Genders.FirstOrDefault(a => a.Name.Equals(oldId));
                if (old != null)
                {
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
                HousingData hde = mapper.MapToEntity(hd);
                HousingData old = db.HousingDatas.FirstOrDefault(a => a.HousingDataAltId.Equals(oldData));

                if (old != null)
                {
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
