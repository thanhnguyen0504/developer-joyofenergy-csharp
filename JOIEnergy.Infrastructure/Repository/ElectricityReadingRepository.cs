using JOIEnergy.Domain.Models;
using System.Linq;

namespace JOIEnergy.Infrastructure.Repository
{
    public class ElectricityReadingRepository : GenericRepositoryBase<ElectricityReading>
    {
        public ElectricityReadingRepository(JOIEnergyContext context) : base(context)
        {

        }
    }
}
