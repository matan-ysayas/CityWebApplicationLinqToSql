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
        public IHttpActionResult Get(int id)
        {

            return Ok(CityDB.Residents.First((ResidentItem) => ResidentItem.Id == id));
        }

        // POST: api/Residents
        public IHttpActionResult Post([FromBody] Resident value)
        {
            CityDB.Residents.InsertOnSubmit(value);
            CityDB.SubmitChanges();
            return Ok(" item was add");
        }

        // PUT: api/Residents/5
        public IHttpActionResult Put(int id, [FromBody] Resident value)
        {
            Resident residentFound=CityDB.Residents.First((item)=>item.Id == id);
            residentFound.FirstName = value.FirstName;
            residentFound.LastName = value.LastName;
            residentFound.BirthDay = value.BirthDay;
            residentFound.Seniority = value.Seniority;
            CityDB.SubmitChanges();
            return Ok("item was update");
        }

        // DELETE: api/Residents/5
        public IHttpActionResult Delete(int id)
        {
            CityDB.Residents.DeleteOnSubmit(CityDB.Residents.First((item)=>item.Id==id));
            CityDB.SubmitChanges();
            return Ok("iteam was delted");
        }
    }
}
