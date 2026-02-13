using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Digi.Tests.Integration;

public class DevicesEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public DevicesEndpointTests(WebApplicationFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task Should_Return_200_When_Device_Exists()
    {
        var response = await _client.GetAsync("/devices/1");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Should_Return_404_When_Device_Does_Not_Exist()
    {
        var response = await _client.GetAsync("/devices/999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
