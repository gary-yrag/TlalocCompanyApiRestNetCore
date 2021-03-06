using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiRestFullA.inter;
using ApiRestFullA.Models;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestFullA.Controllers
{
    [Route("Tlaloc/[controller]")]
    public class VvController : Controller
    {

        [HttpGet("getCompany/{id}")]
        public IActionResult getCompany(string id) {
            DataSuin d = new DataSuin();
            Company c = d.getCompany(id);

            return Ok(c);
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
