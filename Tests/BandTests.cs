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
    }
}
