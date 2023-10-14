using Newtonsoft.Json;

namespace RevisionVR.Service.DTOs.Devices;

public class DeviceUpdateDto
{
    [JsonProperty("deviceId")]
    public long DeviceId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
}