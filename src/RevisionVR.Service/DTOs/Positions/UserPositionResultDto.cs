using Newtonsoft.Json;
using RevisionVR.Service.DTOs.Devices;

namespace RevisionVR.Service.DTOs.Positions;

public class UserPositionResultDto
{
    [JsonProperty("id")]
    public long Id { get; set; }
    [JsonProperty("main")]
    public string Main { get; set; }
    [JsonProperty("head")]
    public string Head { get; set; }
    [JsonProperty("leftHand")]
    public string LeftHand { get; set; }
    [JsonProperty("rightHand")]
    public string RightHand { get; set; }
    [JsonProperty("device result")]
    public DeviceResultDto Device { get; set; }
}