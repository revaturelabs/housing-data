using Housing.Data.Domain;
using Housing.Data.Domain.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Housing.Data.Client.Controllers
{
    public class GenderController : ApiController
    {
        // GET: api/Gender
        public List<GenderDao> Get()
        {
            AccessHelper helper = new AccessHelper();
            return helper.GetGenders();
        }

        // GET: api/Gender/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Gender
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Gender/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Gender/5
        public void Delete(int id)
        {
        }
    }
}
