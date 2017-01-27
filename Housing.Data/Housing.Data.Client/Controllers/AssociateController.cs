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
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST: api/Associate
        public bool Post(AssociateDao a, [FromBody]string value)
        {
            if (a != null)
            {
                try
                {
                    return helper.InsertAssociate(a);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        // PUT: api/Associate/5
        public bool Put(int id, [FromBody]string value)
        {
            try
            {
                AssociateDao a = helper.GetAssociates().Where(b => b.AssociateId == id).First();
                return helper.UpdateAssociate(a);
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
        public bool Delete(int id)
        {
            try
            {
                AssociateDao a = helper.GetAssociates().Where(b => b.AssociateId == id).First();
                return helper.DeleteAssociate(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
