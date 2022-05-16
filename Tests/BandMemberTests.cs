using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models;
using Datalayer;
using WebAPI.Controllers;

namespace Tests;

// All BandMember Controller Methods, DBRepo Methods, and Model Property Tests
// Created by: Bailey
public class BandMemberTests
{

    public Mock<DBInterface> mock = new Mock<DBInterface>();

    [Fact]
    public async Task CreateBandMember_ControllerCallsDBMethod()
    {
        BandMember newMember = new BandMember()
        {
            id = 1,
            userId = 1,
            bandId = 1,
            dateJoined = DateTime.UtcNow
        };

        BandMember memberCheck = new BandMember()
        {
            id = 1,
            userId = 1,
            bandId = 1,
            dateJoined = DateTime.UtcNow
        };

        mock.Setup(p => p.CreateBandMember(newMember)).ReturnsAsync(memberCheck);
        BandMemberController bandMem = new BandMemberController(mock.Object);
        BandMember result = await bandMem.Post(newMember);
        Assert.Equal(memberCheck, result);
    }

    [Fact]
    public async Task GetAllBandMembers_ControllerCallsDBMethod()
    {
        List<BandMember> checkBandMembers = new List<BandMember>() {
            new BandMember {
                id = 1,
                userId = 1,
                bandId = 1,
                dateJoined = DateTime.UtcNow
            },
            new BandMember {
                id = 4,
                userId = 3,
                bandId = 1,
                dateJoined = DateTime.UtcNow
            },
            new BandMember {
                id = 5,
                userId = 7,
                bandId = 1,
                dateJoined = DateTime.UtcNow
            }
        };

        mock.Setup(p => p.GetAllBandMembers(1)).ReturnsAsync(checkBandMembers);
        BandMemberController bandMem = new BandMemberController(mock.Object);
        List<BandMember> result = await bandMem.GetAll(1);
        Assert.Equal(checkBandMembers, result);
    }

    [Fact]
    public async Task DeleteBandMember_ControllerCallsDBMethod()
    {
        BandMember deleteBandMem = new BandMember()
        {
            id = 3,
            userId = 9,
            bandId = 2,
            dateJoined = DateTime.UtcNow
        };

        mock.Setup(p => p.RemoveBandMember(deleteBandMem));
        BandMemberController bandMem = new BandMemberController(mock.Object);
        bandMem.Delete(deleteBandMem);
        mock.Verify(p => p.RemoveBandMember(deleteBandMem));
    }

    [Fact]
    public async Task CreateBandMember_DBMethodRecordExists()
    {
        // Test a new BandMember record was added to Azure Database ~Bailey
    }

    [Fact]
    public async Task GetAllBandMembers_DBMethodSpecificRecordsExists()
    {
        // Test all members for a specific Band group are acquired ~Bailey
    }

    [Fact]
    public async Task DeleteBandMember_DBMethodRecordDoesNotExist()
    {
        // Test that a band member no longer exists in the Azure Database ~Bailey
    }

}