﻿using System;
namespace JOIEnergy.Domain
{
    public class ElectricityReading: EnergyReading
    {
        public override DateTime Time { get; set; }
        public override Decimal Reading { get; set; }
    }
}
