using System;
namespace JOIEnergy.Domain
{
    public abstract class EnergyReading
    {
        public abstract DateTime Time { get; set; }
        public abstract Decimal Reading { get; set; }

    }   
}
