using Newtonsoft.Json;

namespace RevisionVR.Service.DTOs.Positions;

public class UserPositionUpdateDto
{
    [JsonProperty("main")]
    public string Main { get; set; }
    [JsonProperty("head")]
    public string Head { get; set; }
    [JsonProperty("leftHand")]
    public string LeftHand { get; set; }
    [JsonProperty("rightHand")]
    public string RightHand { get; set; }
    //[JsonProperty("deviceId")]
    //public long DeviceId { get; set; }
}