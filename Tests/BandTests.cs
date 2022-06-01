using Models;
using Moq;
using System;
using Xunit;

namespace Datalayer
{
    public class BandTests
    {
        private MockRepository mockRepository;
        public BandTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public Mock<DBInterface> mock = new Mock<DBInterface>();
        
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

<<<<<<< HEAD
        //     // Assert
        //     Assert.True(false);
        //     this.mockRepository.VerifyAll();
        // }
        [Fact]
        public void GetSetBandId()
        {
            Band band = new Band();
            band.id = 1;

            Assert.Equal(1, band.id);
        }
        [Fact]
        public void GetSetBandTitle()
        {
            Band band = new Band();
            band.title = "test";

            Assert.Equal("test", band.title);
        }
        [Fact]
        public void GetSetBandDescription()
        {
            Band band = new Band();
            band.description = "test";

            Assert.Equal("test", band.title);
        }
        [Fact]
        public void GetSetMemberLimit()
        {
            Band band = new Band();
            band.memberLimit = 1;

            Assert.Equal(1, band.memberLimit);
        }
        [Fact]
        public async Task GetAllBandsTest()
        {
            int testBandId = 1;
            List<string> testList = new List<string>();

            mock.Setup(dl => dl.GetAllBandNames()).ReturnsAsync(testList);

            BandController mockPost = new BandController(mock.Object);
            List<string> compare = await mockPost.GetAll(testBandId);

            Assert.Equal(testList, compare);

            mock.Verify(dl => dl.GetAllBandNames());
        }
        [Fact]
        public async void CheckIfNameIsTakenTest()
        {
            string testBandTitle = "test";
            bool testBool = true;

            mock.Setup(dl => dl.CheckIfBandExists(testBandTitle)).ReturnsAsync(testBool);

            BandController mockPost = new BandController(mock.Object);
            bool compare = await mockPost.CheckIfNameIsTaken(testBandTitle);

            Assert.Equal(testBool, compare);

            mock.Verify(dl => dl.CheckIfBandExists(testBandTitle));
        }
        [Fact]
        public async void GetBandDetailsTest()
        {
            
=======
        [Fact]
        public void GetSetBandMemberLimit()
        {
            Band test = new Band();
            test.memberLimit = 1;
            Assert.Equal(1, test.memberLimit);
>>>>>>> a6db8ce8146a329169a9cae966e29de665519283
        }
    }
}
