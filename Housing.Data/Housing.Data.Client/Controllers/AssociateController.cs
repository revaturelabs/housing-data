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
    /// Ctrl for Associate CRUD
    /// </summary>
    public class AssociateController : ApiController
    {        
        private static AccessHelper helper = new AccessHelper();
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
                logger.Trace("testing get");
                logger.Log(LogLevel.Trace, "update log from associate get");
                if ((a = helper.GetAssociates()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "update log from associate get");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Associate controller");
                logger.Log(LogLevel.Error, "Retrieval of Associate failed, a{0} ");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Associate controller");
                logger.Log(LogLevel.Error, "Retrieval of Associate failed, a{0} ");
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
                logger.Trace("testing get id", id.ToString());
                logger.Log(LogLevel.Trace, "from associate get using id");
                if ((a = helper.GetAssociates().FirstOrDefault(m => m.Email.Equals(id))) != null)
                {
                    logger.Trace("testing values of a{0} ", a.Email);
                    logger.Log(LogLevel.Trace, "associate get using id");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Associate controller");
                logger.Log(LogLevel.Error, "Retrieval of Associate failed, a{0} ", a.Email);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Associate controller");
                logger.Log(LogLevel.Error, "Retrieval of Associate failed ");
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
            if (a != null && ModelState.IsValid)
            {
                try
                {
                    if (helper.InsertAssociate(a))
                    {
                        logger.Debug("trying to insert Associate, a{0} ", a);
                        logger.Log(LogLevel.Debug, "Entered try block");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Associate controller");
                        logger.Log(LogLevel.Error, "Insert of Associate failed, a{0} ", a);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Associate controller");
                    logger.Log(LogLevel.Error, "Insert of Associate failed, a{0} ", a);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Associate controller");
            logger.Log(LogLevel.Error, "Insert of Associate failed, a{0} ", a);
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
            if (assoc != null && !string.IsNullOrWhiteSpace(id) && ModelState.IsValid)
            {
                try
                {
                    logger.Debug("trying to update Associate, assoc {0} ", assoc);
                    logger.Log(LogLevel.Debug, "Entered try block updating Associate");
                    if (helper.UpdateAssociate(id, assoc))
                    {
                        logger.Debug("Updating Associate, assoc {0} ", assoc);
                        logger.Log(LogLevel.Debug, "Associate Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Associate controller");
                        logger.Log(LogLevel.Error, "Edit of Associate failed, assoc{0} ", assoc);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Associate Controller");
                    logger.Log(LogLevel.Error, "Edit of Associate failed, a{0} ", assoc);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Associate Controller");
            logger.Log(LogLevel.Error, "Edit of Associate failed, null or whitespace a{0} ", assoc);
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
                    logger.Debug("trying to delete Associate ");
                    logger.Log(LogLevel.Debug, "Entered try block deleting Associate");
                    if (helper.DeleteAssociate(helper.GetAssociates().FirstOrDefault(m => m.Email.Equals(id))))
                    {                 
                        logger.Debug("Deleting Associate ");
                        logger.Log(LogLevel.Debug, "Associate Deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("trying to delete Associate ");
                        logger.Log(LogLevel.Error, "Deletion of Associate did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e,"Error occured in Associate Controller ");
                    logger.Log(LogLevel.Error, "Failed to Delete Associate");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Associate Controller ");
            logger.Log(LogLevel.Error, "Failed to Delete Associate");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
