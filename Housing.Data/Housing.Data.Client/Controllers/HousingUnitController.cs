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
        public List<HousingUnitDao> Get(string id)
        {
            return helper.GetUnitsByComplex(id);
        }

        // POST: api/HousingUnit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hu"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Post(HousingUnitDao hu, [FromBody]string value)
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
        /// <param name="value"></param>
        public bool Put(string name, [FromBody]string value)
        {
            try
            {
                HousingUnitDao a = helper.GetHousingUnits().Where(b => b.HousingUnitName == name).First();
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
        public bool Delete(string name)
        {
            try
            {
                HousingUnitDao a = helper.GetHousingUnits().Where(b => b.HousingUnitName == name).First();
                return helper.DeleteHousingUnit(a);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
