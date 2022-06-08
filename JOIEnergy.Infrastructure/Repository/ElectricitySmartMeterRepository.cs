using JOIEnergy.Domain.Models;
using System.Linq;

namespace JOIEnergy.Infrastructure.Repository
{
    public class ElectricitySmartMeterRepository : GenericRepositoryBase<ElectricitySmartMeter>
    {
        public ElectricitySmartMeterRepository(JOIEnergyContext context) : base(context)
        {

        }
    }
}
