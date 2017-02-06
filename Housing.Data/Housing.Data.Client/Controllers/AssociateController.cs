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
    /// Ctrl for Associate CRUD
    /// </summary>
    public class AssociateController : ApiController
    {        
        private static AccessHelper helper = new AccessHelper();

        /// <summary>
        /// Gets list of associateDao's
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        // GET: api/Associate
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<AssociateDao> a;
            try
            {
                if ((a = helper.GetAssociates()) != null)
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

        /// <summary>
        /// Gets an associateDao with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json object</returns>
        // GET: api/Associate/5
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            AssociateDao a;
            try
            {
                if ((a = helper.GetAssociates().FirstOrDefault(m => m.Email.Equals(id))) != null)
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

        /// <summary>
        /// Attempts to insert associateDao
        /// </summary>
        /// <param name="a"></param>       
        /// <returns>HttpStatusCode</returns>
        // POST: api/Associate
        [HttpPost]
        public HttpResponseMessage Post([FromBody]AssociateDao a)
        {
            if (a != null)
            {
                try
                {
                    if (helper.InsertAssociate(a))
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

        /// <summary>
        /// Attempts to update associateDao with given id and value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assoc"></param>
        /// <returns>HttpStatusCode</returns>
        // PUT: api/Associate/5
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]AssociateDao assoc)
        {
            if (assoc != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.UpdateAssociate(id, assoc))
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

        /// <summary>
        /// Attempts to delete associateDao with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode</returns>
        // DELETE: api/Associate/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.DeleteAssociate(helper.GetAssociates().FirstOrDefault(m => m.Email.Equals(id))))
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
