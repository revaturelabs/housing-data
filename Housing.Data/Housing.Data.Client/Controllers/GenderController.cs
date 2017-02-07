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
    /// Ctrl for Gender CRUD
    /// </summary>
    
    public class GenderController : ApiController
    {        
        private static AccessHelper helper = new AccessHelper();
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
                logger.Trace("testing get genders");
                logger.Log(LogLevel.Trace, "update log for genders get");
                if ((a = helper.GetGenders()) != null)
                {
                    logger.Trace("testing get");
                    logger.Log(LogLevel.Trace, "Retrieving Genders");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Gender controller");
                logger.Log(LogLevel.Error, "Retrieval of Genders failed, a{0} ", a);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Gender controller");
                logger.Log(LogLevel.Error, "Retrieval of Genders failed, handled exception");
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
                logger.Trace("testing get by id", id.ToString());
                logger.Log(LogLevel.Trace, "from gender get using id");
                if ((a = helper.GetGenders().FirstOrDefault(m => m.Name.Equals(id))) != null)
                {
                    logger.Trace("testing values of a{0} ", a.Name);
                    logger.Log(LogLevel.Trace, "gender get using id");
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                logger.Error("Error occured in Gender controller");
                logger.Log(LogLevel.Error, "Retrieval of Gender failed, a{0} ", a.Name);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                logger.Error(e, "Error occured in Batch controller");
                logger.Log(LogLevel.Error, "Retrieval of Batch failed, handled exception");
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
                    logger.Trace("testing insert gender, value{0}", value);
                    logger.Log(LogLevel.Trace, "Entered try block of gender insert");
                    if (helper.InsertGender(value))
                    {
                        logger.Trace("Inserting Gender, value{0}", value);
                        logger.Log(LogLevel.Trace, "Gender Inserted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Gender controller");
                        logger.Log(LogLevel.Error, "Insertion of Gender did not occur, value{0} ", value);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Gender controller");
                    logger.Log(LogLevel.Error, "Insert of Gender failed, handled exception value{0} ", value);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Gender controller");
            logger.Log(LogLevel.Error, "Insertion of Gender failed, null or whitespace");
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
                    logger.Trace("Update Gender", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.UpdateGender(id, value))
                    {
                        logger.Trace("Updating Gender", id.ToString());
                        logger.Log(LogLevel.Trace, "Gender Updated");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Gender controller");
                        logger.Log(LogLevel.Error, "Update of Gender did not occur, value{0}", value);
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Gender controller");
                    logger.Log(LogLevel.Error, "Update of Gender failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Gender controller");
            logger.Log(LogLevel.Error, "Update of Gender failed, null or whitespace");
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
                    logger.Trace("Delete Gender", id.ToString());
                    logger.Log(LogLevel.Trace, "Entered try block");
                    if (helper.DeleteGender(helper.GetGenders().FirstOrDefault(m => m.Name.Equals(id))))
                    {
                        logger.Trace("Deleting Gender", id.ToString());
                        logger.Log(LogLevel.Trace, "Gender deleted");
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        logger.Error("Error occured in Gender controller");
                        logger.Log(LogLevel.Error, "Deletion of Gender did not occur");
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error occured in Gender controller");
                    logger.Log(LogLevel.Error, "Deletion of Gender failed, handled exception");
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            logger.Error("Error occured in Gender controller");
            logger.Log(LogLevel.Error, "Deletion of Gender failed, null or whitespace ");
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
