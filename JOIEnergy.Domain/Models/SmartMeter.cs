using JOIEnergy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOIEnergy.Domain.Models
{
    public abstract class SmartMeterBase
    {
        public virtual Guid Id { get; set; }
        public virtual string? SmartMeterID { get; set; }
        public virtual string? Name { get; set; }
        public virtual Supplier PowerSupplier { get; set; }

    }
}
 