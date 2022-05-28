using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("GetBandDetails/{bandTitle}")]
        public async Task<Band> GetBandDetails(string bandTitle)
        {
            return await _db.GetBandDetails(bandTitle);
        }

        // GET api/<BandController>/5
        [HttpGet("GetBands")]
        public async Task<List<Band>> GetAllBandDetails()
        {
            return await _db.GetAllBands();
        }

        [HttpGet("GetBandMemLimit/{bandId}")]
        public async Task<int> GetBandMemberLimit(int bandId)
        {
            Band band = await _db.GetMemberLimit(bandId);
            return band.memberLimit;
        }

        // POST api/<BandController>
        [HttpPost]
        public async Task<Band> Post(Band newBand)
        {
            return await _db.CreateBand(newBand);
        }

        // PUT api/<BandController>/5
        [HttpPut]
        public async Task Put(Band changeBand)
        {
            await _db.UpdateBand(changeBand);
        }

        // DELETE api/<BandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
