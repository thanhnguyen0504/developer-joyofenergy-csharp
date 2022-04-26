using System.Collections.Generic;
using JOIEnergy.Domain;

namespace JOIEnergy.Services
{
    public interface IMeterReadingService
    {
        List<EnergyReading> GetReadings(string smartMeterId);
        void StoreReadings(string smartMeterId, List<EnergyReading> electricityReadings);
    }
}