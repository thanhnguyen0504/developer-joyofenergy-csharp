using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Enums;

namespace JOIEnergy.Domain.Models
{
    public class GasPricePlan : EnergyPricePlanBase
    {
        public Supplier EnergySupplier { get; set; }

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
