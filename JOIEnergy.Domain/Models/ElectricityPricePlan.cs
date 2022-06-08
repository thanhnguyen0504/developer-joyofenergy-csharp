using System;
using System.Collections.Generic;
using System.Linq;
//using JOIEnergy.Enums;
using JOIEnergy.Domain.Enums;

namespace JOIEnergy.Domain.Models
{
    // should re-name to ElectricPricePlan extend from EnergyPricePlan
    public class ElectricityPricePlan : EnergyPricePlanBase
    {
        public IList<PeakTimeMultiplier> PeakTimeMultiplier { get; set;}

        public override decimal GetPrice(DateTime datetime) {
            var multiplier = PeakTimeMultiplier.FirstOrDefault(m => m.DayOfWeek == datetime.DayOfWeek);

            if (multiplier?.Multiplier != null) {
                return multiplier.Multiplier * UnitRate;
            } else {
                return UnitRate;
            }
        }
    }


    public class PeakTimeMultiplier
    {
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public decimal Multiplier { get; set; }
        public PeakTimeMultiplier()
        {
            Id = Guid.NewGuid();
        }
    }
}
