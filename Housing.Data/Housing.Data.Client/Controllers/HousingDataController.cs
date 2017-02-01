using Housing.Data.Domain.DataAccessObjects;
using Housing.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Housing.Data.Domain.CRUD;

namespace Housing.Data.Client.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    
    public class HousingDataController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();
        // GET: api/HousingData
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<HousingDataDao> Get()
        {
            return helper.GetHousingData();
        }

        // GET: api/HousingData/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string id)
        {
            List<HousingDataDao> a = helper.GetDataByUnit(id);
            return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
        }

        // POST: api/HousingData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hd"></param>
        /// <returns></returns>
        public bool Post([FromBody]HousingDataDao hd)
        {
            if (hd != null)
            {
                try
                {
                    return helper.InsertHousingData(hd);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        // PUT: api/HousingData/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hd"></param>
        /// <returns></returns>
        public bool Put(string id, [FromBody]HousingDataDao hd)
        {
            try
            {
                HousingDataDao a = helper.GetHousingData().Where(b => b.HousingDataAltId == id).First();
                return helper.UpdateHousingData(a);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE: api/HousingData/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {

            try
            {
                HousingDataDao a = helper.GetHousingData().Where(b => b.HousingDataAltId == id).First();
                return helper.DeleteHousingData(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
