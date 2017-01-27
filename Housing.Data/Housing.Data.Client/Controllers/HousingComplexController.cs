using System;
using Housing.Data.Domain;
using Housing.Data.Domain.DataAccessObjects;
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
    public class HousingComplexController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();

        // GET: api/HousingComplex
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<HousingComplexDao> Get()
        {
            return helper.GetHousingComplexes();
        }

        // GET: api/HousingComplex/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HousingComplex
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hc"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Post(HousingComplexDao hc, [FromBody]string value)
        {
            if (hc != null)
            {
                try
                {
                    return helper.InsertHousingComplex(hc);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        // PUT: api/HousingComplex/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Put(int id, [FromBody]string value)
        {
            try
            {
                HousingComplexDao hc = helper.GetHousingComplexes().Where(b => b.HousingComplexId == id).First();
                return helper.UpdateHousingComplex(hc);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE: api/HousingComplex/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                HousingComplexDao a = helper.GetHousingComplexes().Where(b => b.HousingComplexId == id).First();
                return helper.DeleteHousingComplex(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
