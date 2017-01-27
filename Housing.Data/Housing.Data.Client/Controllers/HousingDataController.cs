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
    public class HousingDataController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();
        // GET: api/HousingData
        public List<HousingDataDao> Get()
        {
            return helper.GetHousingData();
        }

        // GET: api/HousingData/5
        public List<HousingDataDao> Get(int id)
        {
            return helper.GetDataByUnit(id);
        }

        // POST: api/HousingData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hd"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Post(HousingDataDao hd, [FromBody]string value)
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
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Put(string name, [FromBody]string value)
        {
            try
            {
                HousingDataDao a = helper.GetHousingData().Where(b => b.Name == name).First();
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
        public bool Delete(string name)
        {

            try
            {
                HousingDataDao a = helper.GetHousingData().Where(b => b.Name == name).First();
                return helper.DeleteHousingData(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
