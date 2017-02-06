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
    /// Ctrl to access crud functions for batches.
    /// </summary>
    public class BatchController : ApiController
    {        
        private static AccessHelper helper = new AccessHelper();


        // GET: api/Batch
        /// <summary>
        /// Returns a list of BatchDao's
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<BatchDao> a;
            try
            {
                if ((a = helper.GetBatches()) != null)
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

        // GET: api/Batch/5
        /// <summary>
        /// Returns a batchDao with the specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json object</returns>            
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            BatchDao a;
            try
            {
                if ((a = helper.GetBatches().FirstOrDefault(m => m.Name.Equals(id))) != null)
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

        // POST: api/Batch
        /// <summary>
        /// Attempts to insert a batchDao and returns the status code
        /// </summary>
        /// <param name="batch"></param>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]BatchDao batch)
        {
            if (batch != null)
            {
                try
                {
                    if (helper.InsertBatch(batch))
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

        // PUT: api/Batch/5
        /// <summary>
        /// Attempts to update a batchDao and returns a status code
        /// </summary>
        /// <param name="id"></param>
        /// <param name="batch"></param>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]BatchDao batch)
        {
            if (batch != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.UpdateBatch(id, batch))
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

        // DELETE: api/Batch/5
        /// <summary>
        /// Attempts to delete a batchDao and returns a status code
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.DeleteBatch(helper.GetBatches().FirstOrDefault(m => m.Name.Equals(id))))
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
