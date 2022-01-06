using CityWebApplicationLinqToSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;




namespace CityWebApplicationLinqToSql.Controllers
{
    public class ResidentsController : ApiController
    {
        static string connecitonString = "Data Source=LAPTOP-E49VKATT;Initial Catalog=City;Integrated Security=True;Pooling=False";
        DataResidentsDataContext CityDB = new DataResidentsDataContext(connecitonString);
        // GET: api/Residents
        public IHttpActionResult Get()
        {
            
            return Ok(CityDB.Residents.ToList());
        }

        // GET: api/Residents/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Residents
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Residents/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Residents/5
        public void Delete(int id)
        {
        }
    }
}
