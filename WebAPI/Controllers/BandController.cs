using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly DBInterface _db;

        public BandController(DBInterface db)
        {
            _db = db;

        }
        // Gets Band Name
        [HttpGet]
        public async Task<List<string>> GetAll(int bandId)
        {
            return await _db.GetAllBandNames(bandId);
        }

        // GET api/<BandController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BandController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
