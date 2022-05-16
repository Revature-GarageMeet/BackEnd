using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

// BandMembers Controller
// Created By: Bailey
[Route("[controller]")]
[ApiController]
public class BandMemberController : ControllerBase
{
   private readonly DBInterface _dl;

   public BandMemberController(DBInterface dl)
   {
       _dl = dl;
   }

   // Gets all band members for a Single band ~Bailey
   [HttpGet]
   public async Task<List<BandMember>> GetAll(int bandId)
   {
       return await _dl.GetAllBandMembers(bandId);
   }

   [HttpPost]
   public async Task<BandMember> Post(BandMember newMember)
   {
       newMember.dateJoined = DateTime.UtcNow;
       return await _dl.CreateBandMember(newMember);
   }

   [HttpDelete]
   public async Task Delete(BandMember memberToDelete)
   {
       await _dl.RemoveBandMember(memberToDelete);
   }

}