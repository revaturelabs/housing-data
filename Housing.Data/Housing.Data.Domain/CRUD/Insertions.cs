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

        private readonly HousingDB_DevEntities db;
        public static AccessMapper mapper;

        /// <summary>
        /// constructor
        /// </summary>
        public AccessHelper()
        {
            db = new HousingDB_DevEntities();
            mapper = new AccessMapper(db);
        }

        #region insertions

        /// <summary>
        /// insert gender into the DB
        /// </summary>
        /// <param name="gender"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertGender(GenderDao gender)
        {
            //map to EF object 
            var itm = mapper.MapToEntity(gender);
            //set Active bit to true 
            itm.Active = true;
            //insert into db
            db.Genders.Add(itm);
            //return success or failure
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// insert batch into the DB
        /// </summary>
        /// <param name="batch"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertBatch(BatchDao batch)
        {
            //map to EF object 
            var itm = mapper.MapToEntity(batch);
            //set Active bit to true 
            itm.Active = true;
            //insert into db
            db.Batches.Add(itm);
            //return success or failure
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// insert Associate into the DB
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertAssociate(AssociateDao assoc)
        {
            //map to EF object 
            var itm = mapper.MapToEntity(assoc);
            //set Active bit to true 
            itm.Active = true;
            //insert into db
            db.Associates.Add(itm);
            //return success or failure
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// insert HousingComplex into the DB
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingComplex(HousingComplexDao hc)
        {
            //map to EF object 
            var itm = mapper.MapToEntity(hc);
            //set Active bit to true 
            itm.Active = true;
            //insert into db
            db.HousingComplexes.Add(itm);
            //return success or failure
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// insert HousingUnit into the DB
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingUnit(HousingUnitDao hu)
        {
            //map to EF object 
            var itm = mapper.MapToEntity(hu);
            //set Active bit to true 
            itm.Active = true;
            //insert into db
            db.HousingUnits.Add(itm);
            //return success or failure
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// insert HousingData entry into the DB
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>true if insertion successful</returns>
        public bool InsertHousingData(HousingDataDao hd)
        {
            //map to EF object 
            var itm = mapper.MapToEntity(hd);

            //set Active bit to true 
            itm.Active = true;

            //get associate object from db
            var assoc = db.Associates.ToList().Where(m => m.Email.Equals(itm.Associate.Email)).FirstOrDefault();

            //get housingUnit object from db
            var assocHouse = db.HousingUnits.ToList().Where(m => m.HousingComplex.Name.Equals(itm.HousingUnit.HousingComplex.Name)).FirstOrDefault();

            //check gender match between Associate, Unit
            var genderMatch = assoc.Gender.Equals(assocHouse.Gender);

            //check that Unit occupancy is not exceeded
            //get number of assoc assigned to unit
            var it = db.HousingData_By_Unit(assocHouse.HousingUnitId);

            //continue insert if gender and capacity are OK
            if (genderMatch && (it.Count() < assocHouse.MaxCapacity))
            {
                //insert into db
                db.HousingDatas.Add(itm);
                //return success or failure
                return db.SaveChanges() > 0;
            }
            //return false if else
            else
                return false;

        }

        #endregion
    }
}
