using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RevisionVR.Service.DTOs.Positions;

public class UserPositionCreationDto
{
    [JsonProperty("deviceId")]
    public long DeviceId { get; set; }
    [JsonProperty("main")]
    public string Main { get; set; }
    [JsonProperty("head")]
    public string Head { get; set; }
    [JsonProperty("leftHand")]
    public string LeftHand { get; set; }
    [JsonProperty("rightHand")]
    public string RightHand { get; set; }
}