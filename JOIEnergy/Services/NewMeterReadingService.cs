using System;
using System.Collections.Generic;
using JOIEnergy.Domain.Models;
using JOIEnergy.Infrastructure.Repository;
using System.Linq;

namespace JOIEnergy.Services
{
    public class NewMeterReadingService : IMeterReadingService
    {
        private readonly IRepository<ElectricityReading> electricityReadingRepo;
        private readonly IRepository<ElectricitySmartMeter> smartMeterRepo;


        public NewMeterReadingService(IRepository<ElectricityReading> electricityReadingRepo, IRepository<ElectricitySmartMeter> smartMeterRepo)
        {
            this.electricityReadingRepo = electricityReadingRepo;
            this.smartMeterRepo = smartMeterRepo;
        }

        public List<EnergyReadingBase> GetReadings(string smartMeterId)
        {
            var readings = electricityReadingRepo.Find(x => x.SmartMeterID == smartMeterId).ToList<EnergyReadingBase>();
            if(readings  != null && readings.Count() > 0)
            {
                return readings;
            } 
            else
            {
                return new List<EnergyReadingBase>();
            }
            
        }
        void IMeterReadingService.StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings)
        {
            if(smartMeterRepo.GetWhere(x => x.SmartMeterID == smartMeterId).SingleOrDefault() != null)
            {
                electricityReadings = electricityReadings.Select(x => new ElectricityReading(smartMeterId, x.Time, x.Reading)).ToList();
                electricityReadingRepo.AddRange(electricityReadings);
                electricityReadingRepo.SaveChanges();
            }
        }
    }
}
