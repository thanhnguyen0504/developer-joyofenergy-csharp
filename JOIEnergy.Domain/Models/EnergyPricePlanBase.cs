using System;
using System.Collections.Generic;
using System.Linq;
//using JOIEnergy.Enums;
using JOIEnergy.Domain.Enums;
namespace JOIEnergy.Domain.Models
{
    public abstract class EnergyPricePlanBase: ISupplier
    {
        public virtual Guid Id { get; set; }
        public virtual Supplier EnergySupplier { get; set; }
        public virtual decimal UnitRate { get; set; }
        public abstract decimal GetPrice(DateTime datetime);
    }
}
