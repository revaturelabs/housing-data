using Housing.Data.Domain;
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
    public class HomeController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/Home
        public List<string> Get()
        {
            List<string> index = new List<string>();
            index.Add("api/Associate for all active Associates");
            index.Add("api/Batch for all active Batches");
            index.Add("api/Gender for all active Genders");
            index.Add("api/HousingComplex for all active HousingComplexes");
            index.Add("api/HousingUnit/[id] for all HousingUnits associated with the HousingComplexId [id]");
            index.Add("api/HousingUnit for all active HousingUnits");
            index.Add("api/HousingData/[id] for all HousingData entries associated with the HousingUnitId [id]");
            index.Add("api/HousingData for all active HousingData entries");
            return index;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Home/5
        public string Get(int id)
        {
            return "value";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        // POST: api/Home
        public void Post([FromBody]string value)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/Home/5
        public void Delete(int id)
        {
        }
    }
}
