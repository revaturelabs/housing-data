using AutoMapper;
using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Housing.Data.Domain
{
    public class AccessMapper
    {
        private readonly MapperConfiguration HousingComplexMapper = new MapperConfiguration(c => c.CreateMap<HousingComplex, HousingComplexDao>().ReverseMap());
        private readonly MapperConfiguration HousingUnitMapper = new MapperConfiguration(u => u.CreateMap<HousingUnit, HousingUnitDao>().ReverseMap());
        private readonly MapperConfiguration HousingDataMapper = new MapperConfiguration(d => d.CreateMap<HousingData, HousingDataDao>().ReverseMap());
        private readonly MapperConfiguration AssociateMapper = new MapperConfiguration(a => a.CreateMap<Associate, AssociateDao>().ReverseMap());
        private readonly MapperConfiguration BatchMapper = new MapperConfiguration(b => b.CreateMap<Batch, BatchDao>().ReverseMap());
        private readonly MapperConfiguration GenderMapper = new MapperConfiguration(g => g.CreateMap<Gender, GenderDao>().ReverseMap());

        private readonly HousingDB_DevEntities db;
        public List<Batch> batches;
        public List<Gender> genders;
        public List<HousingUnit> housingUnits;
        
        public AccessMapper() {
            db = new HousingDB_DevEntities();
            batches = db.Batches.ToList();
            genders = db.Genders.ToList();
            housingUnits = db.HousingUnits.ToList();
        }
        public AccessMapper(HousingDB_DevEntities context)
        {
            db = context;
            batches = db.Batches.ToList();
            genders = db.Genders.ToList();
            housingUnits = db.HousingUnits.ToList();
        }
        /// <summary>
        /// Map HousingComplex entity object to HousingComplexDao
        /// </summary>
        /// <param name="com"></param>
        /// <returns>HousingComplexDao</returns>
        public HousingComplexDao MapToDao(HousingComplex com)
        {
            var mapper = HousingComplexMapper.CreateMapper();
            HousingComplexDao comDao;
            if(com!=null)
            {
                comDao = mapper.Map<HousingComplexDao>(com);
            }
            else
            {
                comDao = new HousingComplexDao();
            }
            return comDao;
        }

        /// <summary>
        /// Map HousingComplexDao to HousingComplex entity object 
        /// </summary>
        /// <param name="comDao"></param>
        /// <returns>HousingComplex</returns>
        public HousingComplex MapToEntity(HousingComplexDao comDao)
        {           
            HousingComplex com = null;
            HousingComplex fromDB = null;
            //use automapper to map matching properties
            var mapper = HousingComplexMapper.CreateMapper();
            if (comDao != null)
            {
                com = mapper.Map<HousingComplex>(comDao);
            }
            //get original object from db
            if (!string.IsNullOrWhiteSpace(comDao.Name))
            {
                fromDB = db.HousingComplexes.Where(m => m.Name.Equals(comDao.Name)).FirstOrDefault();
            }
            //if db object exist then use existing object and map properties sent from dao-ignore name
            if (fromDB != null)
            {
                com = fromDB;
                if (!string.IsNullOrWhiteSpace(comDao.Address))
                {
                    com.Address = comDao.Address;
                    
                }
                if(!string.IsNullOrWhiteSpace(comDao.PhoneNumber))
                {
                    com.PhoneNumber = comDao.PhoneNumber;
                }
            }
            //if db object does not exist use automapper version of object and set active to true            
            else
            {
                com.Active = true;
            }
            return com;
        }

        /// <summary>
        /// Map HousingUnit entity object to HousingUnitDao
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>HousingUnitDao</returns>
        public HousingUnitDao MapToDao(HousingUnit unit)
        {
            //todo add null checks
            var mapper = HousingUnitMapper.CreateMapper();
            HousingUnitDao unitDao = mapper.Map<HousingUnitDao>(unit);
            unitDao.GenderName = unit.Gender.Name;
            return unitDao;
        }

        /// <summary>
        /// Map HousingUnitDao to HousingUnit entity object 
        /// </summary>
        /// <param name="unitDao"></param>
        /// <returns>HousingUnit</returns>
        public HousingUnit MapToEntity(HousingUnitDao unitDao)
        {            
            HousingUnit hu = null;
            HousingUnit fromDB = null;
            //use automapper to map matching properties
            var mapper = HousingUnitMapper.CreateMapper();
            if (unitDao != null)
            {
                hu = mapper.Map<HousingUnit>(unitDao);
            }
            //get original object from db
            if (!string.IsNullOrWhiteSpace(unitDao.HousingUnitName))
            {
                fromDB = db.HousingUnits.Where(m => m.HousingUnitName.Equals(unitDao.HousingUnitName)).FirstOrDefault();
            }
            //if db object exist then use existing object and map properties sent from dao-ignore housingUnitName
            if (fromDB != null)
            {
                hu = fromDB;
                if (!string.IsNullOrWhiteSpace(unitDao.HousingUnitName))
                {
                    hu.AptNumber = unitDao.AptNumber;
                    hu.Gender = db.Genders.Where(m => m.Name.Equals(unitDao.GenderName)).FirstOrDefault();
                    hu.GenderId = hu.Gender.GenderId;
                    hu.HousingComplex = db.HousingComplexes.Where(m => m.Name.Equals(unitDao.HousingComplexName)).FirstOrDefault();
                    hu.HousingComplexId = hu.HousingComplex.HousingComplexId;
                    hu.MaxCapacity = unitDao.MaxCapacity;
                    
                }
            }
            //if db object does not exist use automapper version of object and set active to true            
            else
            {
                hu.Active = true;
                hu.Gender = db.Genders.Where(m => m.Name.Equals(unitDao.GenderName)).FirstOrDefault();
                hu.GenderId = hu.Gender.GenderId;
                hu.HousingComplex = db.HousingComplexes.Where(m => m.Name.Equals(unitDao.HousingComplexName)).FirstOrDefault();
                hu.HousingComplexId = hu.HousingComplex.HousingComplexId; 
            }
            return hu;
        }

        /// <summary>
        /// Map HousingData entity object to HousingDataDao
        /// </summary>
        /// <param name="data"></param>
        /// <returns>HousingDataDao</returns>
        public HousingDataDao MapToDao(HousingData data)
        {
            var mapper = HousingDataMapper.CreateMapper();
            HousingDataDao dataDao = mapper.Map<HousingDataDao>(data);
            dataDao.HousingUnitName = db.HousingUnits.Where(m => m.HousingUnitId == data.HousingUnitId).FirstOrDefault().HousingUnitName;
            return dataDao;
        }

        /// <summary>
        /// Map HousingDataDao to HousingData entity object 
        /// </summary>
        /// <param name="dataDao"></param>
        /// <returns>HousingData</returns>
        public HousingData MapToEntity(HousingDataDao dataDao)
        {
            HousingData hd=null;
            HousingData fromDB=null;
            //use automapper to map matching properties
            var mapper = HousingDataMapper.CreateMapper();
            if (dataDao!=null)
            {
                hd = mapper.Map<HousingData>(dataDao); 
            }
            //get original object from db
            if (!string.IsNullOrWhiteSpace(dataDao.HousingDataAltId))
            {
                fromDB = db.HousingDatas.Where(m => m.HousingDataAltId.Equals(dataDao.HousingDataAltId)).FirstOrDefault(); 
            }
            //if db object exist then use existing object and map properties sent from dao-ignore housingDataAltId
            if (fromDB != null)
            {
                if (dataDao!=null)
                {
                    hd = fromDB;
                    if (!string.IsNullOrWhiteSpace(dataDao.AssociateEmail))
                    {
                        hd.Associate = db.Associates.Where(m => m.Email.Equals(dataDao.AssociateEmail)).FirstOrDefault(); 
                    }
                    if (hd!=null && hd.Associate!=null && hd.Associate.AssociateId>0)
                    {
                        hd.AssociateId = hd.Associate.AssociateId; 
                    }
                    if (!string.IsNullOrWhiteSpace(dataDao.HousingUnitName))
                    {
                        hd.HousingUnit = db.HousingUnits.Where(m => m.HousingUnitName.Equals(dataDao.HousingUnitName)).FirstOrDefault(); 
                    }
                    if (hd!=null && hd.HousingUnit!=null && hd.HousingUnit.HousingUnitId>0)
                    {
                        hd.HousingUnitId = hd.HousingUnit.HousingUnitId; 
                    }
                    if (!(dataDao.MoveInDate==DateTime.MinValue))
                    {
                        hd.MoveInDate = dataDao.MoveInDate; 
                    }
                    if (!(dataDao.MoveOutDate==DateTime.MinValue))
                    {
                        hd.MoveOutDate = dataDao.MoveOutDate;  
                    }
                }
                

            }
            //if db object does not exist use automapper version of object and set active to true            
            else
            {
                hd.Active = true;
                hd.Associate = db.Associates.Where(m => m.Email.Equals(dataDao.AssociateEmail)).FirstOrDefault();
                hd.AssociateId = hd.Associate.AssociateId;
                hd.HousingUnit = db.HousingUnits.Where(m => m.HousingUnitName.Equals(dataDao.HousingUnitName)).FirstOrDefault();
                hd.HousingUnitId = hd.HousingUnit.HousingUnitId;
                
            }
            
            return hd;
        }

        /// <summary>
        /// Map Associate entity object to AssociateDao
        /// </summary>
        /// <param name="assoc"></param>
        /// <returns>AssociateDao</returns>
        public AssociateDao MapToDao(Associate assoc)
        {
            var mapper = AssociateMapper.CreateMapper();
            AssociateDao assocDao = mapper.Map<AssociateDao>(assoc);
            assocDao.BatchName = assoc.Batch.Name;
            assocDao.GenderName = assoc.Gender.Name;
            return assocDao;
        }

        /// <summary>
        /// Map AssociateDao to Associate entity object
        /// </summary>
        /// <param name="assocDao"></param>
        /// <returns>Associate</returns>
        public Associate MapToEntity(AssociateDao assocDao)
        {           
            Associate assoc=null;
            Associate fromDB=null;
            //use automapper to map matching properties
            var mapper = AssociateMapper.CreateMapper();
            if (assocDao!=null)
            {
                assoc = mapper.Map<Associate>(assocDao); 
            }
            //get original object from db
            if (!string.IsNullOrWhiteSpace(assocDao.Email))
            {
                fromDB = db.Associates.Where(m => m.Email.Equals(assocDao.Email)).FirstOrDefault(); 
            }
            //if db object exist then use existing object and map properties sent from dao-ignore email
            if (fromDB != null)
            {
                assoc = fromDB;
                if(assocDao!=null)
                {
                    if (!string.IsNullOrWhiteSpace(assocDao.BatchName))
                    {
                        assoc.Batch = db.Batches.Where(m => m.Name.Equals(assocDao.BatchName)).FirstOrDefault();
                    }
                    if (assoc.Batch != null && assoc.Batch.BatchId > 0)
                    {
                        assoc.BatchId = assoc.Batch.BatchId;
                    }
                    if (!string.IsNullOrWhiteSpace(assocDao.GenderName))
                    {
                        assoc.Gender = db.Genders.Where(m => m.Name.Equals(assocDao.GenderName)).FirstOrDefault();
                    }
                    if (assoc.Gender != null && assoc.Gender.GenderId > 0)
                    {
                        assoc.GenderId = assoc.Gender.GenderId;
                    }
                    if (!(assocDao.DateOfBirth == DateTime.MinValue))
                    {
                        assoc.DateOfBirth = assocDao.DateOfBirth;
                    }
                    if (!string.IsNullOrWhiteSpace(assocDao.FirstName))
                    {
                        assoc.FirstName = assocDao.FirstName;
                    }
                    assoc.HasCar = assocDao.HasCar;//no way to test if data is valid
                    assoc.HasKeys = assocDao.HasKeys;//no way to test if data is valid
                    if (!string.IsNullOrEmpty(assocDao.LastName))
                    {
                        assoc.LastName = assocDao.LastName; 
                    }
                    if (!string.IsNullOrEmpty(assocDao.PhoneNumber))
                    {
                        assoc.PhoneNumber = assocDao.PhoneNumber; 
                    }
                }               
            }
            //if db object does not exist use automapper version of object and set active to true            
            else
            {
                assoc.Active = true;
                assoc.Batch = db.Batches.Where(m => m.Name.Equals(assocDao.BatchName)).FirstOrDefault();
                assoc.BatchId = assoc.Batch.BatchId;
                assoc.Gender = db.Genders.Where(m => m.Name.Equals(assocDao.GenderName)).FirstOrDefault();
                assoc.GenderId = assoc.Gender.GenderId;

            }
            return assoc;
        }

        /// <summary>
        /// Map Batch entity object to BatchDao
        /// </summary>
        /// <param name="batch"></param>
        /// <returns>BatchDao</returns>
        public BatchDao MapToDao(Batch batch)
        {
            var mapper = BatchMapper.CreateMapper();
            BatchDao batchDao = mapper.Map<BatchDao>(batch);
            return batchDao;
        }

        /// <summary>
        /// Map BatchDao to Batch entity object
        /// </summary>
        /// <param name="batchDao"></param>
        /// <returns>Batch</returns>
        public Batch MapToEntity(BatchDao batchDao)
        {
            Batch batch=null;
            Batch fromDB = null;
            //use automapper to map matching properties
            var mapper = BatchMapper.CreateMapper();
            if (batchDao!=null)
            {
                batch = mapper.Map<Batch>(batchDao); 
            }
            //get original object from db
            if (!string.IsNullOrWhiteSpace(batchDao.Name))
            {
                fromDB = db.Batches.Where(m => m.Name.Equals(batchDao.Name)).FirstOrDefault(); 
            }
            //if db object exist then use existing object and map properties sent from dao-ignore name
            if (fromDB != null)
            {
                                
                batch = fromDB;                
                if (!(batchDao.EndDate == DateTime.MinValue))
                {
                    batch.EndDate = batchDao.EndDate; 
                }
                if (!string.IsNullOrWhiteSpace(batchDao.Instructor))
                {
                    batch.Instructor = batchDao.Instructor; 
                }
                if (!(batch.StartDate==DateTime.MinValue))
                {
                    batch.StartDate = batchDao.StartDate; 
                }
                if (!string.IsNullOrWhiteSpace(batchDao.Technology))
                {
                    batch.Technology = batchDao.Technology; 
                }
            }
            //if db object does not exist use automapper version of object and set active to true            
            else
            {
                batch.Active = true;                
            }
            return batch;
        }

        /// <summary>
        /// Map Gender entity object to GenderDao
        /// </summary>
        /// <param name="gen"></param>
        /// <returns>AssociateDao</returns>
        public GenderDao MapToDao(Gender gen)
        {
            var mapper = GenderMapper.CreateMapper();
            GenderDao genDao = mapper.Map<GenderDao>(gen);
            return genDao;
        }

        /// <summary>
        /// Map GenderDao to Gender entity object
        /// </summary>
        /// <param name="genDao"></param>
        /// <returns>Gender</returns>
        public Gender MapToEntity(GenderDao genDao)
        {
            Gender gen=null;
            Gender fromDB=null;
            //use automapper to map matching properties
            var mapper = GenderMapper.CreateMapper();
            if (genDao!=null)
            {
                gen = mapper.Map<Gender>(genDao); 
            }
            //get original object from db
            if (!string.IsNullOrWhiteSpace(genDao.Name))
            {
                fromDB = db.Genders.Where(m => m.Name.Equals(genDao.Name)).FirstOrDefault(); 
            }
            //if db object exist then use existing object and map properties sent from dao
            if (fromDB != null)
            {
                gen = fromDB;
                if(!string.IsNullOrWhiteSpace(genDao.Name))                
                {
                    gen.Name = genDao.Name;
                }
                                
            }
            //if db object does not exist use automapper version of object and set active to true            
            else
            {                
                gen.Active = true;                
            }                        
            return gen;
        }

    }
}
