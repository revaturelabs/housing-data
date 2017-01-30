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
        
        public AccessMapper() {
            db = new HousingDB_DevEntities();
            batches = db.Batches.ToList();
            genders = db.Genders.ToList();
        }

        /// <summary>
        /// Map HousingComplex entity object to HousingComplexDao
        /// </summary>
        /// <param name="com"></param>
        /// <returns>HousingComplexDao</returns>
        public HousingComplexDao MapToDao(HousingComplex com)
        {
            var mapper = HousingComplexMapper.CreateMapper();
            HousingComplexDao comDao = mapper.Map<HousingComplexDao>(com);
            return comDao;
        }

        /// <summary>
        /// Map HousingComplexDao to HousingComplex entity object 
        /// </summary>
        /// <param name="comDao"></param>
        /// <returns>HousingComplex</returns>
        public HousingComplex MapToEntity(HousingComplexDao comDao)
        {
            var mapper = HousingComplexMapper.CreateMapper();
            HousingComplex com = mapper.Map<HousingComplex>(comDao);
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
            HousingUnitDao unitDao = mapper.Map<HousingUnitDao>(unit);
            unitDao.Gender = unit.Gender.Name;
            return unitDao;
        }

        /// <summary>
        /// Map HousingUnitDao to HousingUnit entity object 
        /// </summary>
        /// <param name="unitDao"></param>
        /// <returns>HousingUnit</returns>
        public HousingUnit MapToEntity(HousingUnitDao unitDao)
        {
            var mapper = HousingUnitMapper.CreateMapper();
            HousingUnit unit = mapper.Map<HousingUnit>(unitDao);
            unit.GenderId = genders.Find(g => g.Name.Equals(unitDao.Gender)).GenderId;
            return unit;
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
            return dataDao;
        }

        /// <summary>
        /// Map HousingDataDao to HousingData entity object 
        /// </summary>
        /// <param name="dataDao"></param>
        /// <returns>HousingData</returns>
        public HousingData MapToEntity(HousingDataDao dataDao)
        {
            var mapper = HousingDataMapper.CreateMapper();
            HousingData data = mapper.Map<HousingData>(dataDao);
            return data;
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
            var mapper = AssociateMapper.CreateMapper();
            Associate assoc = mapper.Map<Associate>(assocDao);
            assoc.BatchId = batches.Find(b => b.Name.Equals(assocDao.BatchName)).BatchId;
            assoc.GenderId = genders.Find(g => g.Name.Equals(assocDao.GenderName)).GenderId;
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
            var mapper = BatchMapper.CreateMapper();
            Batch batch = mapper.Map<Batch>(batchDao);
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

            var mapper = GenderMapper.CreateMapper();
            Gender gen = mapper.Map<Gender>(genDao);
            var fromDB = db.Genders.Where(m => m.Name.Equals(genDao.Name)).FirstOrDefault();
            if(fromDB != null)
            {
                gen.Active = fromDB.Active;
                gen.GenderId = fromDB.GenderId;                
            }
            else
            {
                gen.Active = true;
            }            
            
            return gen;
        }

    }
}
