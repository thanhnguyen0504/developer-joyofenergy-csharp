using System;
namespace JOIEnergy.Domain
{
    public class GasReading: EnergyReading
    {
        public override DateTime Time { get; set; }
        public override Decimal Reading { get; set; }
    }
}
