using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Enums;
namespace JOIEnergy.Domain
{
    public abstract class EnergyPricePlan: ISupplier
    {
        public abstract decimal GetPrice(DateTime datetime);
    }
}
