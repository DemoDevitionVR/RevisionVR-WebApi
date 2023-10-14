using Newtonsoft.Json;

namespace RevisionVR.Service.DTOs.Devices;

public class DeviceResultDto
{
    [JsonProperty("id")]
    public long Id { get; set; }
    [JsonProperty("deviceId")]
    public long DeviceId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
}