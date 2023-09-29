using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.NetworkUtility.DNS;
using SW.Payroll.NetworkUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SW.Payroll.Tests.NetworkUtilityTests
{
    public class NetworkServiceTests
    {
        NetworkService _networkService;
        private readonly IDNS _dNS;

        public NetworkServiceTests()
        {
            _dNS = A.Fake<IDNS>();
            // system under test (SUT)
           _networkService = new NetworkService(_dNS);
        }
        [Fact]
        public void NetworkService_PingSent_ReturnsString()
        {
            //Arrange
            A.CallTo(() => _dNS.SendDNS()).Returns(true);
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
        [Fact]
        public void NetworkService_GetPingOptions_ReturnsPingOptionsObj()
        {
            //Arrange
            PingOptions expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            PingOptions actual = _networkService.GetPingOptions();

            //Assert
            actual.Should().BeEquivalentTo(expected); //to compare between to object .. use "BeEquivalentTo"
            //actual.Should().BeOfType<PingOptions>(); // another way to compare objects
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnListOfPingOptions()
        {
            //Arrange
            IEnumerable<PingOptions> expected = new List<PingOptions>()
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = false,
                    Ttl = 2
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 3
                },
            };
            //Act 
            IEnumerable<PingOptions> actual = _networkService.MostRecentPings();
            //Assert
            actual.Should().BeOfType<List<PingOptions>>();
            actual.Should().BeEquivalentTo(expected); // to compare two collections
            actual.Should().Contain(x => x.DontFragment == true);
        }
    }
}
