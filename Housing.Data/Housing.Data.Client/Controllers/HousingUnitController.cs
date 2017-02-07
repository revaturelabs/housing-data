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
    /// Ctrl for HousingUnit CRUD
    /// </summary>
   
    public class HousingUnitController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: api/HousingUnit
        /// <summary>
        /// Gets list of housingUnits
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingUnitDao> a;
            try
            {
                logger.Trace("testing get housing units");
                logger.Log(LogLevel.Trace, "Entering try block in housing units get");
                if ((a = helper.GetHousingUnits()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "Getting Housing Units");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingUnit controller");
                logger.Log(LogLevel.Error, "Retrieval of housing units failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingUnit controller");
                logger.Log(LogLevel.Error, "Retrieval of housing units failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/HousingUnit/5
        /// <summary>
        /// Gets housingUnit with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json object</returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingUnitDao a;
            try
            {
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "Entering try block in housing unit get by id");
                if ((a = helper.GetHousingUnits().FirstOrDefault(m => m.HousingUnitName.Equals(id))) != null)
                {
                    logger.Trace("testing get by id", id.ToString());
                    logger.Log(LogLevel.Trace, "getting housing unit using id");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingUnit controller");
                logger.Log(LogLevel.Error, "Retrieval of housing unit by id failed, a{0} ", a.HousingUnitName);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingUnit controller");
                logger.Log(LogLevel.Error, "Retrieval of housing unit by id failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/HousingUnit
        /// <summary>
        /// Attempts to insert housingUnitDao
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]HousingUnitDao hu)
        {
            if (hu != null)
            {
                try
                {
                    logger.Trace("testing insert housing unit, hu{0}", hu);
                    logger.Log(LogLevel.Trace, "Entered try block of housing unit insert");
                    if (helper.InsertHousingUnit(hu))
                    {
                        logger.Trace("Inserting housing unit, hu{0}", hu);
                        logger.Log(LogLevel.Trace, "HousingUnit Inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingUnit controller");
                        logger.Log(LogLevel.Error, "Insertion of housing unit did not occur, hu{0} ", hu);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingUnit controller");
                    logger.Log(LogLevel.Error, "Insert of housing unit failed, handled exception hu{0} ", hu);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingUnit controller");
            logger.Log(LogLevel.Error, "Insertion of housing unit failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT: api/HousingUnit/5
        /// <summary>
        /// Attempts to update housingUnitDao with given id and value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hu"></param>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]HousingUnitDao hu)
        {
            if (hu != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Update housing unit", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.UpdateHousingUnit(id, hu))
                    {
                        logger.Trace("Updating housing unit", id.ToString());
                        logger.Log(LogLevel.Trace, "Housing unit Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingUnit controller");
                        logger.Log(LogLevel.Error, "Update of housing unit did not occur, hu{0}", hu);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingUnit controller");
                    logger.Log(LogLevel.Error, "Update of housing unit failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingUnit controller");
            logger.Log(LogLevel.Error, "Update of housing unit failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: api/HousingUnit/5
        /// <summary>
        /// Attempts to delete housingunit with given id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Delete HousingUnit", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.DeleteHousingUnit(helper.GetHousingUnits().FirstOrDefault(m => m.HousingUnitName.Equals(id))))
                    {
                        logger.Trace("Deleting HousingUnit", id.ToString());
                        logger.Log(LogLevel.Trace, "Housingnit deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingUnit controller");
                        logger.Log(LogLevel.Error, "Deletion of housing unit did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingUnit controller");
                    logger.Log(LogLevel.Error, "Deletion of housing unit failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingUnit controller");
            logger.Log(LogLevel.Error, "Deletion of housing unit failed, null or whitespace ");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
