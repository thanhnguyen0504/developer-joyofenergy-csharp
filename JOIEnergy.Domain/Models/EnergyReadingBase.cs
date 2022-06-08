using System;
namespace JOIEnergy.Domain.Models
{
    public abstract class EnergyReadingBase
    {
        public virtual Guid Id { get; set; }
        public virtual string? SmartMeterID { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual Decimal Reading { get; set; }

    }   
}
