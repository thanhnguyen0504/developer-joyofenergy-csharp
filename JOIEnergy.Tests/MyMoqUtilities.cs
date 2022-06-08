using System;
using System.Collections.Generic;

using JOIEnergy.Domain.Enums;
using JOIEnergy.Domain.Models;
using Moq;
using System.Linq;
using JOIEnergy.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace JOIEnergy.Tests
{
    internal static class MyMoqUtilities
    {
        public static JOIEnergyContext MockDbContext(
            List<ElectricitySmartMeter> electricitySmartMeterData = null,
            List<ElectricityReading> electricityReadingData = null,
            List<ElectricityPricePlan> electricityPricePlanData = null
            ) 
        {
            var mockElectricitySmartMeterSet = GetFakeDbSet<ElectricitySmartMeter>(electricitySmartMeterData);
            var mockElectricityReadingSet = GetFakeDbSet<ElectricityReading>(electricityReadingData);
            var mockElectricityPricePlanSet = GetFakeDbSet<ElectricityPricePlan>(electricityPricePlanData);

            var mockContext = new Mock<JOIEnergyContext>();
            mockContext.Setup(m => m.ElectricitySmartMeter).Returns(mockElectricitySmartMeterSet.Object);
            mockContext.Setup(m => m.ElectricityReadings).Returns(mockElectricityReadingSet.Object);
            mockContext.Setup(m => m.ElectricityPricePlan).Returns(mockElectricityPricePlanSet.Object);
            return mockContext.Object;
        }


        public static Mock<DbSet<T>> GetFakeDbSet<T>(List<T> data) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            if (data == null)
            {
                return mockSet;
            }

           
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.AsQueryable().GetEnumerator());

            return mockSet;
        }
    }
}
 