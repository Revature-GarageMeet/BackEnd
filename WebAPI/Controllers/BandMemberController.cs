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

    // Gets all band member records for a Single band ~Bailey
    [HttpGet("GetAllBandMembers/{bandId}")]
    public async Task<List<User>> GetAll(int bandId)
    {
        return await _dl.GetAllBandMembers(bandId);
    }

    [HttpGet("GetBandMember/{userId}")]
    public async Task<BandMember> GetBandMemberByUserId(int userId) {
        return await _dl.GetBandMember(userId);
    }

    [HttpGet("IsInABand/{userId}")]
    public async Task<bool> GetIfInBand(int userId) {
        return await _dl.IsInABand(userId);
    }

    // Adds a new band member record to the Database
    [HttpPost("AddBandMember")]
    public async Task<BandMember> Post(BandMember newMember)
    {
        newMember.dateJoined = DateTime.UtcNow;
        return await _dl.CreateBandMember(newMember);
    }

    // Removes a band member record from the database
    [HttpDelete("RemoveBandMember/{bandMemId}")]
    public async Task Delete(int bandMemId)
    {
        await _dl.RemoveBandMember(bandMemId);
    }

}