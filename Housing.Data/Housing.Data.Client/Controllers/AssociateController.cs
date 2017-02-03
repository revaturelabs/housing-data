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
{   /// <summary>
    /// 
    /// </summary>
    
    public class AssociateController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public static AccessHelper helper = new AccessHelper();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/Associate
        public List<AssociateDao> Get()
        {
            return helper.GetAssociates();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Associate/5
        public HttpResponseMessage Get(string id)
        {
            var a = helper.GetAssociates().FirstOrDefault( x => x.Email.Equals(id));
            return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>       
        /// <returns></returns>
        // POST: api/Associate
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assoc"></param>
        /// <returns></returns>
        // PUT: api/Associate/5
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Associate/5
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
