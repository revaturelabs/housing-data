using Housing.Data.Domain;
using Housing.Data.Domain.CRUD;
using Housing.Data.Domain.DataAccessObjects;
using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
                logger.Trace("testing get batches");
                logger.Log(LogLevel.Trace, "update log for batch get");
                if ((a = helper.GetBatches()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "Retrieving Batches");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed");
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
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "from batch get using id");
                if ((a = helper.GetBatches().FirstOrDefault(m => m.Name.Equals(id))) != null)
                {
                    logger.Trace("testing values of a{0} ", a.Name);
                    logger.Log(LogLevel.Trace, "batch get using id");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed, a{0} ", a.Name);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed, handled exception ");
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
            if (batch != null && ModelState.IsValid)
            {
                try
                {
                    logger.Trace("testing insert batch, batch{0}", batch);
                    logger.Log(LogLevel.Trace, "Entered try block for batch insert");
                    if (helper.InsertBatch(batch))
                    {
                        logger.Trace("inserting batch, batch{0}", batch);
                        logger.Log(LogLevel.Trace, "batch inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Batch controller");
                        logger.Log(LogLevel.Error, "Insertion of Batch did not occur, batch{0} ", batch);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Batch controller");
                    logger.Log(LogLevel.Error, "Insert of Batch failed, handled exception batch{0} ", batch);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Batch controller");
            logger.Log(LogLevel.Error, "Insertion of Batch failed, null or whitespace");
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
            if (batch != null && !string.IsNullOrWhiteSpace(id) && ModelState.IsValid)
            {
                try
                {
                    logger.Trace("Update Batch", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.UpdateBatch(id, batch))
                    {
                        logger.Trace("Batch update", id.ToString());
                        logger.Log(LogLevel.Trace, "Updating the Batch");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Batch controller");
                        logger.Log(LogLevel.Error, "Update of Batch did not occur, batch{0} ", batch);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Batch controller");
                    logger.Log(LogLevel.Error, "Update of Batch failed, handled exception batch{0} ", batch);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Batch controller");
            logger.Log(LogLevel.Error, "Update of Batch failed, null or whitespace batch{0} ", batch);
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
                    logger.Trace("Delete Batch", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.DeleteBatch(helper.GetBatches().FirstOrDefault(m => m.Name.Equals(id))))
                    {
                        logger.Trace("Deleting Batch", id.ToString());
                        logger.Log(LogLevel.Trace, "Batch Deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Batch controller");
                        logger.Log(LogLevel.Error, "Deletion of Batch did not occur ");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Batch controller");
                    logger.Log(LogLevel.Error, "Deletion of Batch failed due to a handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Batch controller");
            logger.Log(LogLevel.Error, "Deletion of Batch failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
