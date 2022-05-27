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

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var band = this.CreateBand();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
