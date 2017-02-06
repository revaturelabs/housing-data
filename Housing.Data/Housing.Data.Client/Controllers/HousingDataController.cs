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
    /// Ctrl for HousingData CRUD
    /// </summary>
    
    public class HousingDataController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();

        // GET: api/HousingData
        /// <summary>
        /// Gets list of HousingDataDao's
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingDataDao> a;
            try
            {
                if ((a = helper.GetHousingData()) != null)
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

        // GET: api/HousingData/5
        /// <summary>
        /// Get HousingDataDao with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json objects</returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingDataDao a;
            try
            {
                if ((a = helper.GetHousingData().FirstOrDefault(m => m.HousingDataAltId.Equals(id))) != null)
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

        // POST: api/HousingData
        /// <summary>
        /// Attempt to insert housingData
        /// </summary>
        /// <param name="hd"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]HousingDataDao hd)
        {
            if (hd != null)
            {
                try
                {
                    if (helper.InsertHousingData(hd))
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

        // PUT: api/HousingData/5
        /// <summary>
        /// Attempt to update housingData with given id and hd
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hd"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]HousingDataDao hd)
        {
            if (hd != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.UpdateHousingData(id, hd))
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

        // DELETE: api/HousingData/5
        /// <summary>
        /// Attempt to delete housing data with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {

            if (!string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.DeleteHousingData(helper.GetHousingData().FirstOrDefault(m => m.HousingDataAltId.Equals(id))))
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
