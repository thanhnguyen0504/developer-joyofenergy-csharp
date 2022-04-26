using System;
using System.Collections.Generic;

namespace JOIEnergy.Domain
{
    public class MeterReadings
    {
        public string SmartMeterId { get; set; }
        public List<EnergyReading> ElectricityReadings { get; set; }
    }
}
