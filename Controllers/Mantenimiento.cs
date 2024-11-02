using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2_FloricelaArguedas_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mantenimiento : ControllerBase
    {
        // GET: api/<Mantenimiento>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Mantenimiento>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Mantenimiento>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Mantenimiento>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Mantenimiento>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
