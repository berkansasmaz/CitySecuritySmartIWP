using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitySecuritySmart.Entity
{
    public class CSSDDangerLabel
    {
		[Key]
        public Guid DangerLabelId { get; set; }
		public string DangerLabelName { get; set; }
    }
}