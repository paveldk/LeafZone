﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ImageProcessingServices.Controllers
{
    public class TestController : ApiController
    {
        // GET api/test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/test
        public void Post([FromBody]string value)
        {
        }

        // PUT api/test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/test/5
        public void Delete(int id)
        {
        }
    }
}
