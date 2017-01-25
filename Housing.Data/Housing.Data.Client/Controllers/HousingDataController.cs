using Housing.Data.Domain.DataAccessObjects;
using Housing.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Housing.Data.Domain.CRUD;

namespace Housing.Data.Client.Controllers
{
    public class HousingDataController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();
        // GET: api/HousingData
        public List<HousingDataDao> Get()
        {
            return helper.GetHousingData();
        }

        // GET: api/HousingData/5
        public List<HousingDataDao> Get(int id)
        {
            return helper.GetDataByUnit(id);
        }

        // POST: api/HousingData
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HousingData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HousingData/5
        public void Delete(int id)
        {
        }
    }
}
