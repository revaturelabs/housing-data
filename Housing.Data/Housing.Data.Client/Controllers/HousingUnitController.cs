﻿using Housing.Data.Domain;
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
   
    public class HousingUnitController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();
        // GET: api/HousingUnit
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<HousingUnitDao> Get()
        {
            return helper.GetHousingUnits();
        }

        // GET: api/HousingUnit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string id)
        {
            List<HousingUnitDao> a = helper.GetUnitsByComplex(id);
            return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
        }

        // POST: api/HousingUnit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hu"></param>
        /// <returns></returns>
        public bool Post([FromBody]HousingUnitDao hu)
        {
            if (hu != null)
            {
                try
                {
                    return helper.InsertHousingUnit(hu);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        // PUT: api/HousingUnit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hu"></param>
        public bool Put(string id, [FromBody]HousingUnitDao hu)
        {
            try
            {
                HousingUnitDao a = helper.GetHousingUnits().Where(b => b.HousingUnitName == id).First();
                return helper.UpdateHousingUnit(a);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE: api/HousingUnit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(string id)
        {
            try
            {
                HousingUnitDao a = helper.GetHousingUnits().Where(b => b.HousingUnitName == id).First();
                return helper.DeleteHousingUnit(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
