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
    public class BatchController : ApiController
    {
        // GET: api/Batch
        public List<BatchDao> Get()
        {
            AccessHelper helper = new AccessHelper();
            return helper.GetBatches();
        }

        // GET: api/Batch/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Batch
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Batch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Batch/5
        public void Delete(int id)
        {
        }
    }
}
