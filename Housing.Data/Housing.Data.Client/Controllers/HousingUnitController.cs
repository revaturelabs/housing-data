using Housing.Data.Domain;
using Housing.Data.Domain.CRUD;
using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Data.Client.Controllers
{
    public class HousingUnitController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();
        // GET: api/HousingUnit
        public List<HousingUnitDao> Get()
        {
            return helper.GetHousingUnits();
        }

        // GET: api/HousingUnit/5
        public List<HousingUnitDao> Get(int id)
        {
            return helper.GetUnitsByComplex(id);
        }

        // POST: api/HousingUnit
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HousingUnit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HousingUnit/5
        public void Delete(int id)
        {
        }
    }
}
