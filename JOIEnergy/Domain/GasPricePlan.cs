using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Enums;

namespace JOIEnergy.Domain
{
    public class GasPricePlan : EnergyPricePlan
    {
        public Supplier EnergySupplier { get; set; }
        public decimal UnitRate { get; set; }
        public IList<PeakTimeMultiplier> PeakTimeMultiplier { get; set;}

        public override decimal GetPrice(DateTime datetime) {
            const decimal godenTimeRate = 1.5m;
            var startGoldenTime = new TimeSpan(19, 0, 0);
            var endGoldenTime = new TimeSpan(20, 0, 0);

            if (datetime.TimeOfDay >= startGoldenTime && datetime.TimeOfDay <= endGoldenTime) {
                return UnitRate * godenTimeRate;
            } else {
                return UnitRate;
            }
        }
    }
}
