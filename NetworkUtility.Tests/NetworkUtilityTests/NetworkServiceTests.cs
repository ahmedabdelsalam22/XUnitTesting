using FluentAssertions;
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
    }
}
