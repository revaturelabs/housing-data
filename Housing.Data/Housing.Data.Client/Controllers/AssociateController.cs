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
    public class AssociateController : ApiController
    {
        public static AccessHelper helper = new AccessHelper();
        // GET: api/Associate
        public List<AssociateDao> Get()
        {
            return helper.GetAssociates();
        }

        // GET: api/Associate/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Associate
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Associate/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Associate/5
        public void Delete(int id)
        {
        }
    }
}
