using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models;
using Datalayer;
using WebAPI.Controllers;

namespace Tests;

public class BandTests
{
    public Mock<DBInterface> mock = new Mock<DBInterface>();

    [Fact]
    public async Task CreateBand_ControllerCallsDBMethod()
    {
        Band newBand = new Band()
        {
            id = 1,
            bandId = 1,
            //description
            //member list
        };

        mock.Setup(p => p.CreateBand(newBand).ReturnsAsync(memberCheck);
        BandController band = new BandController(mock.Object);
        Band result = await band.Post(newMember);
        Assert.Equal(band, result);
    }
}