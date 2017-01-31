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
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/gender")]
    public class GenderController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public static AccessHelper helper = new AccessHelper();
        // GET: api/Gender
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GenderDao> Get()
        {
            return helper.GetGenders();
        }

        // GET: api/Gender/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetById")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var a = helper.GetGenders().Where(x => x.Name == id).First();
            return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
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
