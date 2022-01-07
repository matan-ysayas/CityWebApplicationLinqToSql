using CityWebApplicationLinqToSql.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityWebApplicationLinqToSql.Controllers.api
{
    public class SchoolController : ApiController
    {
        static string connecitonString = "Data Source=LAPTOP-E49VKATT;Initial Catalog=City;Integrated Security=True;Pooling=False";
        DataResidentsDataContext cityDB = new DataResidentsDataContext(connecitonString);
        // GET: api/School
        public IHttpActionResult Get()
        {
            return Ok(cityDB.Schools.ToList());
        }

        // GET: api/School/5
        public IHttpActionResult Get(int id)
        {
           
            return Ok(cityDB.Schools.First((item) => item.Id == id));
        }

        // POST: api/School
        public IHttpActionResult Post([FromBody]School value)
        {
            try
            {
                cityDB.Schools.InsertOnSubmit(value);
                cityDB.SubmitChanges();

                return Ok("item was add");
            }
            catch(SqlException ex)
            {
                return Ok(new {ex.Message});
            }
            catch(Exception ex)
            {
                return Ok(new { ex.Message });
            }

        }

        // PUT: api/School/5
        public IHttpActionResult Put(int id, [FromBody]School value)
        {
            try
            {
               School schoolFound=cityDB.Schools.First((item)=>item.Id == id);
                schoolFound.Name = value.Name;
                schoolFound.Street = value.Street;
                schoolFound.NumOfStudent  =value.NumOfStudent;
                schoolFound.Public=value.Public;
                cityDB.SubmitChanges();
                return Ok("item was update");
            }
            catch(SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new {ex.Message });
            }
           
        }

        // DELETE: api/School/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                cityDB.Schools.DeleteOnSubmit(cityDB.Schools.First((item)=>item.Id==id));
                cityDB.SubmitChanges();
                return Ok("item was deleted");
            }
            catch (SqlException ex)
            {
                return Ok(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { ex.Message });
            }

        }
    }
}
