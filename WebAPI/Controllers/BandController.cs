using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly DBInterface _dl;

        public BandController(DBInterface dl)
        {
            _dl = dl;

        }
        // Gets Band Name
        [HttpGet("GetAllBands/bandId")]
        public async Task<List<string>> GetAllBands(int bandId)
        {
            return await _dl.GetAllBands(bandId);
        }

     

        // POST api/<BandController>
        [HttpPost("AddBand")]
        public async Task<List<string>> Post(int Id)
        {
            return await _dl.CreateBand(Id); 
        }

        // DELETE api/<BandController>/5
        [HttpDelete("Delete Band")]
        public async void Delete(Band bandToDelete)
        {
            await _dl.DeleteBand(bandToDelete);
        }
    }
}
