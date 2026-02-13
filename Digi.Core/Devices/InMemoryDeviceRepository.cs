using Digi.Core.Devices;

namespace Digi.Core.Devices;

public sealed class  InMemoryDeviceRepository : IDeviceRepository
{
    private static readonly List<Device> _db =
    [
        new(1, "Tracker A"),
        new(2, "Tracker B"),
        new(3, "Tracker C")
    ];

    public Task<Device> GetDeviceIdAsync(int id, CancellationToken ct)
        => Task.FromResult(_db.FirstOrDefault(x=> x.Id == id));
}