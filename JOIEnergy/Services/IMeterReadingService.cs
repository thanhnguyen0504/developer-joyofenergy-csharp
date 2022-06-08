using System.Collections.Generic;
using JOIEnergy.Domain.Models;

namespace JOIEnergy.Services
{
    public interface IMeterReadingService
    {
        List<EnergyReadingBase> GetReadings(string smartMeterId);
        void StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings);
    }
}