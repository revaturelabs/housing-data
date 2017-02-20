using AutoMapper;
using Housing.Data.Domain.DataAccessObjects;
using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
                logger.Trace("testing map housing complex coming in from db, com{0}", com.Name ?? "Object name is null");
                logger.Log(LogLevel.Trace, "Log housing complex mapping from db");
                comDao = mapper.Map<HousingComplexDao>(com);
                logger.Trace("testing map housing complex to dao, comDao{0}", comDao.Name ?? "Object name is null");
                logger.Log(LogLevel.Trace, "Log housing complex mapping to dao");
            }
            else
            {
                logger.Trace("testing map a new housing complex coming in from db, Complex object is null");
                logger.Log(LogLevel.Trace, "Log a new housing complex mapping from db");
                comDao = new HousingComplexDao();
                logger.Trace("testing map a new housing complex to dao, Returning new HousingComplexDao object");
                logger.Log(LogLevel.Trace, "Log a new housing complex mapping to dao");
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
                logger.Trace("testing mapping a housing complex from dao, comDao{0}", comDao.Name ?? "Object name is null");
                logger.Log(LogLevel.Trace, "Log housing complex mapping from dao");
                com = mapper.Map<HousingComplex>(comDao);
                logger.Trace("testing map housing complex from dao to the db, com{0}", com.Name ?? "Object name is null");
                logger.Log(LogLevel.Trace, "Log housing complex mapping to db");

                //get original object from db
                if (!string.IsNullOrWhiteSpace(comDao.Name))
                {
                    fromDB = db.HousingComplexes.FirstOrDefault(m => m.Name.Equals(comDao.Name));
                    if (fromDB != null)
                    {
                        logger.Trace("Getting housing complex from db, fromDB{0}", fromDB.Name ?? "Object name from DB is null");
                    }
                    logger.Log(LogLevel.Trace, "Log getting housing complex mapping from db");
                }
                //if db object exist then use existing object and map properties sent from dao-ignore name
                if (fromDB != null)
                {
                    com = fromDB;
                    if (!string.IsNullOrWhiteSpace(comDao.Address))
                    {
                        com.Address = comDao.Address;
                        logger.Trace("testing mapping a housing complex that aleady exist to db, com{0}", com.Name ?? "name is null");
                        logger.Log(LogLevel.Trace, "housing complex mapping to db");
                    }
                    if (!string.IsNullOrWhiteSpace(comDao.PhoneNumber))
                    {
                        logger.Trace("testing mapping a housing complex that already exist to db, comDao{0}", comDao.PhoneNumber ?? "Phone number is null");
                        logger.Log(LogLevel.Trace, "creating new housing complex mapping to db");
                        com.PhoneNumber = comDao.PhoneNumber;
                        logger.Trace("testing mapping a housing complex that already exist to db, com{0}", com.PhoneNumber ?? "Phone number is null");
                        logger.Log(LogLevel.Trace, "creating new housing complex mapping to db");
                    }
                }
                //if db object does not exist use automapper version of object and set active to true            
                else
                {
                    if (com != null)
                    {
                        com.Active = true;
                        logger.Trace("testing mapping a housing complex that doesn't exist to db, com{0}", com.Active.ToString());
                        logger.Log(LogLevel.Trace, "creating new housing complex mapping to db"); 
                    }
                }
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
            var mapper = HousingUnitMapper.CreateMapper();
            if (unit != null)
            {
                HousingUnitDao unitDao = mapper.Map<HousingUnitDao>(unit);
                if (unit.Gender != null)
                {
                    if (!string.IsNullOrWhiteSpace(unit.Gender.Name))
                    {
                        unitDao.GenderName = unit.Gender.Name;
                    } 
                }
                logger.Info("map housingunitdao");
                logger.Log(LogLevel.Info, "unitDao{0}", unitDao?.ToString());
                return unitDao; 
            }
            else
            {
                return new HousingUnitDao();
            }
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
                logger.Info("map housingunitdao");
                logger.Log(LogLevel.Info, "unitDao{0}", hu.HousingUnitId.ToString());

                //get original object from db
                if (!string.IsNullOrWhiteSpace(unitDao.HousingUnitName))
                {
                    fromDB = db.HousingUnits.FirstOrDefault(m => m.HousingUnitName.Equals(unitDao.HousingUnitName));
                    logger.Info("map housingunitdao");
                    logger.Log(LogLevel.Info, "fromDB{0}", fromDB?.HousingUnitId.ToString());
                }
                //if db object exist then use existing object and map properties sent from dao-ignore housingUnitName
                if (fromDB != null)
                {
                    hu = fromDB;
                    if (!string.IsNullOrWhiteSpace(unitDao.HousingUnitName))
                    {
                        hu.AptNumber = unitDao.AptNumber;
                        logger.Info("map complex apartment number");
                        logger.Log(LogLevel.Info, "hu{0}", hu?.AptNumber?.ToString());
                        hu.Gender = db.Genders.Where(m => m.Name.Equals(unitDao.GenderName)).FirstOrDefault();
                        logger.Info("map gender name");
                        logger.Log(LogLevel.Info, "hu{0}", hu?.Gender?.Name?.ToString());
                        hu.GenderId = hu.Gender.GenderId;
                        hu.HousingComplex = db.HousingComplexes.Where(m => m.Name.Equals(unitDao.HousingComplexName)).FirstOrDefault();
                        logger.Info("map complex name");
                        logger.Log(LogLevel.Info, "hu{0}", hu?.HousingComplex?.Name?.ToString());
                        hu.HousingComplexId = hu.HousingComplex.HousingComplexId;
                        hu.MaxCapacity = unitDao.MaxCapacity;
                        logger.Info("map housingunitdao max capacity");
                        logger.Log(LogLevel.Info, "hu{0}", hu?.MaxCapacity.ToString());
                        hu.LeaseEndDate = unitDao.LeaseEndDate;

                    }
                }
                //if db object does not exist use automapper version of object and set active to true            
                else
                {
                    hu.Active = true;
                    hu.Gender = db.Genders.Where(m => m.Name.Equals(unitDao.GenderName)).FirstOrDefault();
                    logger.Info("map gender name");
                    logger.Log(LogLevel.Info, "hu{0}", hu.Gender?.Name?.ToString());
                    hu.GenderId = hu.Gender.GenderId;
                    hu.HousingComplex = db.HousingComplexes.Where(m => m.Name.Equals(unitDao.HousingComplexName)).FirstOrDefault();
                    logger.Info("map complex name");
                    logger.Log(LogLevel.Info, "hu{0}", hu?.HousingComplex?.Name?.ToString());
                    hu.HousingComplexId = hu.HousingComplex.HousingComplexId;
                    logger.Info("map housingunitdao for new complex");
                    logger.Log(LogLevel.Info, "hu{0}", hu?.HousingComplexId?.ToString());
                }
                logger.Info("map housingunitdao");
                logger.Log(LogLevel.Info, "hu{0}", hu?.HousingComplexId?.ToString());
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
            if (data != null)
            {
                HousingDataDao dataDao = mapper.Map<HousingDataDao>(data);
                if (data.HousingUnitId != null)
                {
                    dataDao.HousingUnitName = db.HousingUnits.FirstOrDefault(m => m.HousingUnitId == data.HousingUnitId).HousingUnitName;
                }
                return dataDao; 
            }
            else
            {
                return new HousingDataDao();
            }
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
            if (dataDao != null)
            {
                hd = mapper.Map<HousingData>(dataDao);

                //get original object from db
                if (!string.IsNullOrWhiteSpace(dataDao.HousingDataAltId))
                {
                    fromDB = db.HousingDatas.FirstOrDefault(m => m.HousingDataAltId.Equals(dataDao.HousingDataAltId));
                    logger.Info("map housingdatadao id");
                    logger.Log(LogLevel.Info, "fromDB{0}", fromDB?.HousingDataAltId?.ToString());
                }
                //if db object exist then use existing object and map properties sent from dao-ignore housingDataAltId
                if (fromDB != null)
                {                   
                        hd = fromDB;
                        if (!string.IsNullOrWhiteSpace(dataDao.AssociateEmail))
                        {
                            hd.Associate = db.Associates.Where(m => m.Email.Equals(dataDao.AssociateEmail)).FirstOrDefault();
                            logger.Info("map housingdatadao associate email");
                            logger.Log(LogLevel.Info, "hd{0}", hd?.Associate?.Email?.ToString());
                        }
                        if (hd != null && hd.Associate != null && hd.Associate.AssociateId > 0)
                        {
                            hd.AssociateId = hd.Associate.AssociateId;
                        }
                        if (!string.IsNullOrWhiteSpace(dataDao.HousingUnitName))
                        {
                            hd.HousingUnit = db.HousingUnits.Where(m => m.HousingUnitName.Equals(dataDao.HousingUnitName)).FirstOrDefault();
                            logger.Info("map housingdatadao housing unit name");
                            logger.Log(LogLevel.Info, "hd{0}", hd?.HousingUnit?.HousingUnitName?.ToString());
                        }
                        if (hd != null && hd.HousingUnit != null && hd.HousingUnit.HousingUnitId > 0)
                        {
                            hd.HousingUnitId = hd.HousingUnit.HousingUnitId;
                            logger.Info("map housingdatadao unit id");
                            logger.Log(LogLevel.Info, "hd{0}", hd?.HousingUnit?.HousingUnitId.ToString());
                        }
                        if (!(dataDao.MoveInDate == DateTime.MinValue))
                        {
                            hd.MoveInDate = dataDao.MoveInDate;
                            logger.Info("map housingdatadao associate move in date");
                            logger.Log(LogLevel.Info, "hd{0}", hd?.MoveInDate.ToString());
                        }
                        if (!(dataDao.MoveOutDate == DateTime.MinValue))
                        {
                            hd.MoveOutDate = dataDao.MoveOutDate;
                            logger.Info("map housingdatadao associate move out date");
                            logger.Log(LogLevel.Info, "hd{0}", hd?.MoveOutDate.ToString());
                        }
                    


                }
                //if db object does not exist use automapper version of object and set active to true            
                else
                {
                    hd.Active = true;
                    hd.Associate = db.Associates.Where(m => m.Email.Equals(dataDao.AssociateEmail)).FirstOrDefault();
                    logger.Info("map housingdatadao associate email");
                    logger.Log(LogLevel.Info, "hd{0}", hd?.Associate?.Email?.ToString());
                    hd.AssociateId = hd.Associate.AssociateId;
                    hd.HousingUnit = db.HousingUnits.Where(m => m.HousingUnitName.Equals(dataDao.HousingUnitName)).FirstOrDefault();
                    logger.Info("map housingdatadao housing unit name");
                    logger.Log(LogLevel.Info, "hd{0}", hd?.HousingUnit?.HousingUnitName?.ToString());
                    hd.HousingUnitId = hd.HousingUnit.HousingUnitId;
                    hd.HousingDataAltId = CRUD.AccessHelper.GetRandomHexNumber();  //gets random hex number of length 8
                    while (db.HousingDatas.Where(m => m.HousingDataAltId.Equals(hd.HousingDataAltId)).Count() > 0)
                    {
                        hd.HousingDataAltId = CRUD.AccessHelper.GetRandomHexNumber();  //repeat random number generation until unique
                    }
                }
                logger.Info("map housingdatadao");
                logger.Log(LogLevel.Info, "hd{0}");
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
            if (assoc != null)
            {
                AssociateDao assocDao = mapper.Map<AssociateDao>(assoc);
                if (assoc.Batch != null)
                {
                    assocDao.BatchName = assoc.Batch.Name; 
                }
                logger.Info("map associatedao batch name");
                logger.Log(LogLevel.Info, "assocDao{0}", assocDao?.BatchName?.ToString());
                if (assoc.Gender != null)
                {
                    assocDao.GenderName = assoc.Gender.Name; 
                }
                logger.Info("map associatedao housing unit name");
                logger.Log(LogLevel.Info, "assocDao{0}", assocDao?.GenderName?.ToString());
                return assocDao; 
            }
            else
            {
                return new AssociateDao();
            }
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
            if (assocDao != null)
            {
                assoc = mapper.Map<Associate>(assocDao);

                //get original object from db
                if (!string.IsNullOrWhiteSpace(assocDao.Email))
                {
                    fromDB = db.Associates.Where(m => m.Email.Equals(assocDao.Email)).FirstOrDefault();
                    logger.Info("map associate email");
                    logger.Log(LogLevel.Info, "fromDB{0}", fromDB?.Email?.ToString());
                }
                //if db object exist then use existing object and map properties sent from dao-ignore email
                if (fromDB != null)
                {
                    assoc = fromDB;
                    if (assocDao != null)
                    {
                        if (!string.IsNullOrWhiteSpace(assocDao.BatchName))
                        {
                            assoc.Batch = db.Batches.Where(m => m.Name.Equals(assocDao.BatchName)).FirstOrDefault();
                            logger.Info("map associate batch");
                            logger.Log(LogLevel.Info, "assoc{0}", assoc?.Batch?.Name?.ToString());
                        }
                        if (assoc.Batch != null && assoc.Batch.BatchId > 0)
                        {
                            assoc.BatchId = assoc.Batch.BatchId;
                        }
                        if (!string.IsNullOrWhiteSpace(assocDao.GenderName))
                        {
                            assoc.Gender = db.Genders.Where(m => m.Name.Equals(assocDao.GenderName)).FirstOrDefault();
                            logger.Info("map associate gender");
                            logger.Log(LogLevel.Info, "assoc{0}", assoc?.Gender?.ToString());
                        }
                        if (assoc.Gender != null && assoc.Gender.GenderId > 0)
                        {
                            assoc.GenderId = assoc.Gender.GenderId;
                        }
                        if (!(assocDao.DateOfBirth == DateTime.MinValue))
                        {
                            assoc.DateOfBirth = assocDao.DateOfBirth;
                            logger.Info("map associate dob");
                            logger.Log(LogLevel.Info, "assoc{0}", assoc?.DateOfBirth.ToString());
                        }
                        if (!string.IsNullOrWhiteSpace(assocDao.FirstName))
                        {
                            assoc.FirstName = assocDao.FirstName;
                            logger.Info("map associate first name");
                            logger.Log(LogLevel.Info, "assoc{0}", assoc?.FirstName?.ToString());
                        }
                        assoc.HasCar = assocDao.HasCar;//no way to test if data is valid
                        logger.Info("map associate has car");
                        logger.Log(LogLevel.Info, "assoc{0}", assoc?.HasCar.ToString());
                        assoc.HasKeys = assocDao.HasKeys;//no way to test if data is valid
                        logger.Info("map associate has keys");
                        logger.Log(LogLevel.Info, "assoc{0}", assoc?.HasKeys.ToString());
                        if (!string.IsNullOrEmpty(assocDao.LastName))
                        {
                            assoc.LastName = assocDao.LastName;

                            logger.Info("map associate last name");
                            logger.Log(LogLevel.Info, "assoc{0}", assoc?.LastName?.ToString());
                        }
                        if (!string.IsNullOrEmpty(assocDao.PhoneNumber))
                        {
                            assoc.PhoneNumber = assocDao.PhoneNumber;
                            logger.Info("map associate phone number");
                            logger.Log(LogLevel.Info, "assoc{0}", assoc?.PhoneNumber?.ToString());
                        }
                        assoc.NeedsHousing = assocDao.NeedsHousing;
                    }
                }
                //if db object does not exist use automapper version of object and set active to true            
                else
                {
                    assoc.Active = true;
                    assoc.Batch = db.Batches.Where(m => m.Name.Equals(assocDao.BatchName)).FirstOrDefault();
                    logger.Info("map associate batch");
                    logger.Log(LogLevel.Info, "assoc{0}", assoc?.Batch?.Name?.ToString());
                    assoc.BatchId = assoc.Batch.BatchId;
                    assoc.Gender = db.Genders.Where(m => m.Name.Equals(assocDao.GenderName)).FirstOrDefault();
                    logger.Info("map associate gender");
                    logger.Log(LogLevel.Info, "assoc{0}", assoc?.Gender?.Name?.ToString());
                    assoc.GenderId = assoc.Gender.GenderId;

                }
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
            if (batch != null)
            {
                BatchDao batchDao = mapper.Map<BatchDao>(batch);
                logger.Info("map batchdao name");
                logger.Log(LogLevel.Info, "batchDao{0}", batchDao?.Name?.ToString());
                return batchDao; 
            }
            else
            {
                return new BatchDao();
            }
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
            if (batchDao != null)
            {
                batch = mapper.Map<Batch>(batchDao);

                //get original object from db
                if (!string.IsNullOrWhiteSpace(batchDao.Name))
                {
                    fromDB = db.Batches.Where(m => m.Name.Equals(batchDao.Name)).FirstOrDefault();
                    logger.Info("map batch name");
                    logger.Log(LogLevel.Info, "fromDB{0}", fromDB?.Name?.ToString());
                }
                //if db object exist then use existing object and map properties sent from dao-ignore name
                if (fromDB != null)
                {

                    batch = fromDB;
                    if (!(batchDao.EndDate == DateTime.MinValue))
                    {
                        batch.EndDate = batchDao.EndDate;
                        logger.Info("map batch end date");
                        logger.Log(LogLevel.Info, "batch{0}", batch?.EndDate.ToString());
                    }
                    if (!string.IsNullOrWhiteSpace(batchDao.Instructor))
                    {
                        batch.Instructor = batchDao.Instructor;
                        logger.Info("map batch instructor");
                        logger.Log(LogLevel.Info, "batch{0}", batch?.Instructor?.ToString());
                    }
                    if (!(batch.StartDate == DateTime.MinValue))
                    {
                        batch.StartDate = batchDao.StartDate;
                        logger.Info("map batch start date");
                        logger.Log(LogLevel.Info, "batch{0}", batch?.StartDate.ToString());
                    }
                    if (!string.IsNullOrWhiteSpace(batchDao.Technology))
                    {
                        batch.Technology = batchDao.Technology;
                        logger.Info("map batch technology");
                        logger.Log(LogLevel.Info, "batch{0}", batch?.Technology?.ToString());
                    }
                }
                //if db object does not exist use automapper version of object and set active to true            
                else
                {
                    batch.Active = true;
                }
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
            if (gen != null)
            {
                GenderDao genDao = mapper.Map<GenderDao>(gen);
                return genDao; 
            }
            else
            {
                return new GenderDao();
            }
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
            if (genDao != null)
            {
                gen = mapper.Map<Gender>(genDao);

                //get original object from db
                if (!string.IsNullOrWhiteSpace(genDao.Name))
                {
                    fromDB = db.Genders.Where(m => m.Name.Equals(genDao.Name)).FirstOrDefault();
                    logger.Info("map gender name");
                    logger.Log(LogLevel.Info, "fromDB{0}", fromDB?.Name?.ToString());
                }
                //if db object exist then use existing object and map properties sent from dao
                if (fromDB != null)
                {
                    gen = fromDB;
                    if (!string.IsNullOrWhiteSpace(genDao.Name))
                    {
                        gen.Name = genDao.Name;
                        logger.Info("map gender name");
                        logger.Log(LogLevel.Info, "gen{0}", gen?.Name?.ToString());
                    }

                }
                //if db object does not exist use automapper version of object and set active to true            
                else
                {
                    gen.Active = true;
                }
            }                  
            return gen;
        }

    }
}
