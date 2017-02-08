using Housing.Data.Domain.DataAccessObjects;
using Housing.Data.Domain;
using System;
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
    /// Ctrl for HousingData CRUD
    /// </summary>
    
    public class HousingDataController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: api/HousingData
        /// <summary>
        /// Gets list of HousingDataDao's
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingDataDao> a;
            try
            {
                logger.Trace("testing get housing data");
                logger.Log(LogLevel.Trace, "Entering try block in housing data get");
                if ((a = helper.GetHousingData()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "Getting Housing Data");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingData controller");
                logger.Log(LogLevel.Error, "Retrieval of housing data failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingComplex controller");
                logger.Log(LogLevel.Error, "Retrieval of complex failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/HousingData/5
        /// <summary>
        /// Get HousingDataDao with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json objects</returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingDataDao a;
            try
            {
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "Entering try block in get by id");
                if ((a = helper.GetHousingData().FirstOrDefault(m => m.HousingDataAltId.Equals(id))) != null)
                {
                    logger.Trace("testing get by id", id.ToString());
                    logger.Log(LogLevel.Trace, "getting housing data using id");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in HousingData controller");
                logger.Log(LogLevel.Error, "Retrieval of housing data by id failed, a{0} ", a.HousingDataAltId);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in HousingData controller");
                logger.Log(LogLevel.Error, "Retrieval of housing data by id failed, handled exception");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/HousingData
        /// <summary>
        /// Attempt to insert housingData
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]HousingDataDao hd)
        {
            if (hd != null)
            {
                try
                {
                    logger.Trace("testing insert housing data, hd{0}", hd);
                    logger.Log(LogLevel.Trace, "Entered try block of housing data insert");
                    if (helper.InsertHousingData(hd))
                    {
                        logger.Trace("Inserting housing data, hd{0}", hd);
                        logger.Log(LogLevel.Trace, "HousingData Inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingData controller");
                        logger.Log(LogLevel.Error, "Insertion of housing data did not occur, hd{0} ", hd);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingData controller");
                    logger.Log(LogLevel.Error, "Insert of housing data failed, handled exception hd{0} ", hd);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingData controller");
            logger.Log(LogLevel.Error, "Insertion of housing data failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT: api/HousingData/5
        /// <summary>
        /// Attempt to update housingData with given id and hd
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hd"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]HousingDataDao hd)
        {
            if (hd != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    logger.Trace("Update housing data", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.UpdateHousingData(id, hd))
                    {
                        logger.Trace("Updating housing data", id.ToString());
                        logger.Log(LogLevel.Trace, "Housing data Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingData controller");
                        logger.Log(LogLevel.Error, "Update of housing data did not occur, hd{0}", hd);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingData controller");
                    logger.Log(LogLevel.Error, "Update of housing data failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingData controller");
            logger.Log(LogLevel.Error, "Update of housing data failed, null or whitespace");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: api/HousingData/5
        /// <summary>
        /// Attempt to delete housing data with given id
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
                    logger.Trace("Delete HousingData", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.DeleteHousingData(helper.GetHousingData().FirstOrDefault(m => m.HousingDataAltId.Equals(id))))
                    {
                        logger.Trace("Deleting HousingData", id.ToString());
                        logger.Log(LogLevel.Trace, "HousingData deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in HousingData controller");
                        logger.Log(LogLevel.Error, "Deletion of housing data did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in HousingData controller");
                    logger.Log(LogLevel.Error, "Deletion of housing data failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in HousingData controller");
            logger.Log(LogLevel.Error, "Deletion of housing data failed, null or whitespace ");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
