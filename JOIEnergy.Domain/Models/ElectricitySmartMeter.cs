using JOIEnergy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOIEnergy.Domain.Models
{
    public class ElectricitySmartMeter : SmartMeterBase
    {
        public ElectricitySmartMeter()
        {

        }

        public ElectricitySmartMeter(string smartMeterID, string Name, Supplier PowerSupplier)
        {
            this.Id = Guid.NewGuid();
            this.SmartMeterID = smartMeterID;
            this.Name = Name;
            this.PowerSupplier = PowerSupplier;
        }
    }
}
