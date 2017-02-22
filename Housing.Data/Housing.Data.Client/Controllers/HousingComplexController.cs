using System;
using Housing.Data.Domain;
using Housing.Data.Domain.DataAccessObjects;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Housing.Data.Domain.CRUD;
using NLog;

namespace Housing.Data.Client.Controllers
{
    /// <summary>
    /// Ctrl for HousingComplex CRUD
    /// </summary>

    public class HousingComplexController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: api/HousingComplex
        /// <summary>
        /// Gets a list of housingComplexes
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingComplexDao> a;
            try
            {
                logger.Trace("testing get complex");
                logger.Log(LogLevel.Trace, "Entering try block in complex get");
                if ((a = helper.GetHousingComplexes()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "update log for complex get");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/HousingComplex/5
        /// <summary>
        /// Gets a HousingComplexDao with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json object</returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingComplexDao a;
            try
            {
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "Entering try block in get by id");
                if ((a = helper.GetHousingComplexes().FirstOrDefault(m => m.Name.Equals(id))) != null)
                {
                    logger.Trace("testing get by id", id.ToString());
                    logger.Log(LogLevel.Trace, "getting complex using id");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex by id failed, a{0} ", a.Name);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex by id failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/HousingComplex
        /// <summary>
        /// Attemps to insert HousingComplexDao
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]HousingComplexDao hc)
        {
            if (hc != null && ModelState.IsValid)
            {
                try
                {
                    logger.Trace("testing insert complex, hc{0}", hc);
                    logger.Log(LogLevel.Trace, "Entered try block of complex insert");
                    if (helper.InsertHousingComplex(hc))
                    {
                        logger.Trace("Inserting complex, hc{0}", hc);
                        logger.Log(LogLevel.Trace, "HousingComplex Inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingComplex controller");
                        logger.Log(LogLevel.Error, "Insertion of complex did not occur, hc{0} ", hc);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }

                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingComplex controller");
                    logger.Log(LogLevel.Error, "Insert of complex failed, handled exception hc{0} ", hc);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingComplex controller");
            logger.Log(LogLevel.Error, "Insertion of complex failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT: api/HousingComplex/5
        /// <summary>
        /// Attemps to update HousingComplexDao with given id and value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]HousingComplexDao value)
        {

            if (value != null && !string.IsNullOrWhiteSpace(id) && ModelState.IsValid)
            {
                try
                {
                    logger.Trace("Update complex", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.UpdateHousingComplex(id, value))
                    {
                        logger.Trace("Updating complex", id.ToString());
                        logger.Log(LogLevel.Trace, "Complex Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingComplex controller");
                        logger.Log(LogLevel.Error, "Update of complex did not occur, value{0}", value);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingComplex controller");
                    logger.Log(LogLevel.Error, "Update of complex failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingComplex controller");
            logger.Log(LogLevel.Error, "Update of complex failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: api/HousingComplex/5
        /// <summary>
        /// Attemps to delete HousingComplex with given id
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
                    logger.Trace("Delete HousingComplex", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.DeleteHousingComplex(helper.GetHousingComplexes().FirstOrDefault(m => m.Name.Equals(id))))
                    {
                        logger.Trace("Deleting HousingComplex", id.ToString());
                        logger.Log(LogLevel.Trace, "HousingComplex deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingComplex controller");
                        logger.Log(LogLevel.Error, "Deletion of complex did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingComplex controller");
                    logger.Log(LogLevel.Error, "Deletion of complex failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingComplex controller");
            logger.Log(LogLevel.Error, "Deletion of complex failed, null or whitespace ");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
