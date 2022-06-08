using JOIEnergy.Domain.Models;

namespace JOIEnergy.Infrastructure.Repository
{
    public class ElectricityPricePlanRepository : GenericRepositoryBase<ElectricityPricePlan>
    {
        public ElectricityPricePlanRepository(JOIEnergyContext context) : base(context)
        {

        }
    }
}
