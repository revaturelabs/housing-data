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
        /// <param name="name"></param>
        /// <returns></returns>
        public string Get(string name)
        {
            return helper.GetBatches().Where( x => x.Name == name).First().ToString();
        }

        // POST: api/Batch
        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        public bool Post([FromBody]BatchDao batch)
        {
            if (batch != null)
            {
                try
                {
                    return helper.InsertBatch(batch);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        // PUT: api/Batch/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="batch"></param>
        public bool Put(string name, [FromBody]BatchDao batch)
        {
            try
            {                
                return helper.UpdateBatch(batch);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE: api/Batch/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public bool Delete(string name)
        {
            try
            {
                BatchDao a = helper.GetBatches().Where(b => b.Name == name).First();
                return helper.DeleteBatch(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
