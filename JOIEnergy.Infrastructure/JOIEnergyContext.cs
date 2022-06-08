using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JOIEnergy.Infrastructure
{
    public class JOIEnergyContext: DbContext
    {
        public virtual DbSet<ElectricityReading>? ElectricityReadings { get; set; }
        public virtual DbSet<ElectricitySmartMeter>? ElectricitySmartMeter { get; set; }
        public virtual DbSet<ElectricityPricePlan>? ElectricityPricePlan { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlite("Data Source=joienergy.db");
        }

    }
}
