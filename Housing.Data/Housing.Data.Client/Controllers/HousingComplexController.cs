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
    [RoutePrefix("api/housingcomplex")]
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
        [Route("GetById")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var a = helper.GetHousingComplexes().Where(x => x.Name == id).First();
            return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
        }

        // POST: api/HousingComplex
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hc"></param>
        /// <returns></returns>
        public bool Post([FromBody]HousingComplexDao hc)
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
        public bool Put(string name, [FromBody]string value)
        {
            try
            {
                HousingComplexDao hc = helper.GetHousingComplexes().Where(b => b.Name == name).First();
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
        public bool Delete(string name)
        {
            try
            {
                HousingComplexDao a = helper.GetHousingComplexes().Where(b => b.Name == name).First();
                return helper.DeleteHousingComplex(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
