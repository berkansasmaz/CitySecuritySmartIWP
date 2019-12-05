using Newtonsoft.Json;

namespace CitySecuritySmart.Web.Models
{
    public class VideoAPI
    {
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string LabelCategory { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string StartTimeOffset { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string EndTimeOffset { get; set; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public float Confidence { get; set; }
    }
}