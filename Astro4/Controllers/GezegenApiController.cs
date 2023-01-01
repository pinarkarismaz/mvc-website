using Astro4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Astro4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GezegenApiController : ControllerBase
    {
        // GET: api/<GezegenApiController>
         //ApplicationDbContext gz = new ApplicationDbContext();
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GezegenApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GezegenApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GezegenApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GezegenApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
