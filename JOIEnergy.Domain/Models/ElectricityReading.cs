using System;
namespace JOIEnergy.Domain.Models
{
    public class ElectricityReading: EnergyReadingBase
    {
        public ElectricityReading()
        {

        }

        public ElectricityReading(string smartMeterID, DateTime Time, Decimal Reading)
        {
            this.Id = Guid.NewGuid();
            this.SmartMeterID = smartMeterID;
            this.Time = Time;
            this.Reading = Reading;
        }

    }
}
