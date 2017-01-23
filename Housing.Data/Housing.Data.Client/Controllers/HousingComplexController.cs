using System;
using Housing.Data.Domain;
using Housing.Data.Domain.DataAccessObjects;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Data.Client.Controllers
{
    public class HousingComplexController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();

        // GET: api/HousingComplex
        public List<HousingComplexDao> Get()
        {
            return helper.GetHousingComplexes();
        }

        // GET: api/HousingComplex/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HousingComplex
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HousingComplex/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HousingComplex/5
        public void Delete(int id)
        {
        }
    }
}
