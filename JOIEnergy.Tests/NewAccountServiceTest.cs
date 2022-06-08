using System;
using System.Collections.Generic;
//using JOIEnergy.Enums;
using JOIEnergy.Domain.Enums;
using JOIEnergy.Domain.Models;
using JOIEnergy.Services;
using Xunit;
using Moq;
using JOIEnergy.Infrastructure.Repository;
using System.Linq;
using JOIEnergy.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace JOIEnergy.Tests
{
    public class NewAccountServiceTest
    {
        private const Supplier PRICE_PLAN_ID = Supplier.PowerForEveryone;
        private const String SMART_METER_ID = "smart-meter-id";

        private NewAccountService accountService;

        public NewAccountServiceTest()
        {
            var data = new List<ElectricitySmartMeter>
            {
                new ElectricitySmartMeter("smart-meter-0", "Sarah", Supplier.DrEvilsDarkEnergy),
                new ElectricitySmartMeter("smart-meter-1", "Peter", Supplier.DrEvilsDarkEnergy),
                new ElectricitySmartMeter("smart-meter-2", "Charlie", Supplier.DrEvilsDarkEnergy),
                new ElectricitySmartMeter("smart-meter-3", "Andrea", Supplier.TheGreenEco),
                new ElectricitySmartMeter("smart-meter-4", "Alex", Supplier.TheGreenEco)
            };


            var mockContext = MyMoqUtilities.MockDbContext(data);
            var repo = new ElectricitySmartMeterRepository(mockContext);

            accountService = new NewAccountService(repo);
        }

        [Fact]
        public void GivenTheSmartMeterIdReturnsThePricePlanId()
        {
            var result = accountService.GetPricePlanIdForSmartMeterId("smart-meter-0");
            Assert.Equal(Supplier.PowerForEveryone, result);
        }

        [Fact]
        public void GivenAnUnknownSmartMeterIdReturnsANullSupplier()
        {
            var result = accountService.GetPricePlanIdForSmartMeterId("bob-carolgees");
            Assert.Equal(Supplier.NullSupplier, result);
        }
    }
}
