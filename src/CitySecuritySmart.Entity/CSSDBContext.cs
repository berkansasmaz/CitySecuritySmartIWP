using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CitySecuritySmart.Entity {

    public class CSSDBContext: IdentityDbContext <CSSUser, IdentityRole <Guid> , Guid > 
    {
        public CSSDBContext(DbContextOptions options): base(options) 
        {
        }

		 	 public DbSet<CSSDMonitor> Monitors {get; set;}
			  public DbSet<CSSDDangerLabel> DangerLabels { get; set; }
    }

}