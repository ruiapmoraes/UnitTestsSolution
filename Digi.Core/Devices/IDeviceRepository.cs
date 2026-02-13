namespace Digi.Core.Devices;

public interface IDeviceRepository
{
    Task<Device?> GetDeviceIdAsync(int Id, CancellationToken ct);
}