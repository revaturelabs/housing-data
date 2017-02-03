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
{   /// <summary>
    /// 
    /// </summary>
    
    public class AssociateController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
            logger.Trace("testing get");
            logger.Log(LogLevel.Trace, "update log from associate get");
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
            logger.Trace("testing get id", id);
            logger.Log(LogLevel.Trace, "update log from associate get using id");
            var a = helper.GetAssociates().Where( x => x.Email == id).First();
            logger.Trace("testing values of a{0}", a);
            logger.Log(LogLevel.Trace, "update log from associate get using id");
            return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>       
        /// <returns></returns>
        // POST: api/Associate
        public bool Post([FromBody]AssociateDao a)
        {
            logger.ConditionalTrace(a = null);
            logger.Log(LogLevel.Debug, "Checking if a{0} is null");
            if (a != null)
            {
                try
                {
                    logger.Debug("trying to insert Associate, a {0}", a);
                    logger.Log(LogLevel.Debug, "Entered try block");
                    return helper.InsertAssociate(a);
                }
                catch (Exception)
                {
                    logger.Debug("Failed to insert Associate, a {0}", a);
                    logger.Log(LogLevel.Info, "Log info updated, a {0}", a);
                    return false;
                }
            }
            logger.Log(LogLevel.Info, "Log info updated, a {0}", a);
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assoc"></param>
        /// <returns></returns>
        // PUT: api/Associate/5
        public bool Put(string id, [FromBody]AssociateDao assoc)
        {
            try
            {                
                return helper.UpdateAssociate(assoc);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Associate/5
        public bool Delete(string id)
        {
            try
            {
                AssociateDao a = helper.GetAssociates().Where(b => b.Email == id).First();
                return helper.DeleteAssociate(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
