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
        public HttpResponseMessage Get(string id)
        {
            var a = helper.GetGenders().Where(x => x.Name == id).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
        }

        // POST: api/Gender
        [HttpPost]
        public HttpResponseMessage Post([FromBody]GenderDao value)
        {
            if (helper.InsertGender(value))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            
        }

        // PUT: api/Gender/5
        public HttpResponseMessage Put(string id, [FromBody]GenderDao value)
        {
            if(helper.UpdateGender(id, value))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: api/Gender/5
        public HttpResponseMessage Delete(string id)
        {
            if (helper.DeleteGender(helper.GetGenders().Where(m => m.Name.Equals(id)).FirstOrDefault()))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
