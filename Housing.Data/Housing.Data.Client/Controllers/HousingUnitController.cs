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
    /// Ctrl for HousingUnit CRUD
    /// </summary>
   
    public class HousingUnitController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();

        // GET: api/HousingUnit
        /// <summary>
        /// Gets list of housingUnits
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingUnitDao> a;
            try
            {
                if ((a = helper.GetHousingUnits()) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // GET: api/HousingUnit/5
        /// <summary>
        /// Gets housingUnit with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json object</returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingUnitDao a;
            try
            {
                if ((a = helper.GetHousingUnits().FirstOrDefault(m => m.HousingUnitName.Equals(id))) != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, a, "application/json");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // POST: api/HousingUnit
        /// <summary>
        /// Attempts to insert housingUnitDao
        /// </summary>
        /// <param name="hu"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]HousingUnitDao hu)
        {
            if (hu != null)
            {
                try
                {
                    if (helper.InsertHousingUnit(hu))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT: api/HousingUnit/5
        /// <summary>
        /// Attempts to update housingUnitDao with given id and value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hu"></param>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]HousingUnitDao hu)
        {
            if (hu != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.UpdateHousingUnit(id, hu))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: api/HousingUnit/5
        /// <summary>
        /// Attempts to delete housingunit with given id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.DeleteHousingUnit(helper.GetHousingUnits().FirstOrDefault(m => m.HousingUnitName.Equals(id))))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else return Request.CreateResponse(HttpStatusCode.NotModified);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
