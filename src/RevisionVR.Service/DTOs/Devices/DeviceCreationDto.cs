using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RevisionVR.Service.DTOs.Devices;

public class DeviceCreationDto
{
    [JsonProperty("deviceId")]
    public long DeviceId { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
}
