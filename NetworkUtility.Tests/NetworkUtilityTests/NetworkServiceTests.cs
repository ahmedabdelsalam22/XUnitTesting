using FluentAssertions;
using FluentAssertions.Extensions;
using SW.Payroll.NetworkUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Payroll.Tests.NetworkUtilityTests
{
    public class NetworkServiceTests
    {
        private NetworkService _networkService;

        public NetworkServiceTests()
        {
            // system under test (SUT)
            _networkService = new NetworkService();
        }
        [Fact]
        public void NetworkService_PingSent_ReturnsString()
        {
            //Arrange
            // _networkService -- system under test
            string expected = "Ping Sent";

            //Act
            string actual = _networkService.PingSent();
            //Assert

            // Assert.Equal(expected, actual);
            actual.Should().NotBeEmpty(expected); // from third party (FluentAssertions)
            actual.Should().Be(expected);
            actual.Should().Contain("Ping", Exactly.Once());
        }

        //[Fact]

        //public void NetworkService_PingTimeOut_ReturnsInt()
        //{
        //    //Arrange
             
        //    int x = 1;
        //    int y = 2;
        //    //Act 
        //    int actual = _networkService.PingTimeOut(x, y);
        //    int expected = x + y;
        //    //Assert 
        //    Assert.Equal(expected, actual);
        //    actual.Should().Be(expected);
        //}

        [Theory]
        [InlineData(1, 2, 3)]
        public void NetworkService_PingTimeOut_ReturnsInt(int x, int y, int expected)
        {
            //Arrange

            //Act
            int actual = _networkService.PingTimeOut(x, y);
            //Assert 
            //Assert.Equal(expected, actual);
            actual.Should().Be(expected);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            //Arrange
            DateTime expected = DateTime.Now;
            //Act 
            DateTime actual = _networkService.LastPingDate();
            //Assert
            actual.Should().BeAfter(1.January(2020));
            actual.Should().BeBefore(1.January(2024));

        }
    }
}
