using Digi.Core.Geofences;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digi.Tests.Unit;

public class GeofenceDecisionTests
{
    [Fact]
    public void Should_Return_Entered_When_WasOutside_And_NowInside()
    {
        var ev = GeofenceDecision.Decide(wasInside: false, isInside: true);
        ev.Should().Be(GeofenceEvent.Entered);
    }

    [Fact]
    public void Should_Return_Exited_When_WasInside_And_NowOutside()
    {
        var ev = GeofenceDecision.Decide(wasInside: true, isInside: false);
        ev.Should().Be(GeofenceEvent.Exited);
    }

    [Fact]
    public void Should_Return_None_When_NoChange()
    {
        GeofenceDecision.Decide(false, false).Should().Be(GeofenceEvent.None);
        GeofenceDecision.Decide(true, true).Should().Be(GeofenceEvent.None);
    }
}
