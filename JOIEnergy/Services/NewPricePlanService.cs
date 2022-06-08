using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Models;
using JOIEnergy.Infrastructure.Repository;

namespace JOIEnergy.Services
{
    public class NewPricePlanService : IPricePlanService
    {
        public interface Debug { void Log(string s); };

        private IMeterReadingService _meterReadingService;
        private IRepository<ElectricityPricePlan> _pricePlanRepo;

        public NewPricePlanService(IRepository<ElectricityPricePlan> pricePlanRepo, IMeterReadingService meterReadingService)
        {
            _pricePlanRepo = pricePlanRepo;
            _meterReadingService = meterReadingService;
        }

        private decimal calculateAverageReading(List<EnergyReadingBase> electricityReadings)
        {
            var newSummedReadings = electricityReadings.Select(readings => readings.Reading).Aggregate((reading, accumulator) => reading + accumulator);

            return newSummedReadings / electricityReadings.Count();
        }

        private decimal calculateTimeElapsed(List<EnergyReadingBase> electricityReadings)
        {
            var first = electricityReadings.Min(reading => reading.Time);
            var last = electricityReadings.Max(reading => reading.Time);

            return (decimal)(last - first).TotalHours;
        }
        private decimal calculateCost(List<EnergyReadingBase> electricityReadings, ElectricityPricePlan pricePlan)
        {
            var average = calculateAverageReading(electricityReadings);
            var timeElapsed = calculateTimeElapsed(electricityReadings);
            var averagedCost = average / timeElapsed;
            return averagedCost * pricePlan.UnitRate;
        }

        public Dictionary<String, decimal> GetConsumptionCostOfElectricityReadingsForEachPricePlan(String smartMeterId)
        {
            List<EnergyReadingBase> readings = _meterReadingService.GetReadings(smartMeterId);

            if (!readings.Any())
            {
                return new Dictionary<string, decimal>();
            }


            

            return _pricePlanRepo.All().ToDictionary(plan => plan.EnergySupplier.ToString(), plan => calculateCost(readings, plan));
        }



    }
}
