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
    /// Ctrl for HousingComplex CRUD
    /// </summary>
   
    public class HousingComplexController : ApiController
    {
        private static AccessHelper helper = new AccessHelper();

        // GET: api/HousingComplex
        /// <summary>
        /// Gets a list of housingComplexes
        /// </summary>
        /// <returns>HttpStatusCode and json list</returns>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<HousingComplexDao> a;
            try
            {
                if ((a = helper.GetHousingComplexes()) != null)
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

        // GET: api/HousingComplex/5
        /// <summary>
        /// Gets a HousingComplexDao with given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode and json object</returns>
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            HousingComplexDao a;
            try
            {
                if ((a = helper.GetHousingComplexes().FirstOrDefault(m => m.Name.Equals(id))) != null)
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

        // POST: api/HousingComplex
        /// <summary>
        /// Attemps to insert HousingComplexDao
        /// </summary>
        /// <param name="hc"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]HousingComplexDao hc)
        {
            if (hc != null)
            {
                try
                {
                    if (helper.InsertHousingComplex(hc))
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

        // PUT: api/HousingComplex/5
        /// <summary>
        /// Attemps to update HousingComplexDao with given id and value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]HousingComplexDao value)
        {

            if (value != null && !string.IsNullOrWhiteSpace(id))
            {
                try
                {
                    if (helper.UpdateHousingComplex(id, value))
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

        // DELETE: api/HousingComplex/5
        /// <summary>
        /// Attemps to delete HousingComplex with given id
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
                    if (helper.DeleteHousingComplex(helper.GetHousingComplexes().FirstOrDefault(m => m.Name.Equals(id))))
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
