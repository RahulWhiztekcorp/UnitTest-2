﻿using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetworkUtility.Tests.Ping
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnsString()
        {
            // Arrange 
            var pingService = new NetworkService();

            // Art
            var result = pingService.SendPing();
            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());

        }
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,4,2)]
        public void NetworkService_PingTImeout_ReturnInt(int a,int b,int expected)
        {
            // Arrange
            var pingService = new NetworkService();
            // Act
            var result = pingService.PingTImeout(a,b);

            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-1000, 0);


        }
    }
}
