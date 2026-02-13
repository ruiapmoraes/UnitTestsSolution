namespace Digi.Core.Geofences;

public enum GeofenceEvent
{
    None,
    Entered,
    Exited
}

public static class GeofenceDecision
{
    public static GeofenceEvent Decide(bool wasInside, bool isInside)
     => (wasInside, isInside) switch
     {
         (false, true) => GeofenceEvent.Entered,
         (true, false) => GeofenceEvent.Exited,
         _ => GeofenceEvent.None
     };
}

