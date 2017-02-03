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
    
    public class BatchController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public static AccessHelper helper = new AccessHelper();
        // GET: api/Batch
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BatchDao> Get()
        {
            return helper.GetBatches();
        }

        // GET: api/Batch/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>                 
        public HttpResponseMessage Get(string id)
        {
            var a = helper.GetBatches().FirstOrDefault( x => x.Name == id);
            return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
        }

        // POST: api/Batch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]BatchDao batch)
        {
            if (batch != null)
            {
                try
                {
                    if(helper.InsertBatch(batch))
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
        /// 
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
        /// 
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
