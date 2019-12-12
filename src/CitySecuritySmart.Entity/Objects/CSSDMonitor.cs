using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitySecuritySmart.Entity
{
	 [Table("Monitor")]
    public class CSSDMonitor
    {
        [Key]
        public Guid MonitorId { get; set; }
		public Guid UserId { get; set; }
		public string Uri { get; set; }
		public string Url { get; set; }
        public string Name { get; set; }
		public string Label { get; set; }
		public string LabelCategory { get; set; }
		public int DangerLevel { get; set; }
		public string StartTimeOffset { get; set; }
		public string EndTimeOffset { get; set; }
		public float Confidence { get; set; }
    }
}