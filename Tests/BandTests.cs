using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore; //dotnet add package Microsoft.EntityFrameworkCore.Sqlite

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Models;
using Datalayer;
using WebAPI.Controllers;

namespace Datalayer
{
    public class BandTests
    {
        private MockRepository mockRepository;

        public Mock<DBInterface> mock = new Mock<DBInterface>();
        private readonly DbContextOptions<GMDBContext> options;

        private void Seed()
        {
            //this method sets up the db and ensures that the db is reset every time we test
            using (var context = new GMDBContext(options))
            {
                //methods are self explanatory what they do, delete -> create -> save
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //adding a default to the db, this is used to test below
                context.Bands.Add(
                    new Band()
                    {
                        id = 1,
                        title = "test",
                        description = "band",
                        memberLimit = 1
                    }
                );
                context.SaveChanges();
            }
        }

        public BandTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            //set options up to use a sqlite db called test.db
            options = new DbContextOptionsBuilder<GMDBContext>()
                    .UseSqlite("Filename=band.db").Options;
            //call next method below
            Seed();

        }

        private Band CreateBand()
        {
            return new Band();
        }

        //Model
        [Fact]
        public void GetSetBandId()
        {
            Band test = new Band();
            test.id = 1;
            Assert.Equal(1, test.id);
        }

        [Fact]
        public void GetSetBandTitle()
        {
            Band test = new Band();
            test.title = "1";
            Assert.Equal("1", test.title);
        }

        [Fact]
        public void GetSetBandDesc()
        {
            Band test = new Band();
            test.description = "1";
            Assert.Equal("1", test.description);
        }

        [Fact]
        public void GetSetBandMemberLimit()
        {
            Band test = new Band();
            test.memberLimit = 1;
            Assert.Equal(1, test.memberLimit);
        }

        [Fact]
        public void DBCreateBand()
        {
            using (var context = new GMDBContext(options))
            {
                DBInterface repo = new DatabaseCalls(context);
                Band test = new Band()
                {
                    id = 2,
                    title = "test",
                    description = "band",
                    memberLimit = 1
                };
                repo.CreateBand(test);
            }

            using (var context = new GMDBContext(options))
            {
                Band test = context.Bands.FirstOrDefault(r => r.id == 2);
                Assert.NotNull(test);
                Assert.Equal("test", test.title);
                Assert.Equal("band", test.description);
                Assert.Equal(1, test.memberLimit);
            }
        }
        [Fact]
        public void UpdateBand()
        {
            using (var context = new GMDBContext(options))
            {
                DBInterface repo = new DatabaseCalls(context);
                Band test = new Band()
                {
                    id = 1,
                    title = "test",
                    description = "test2",
                    memberLimit = 1
                };
                repo.UpdateBand(test);
            }
            using (var context = new GMDBContext(options))
            {
                Band test = context.Bands.FirstOrDefault(r => r.id == 1);
                Assert.NotNull(test);
                Assert.Equal("test", test.title);
                Assert.Equal("test2", test.description);
                Assert.Equal(1, test.memberLimit);
            }
        }
    }


    /*
        UNTESTED:
        get memberlist
        get band (id)
        get all bands
        delete band
    */
}
