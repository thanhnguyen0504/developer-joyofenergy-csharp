using System;
using System.Collections.Generic;
using JOIEnergy.Infrastructure.Repository;
using JOIEnergy.Domain.Enums;
using JOIEnergy.Domain.Models;
using System.Linq;

namespace JOIEnergy.Services
{
    public class NewAccountService: IAccountService
    {
        private readonly IRepository<ElectricitySmartMeter> repository;

        public NewAccountService(IRepository<ElectricitySmartMeter> repo) {
            repository = repo;
        }

        public Supplier GetPricePlanIdForSmartMeterId(string smartMeterId) {

            var smartMeter = repository.GetWhere(x => x.SmartMeterID == smartMeterId).SingleOrDefault();

            if (smartMeter != null)
            {
                return smartMeter.PowerSupplier;
            }

            return Supplier.NullSupplier;
        }
    }
}
