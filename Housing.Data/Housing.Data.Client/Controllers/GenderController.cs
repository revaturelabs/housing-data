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
    /// Ctrl for Gender CRUD
    /// </summary>
    
    public class GenderController : ApiController
    {        
        private static AccessHelper helper = new AccessHelper();

        // GET: api/Gender
        /// <summary>
        /// Gets a list of genderDao's
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<GenderDao> a;
            try
            {
                if ((a = helper.GetGenders()) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/Gender/5
        /// <summary>
        /// Returns a genderDao with specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json object</returns>      
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            GenderDao a;
            try
            {
                if ((a = helper.GetGenders().FirstOrDefault(m => m.Name.Equals(id))) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/Gender
        /// <summary>
        /// Attempts to insert genderDao
        /// </summary>
        /// <param name="value"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]GenderDao value)
        {
            if (value != null)
            {
                try
                {
                    if (helper.InsertGender(value))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        // PUT: api/Gender/5
        /// <summary>
        /// Attempts to update genderDao of id with data in value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]GenderDao value)
        {
            if (value != null)
            {
                try
                {
                    if (helper.UpdateGender(id, value))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: api/Gender/5
        /// <summary>
        /// Attempts to delete gender with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.DeleteGender(helper.GetGenders().FirstOrDefault(m => m.Name.Equals(id))))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
