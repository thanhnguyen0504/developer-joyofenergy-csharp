using System;
using System.Collections.Generic;
using System.Linq;
// using JOIEnergy.Enums;
using JOIEnergy.Domain.Enums;
using JOIEnergy.Domain.Models;
using JOIEnergy.Infrastructure;
using JOIEnergy.Generator;
using JOIEnergy.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using JOIEnergy.Infrastructure.Repository;

namespace JOIEnergy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            CreateInitialDatabase();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // services.AddTransient<JOIEnergyContext>();
            // services.AddScoped // for every session (request) that will not create new object
            services.AddScoped<JOIEnergyContext>();
            services.AddTransient<IRepository<ElectricityReading>, ElectricityReadingRepository>();
            services.AddTransient<IRepository<ElectricitySmartMeter>, ElectricitySmartMeterRepository>();
            services.AddTransient<IRepository<ElectricityPricePlan>, ElectricityPricePlanRepository>();
            services.AddTransient<IAccountService, NewAccountService>();
            services.AddTransient<IMeterReadingService, NewMeterReadingService>();
            services.AddTransient<IPricePlanService, NewPricePlanService>(); // create new AddTransient 
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }


        public void CreateInitialDatabase()
        {
            using (var context = new JOIEnergyContext())
            {

                var generator = new ElectricityReadingGenerator();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // init SmartMeters
                var smartMeterRepository = new ElectricitySmartMeterRepository(context);
                var Sarah = new ElectricitySmartMeter { Name = "Sarah", SmartMeterID = "smart-meter-0", PowerSupplier = Supplier.DrEvilsDarkEnergy };
                var Peter = new ElectricitySmartMeter { Name = "Peter", SmartMeterID = "smart-meter-1", PowerSupplier = Supplier.TheGreenEco };
                var Charlie = new ElectricitySmartMeter { Name = "Charlie", SmartMeterID = "smart-meter-2", PowerSupplier = Supplier.DrEvilsDarkEnergy };
                var Andrea = new ElectricitySmartMeter { Name = "Andrea", SmartMeterID = "smart-meter-3", PowerSupplier = Supplier.PowerForEveryone };
                var Alex = new ElectricitySmartMeter { Name = "Alex", SmartMeterID = "smart-meter-4", PowerSupplier = Supplier.TheGreenEco };


                smartMeterRepository.Add(Sarah);
                smartMeterRepository.Add(Peter);
                smartMeterRepository.Add(Charlie);
                smartMeterRepository.Add(Andrea);
                smartMeterRepository.Add(Alex);
                smartMeterRepository.SaveChanges();


                var electricityReadingRepository = new ElectricityReadingRepository(context);
                var smartMeterIds = SmartMeterToPricePlanAccounts.Select(mtpp => mtpp.Key);
                foreach (var smartMeterId in smartMeterIds)
                {
                    var listElectricityReading = generator.Generate(20, smartMeterId);
                    electricityReadingRepository.AddRange(listElectricityReading);
                }
                electricityReadingRepository.SaveChanges();


                var pricePlans = new List<ElectricityPricePlan> {
                    new ElectricityPricePlan{
                        EnergySupplier = Domain.Enums.Supplier.DrEvilsDarkEnergy,
                        UnitRate = 10m,
                        //PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                    },
                    new ElectricityPricePlan{
                        EnergySupplier = Domain.Enums.Supplier.TheGreenEco,
                        UnitRate = 2m,
                        //PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                    },
                    new ElectricityPricePlan{
                        EnergySupplier = Domain.Enums.Supplier.PowerForEveryone,
                        UnitRate = 1m
                        //PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                    }
                };

                var pricePlanRepository = new ElectricityPricePlanRepository(context);
                pricePlanRepository.AddRange(pricePlans);
                pricePlanRepository.SaveChanges();

            }
        }



        private Dictionary<string, List<ElectricityReading>> GenerateMeterElectricityReadings() {
            var readings = new Dictionary<string, List<ElectricityReading>>();
            var generator = new ElectricityReadingGenerator();
            var smartMeterIds = SmartMeterToPricePlanAccounts.Select(mtpp => mtpp.Key);

            foreach (var smartMeterId in smartMeterIds)
            {
                readings.Add(smartMeterId, generator.Generate(20));
            }
            return readings;
        }

        public Dictionary<String, Supplier> SmartMeterToPricePlanAccounts
        {
            get
            {
                Dictionary<String, Supplier> smartMeterToPricePlanAccounts = new Dictionary<string, Supplier>();
                smartMeterToPricePlanAccounts.Add("smart-meter-0", Supplier.DrEvilsDarkEnergy);
                smartMeterToPricePlanAccounts.Add("smart-meter-1", Supplier.TheGreenEco);
                smartMeterToPricePlanAccounts.Add("smart-meter-2", Supplier.DrEvilsDarkEnergy);
                smartMeterToPricePlanAccounts.Add("smart-meter-3", Supplier.PowerForEveryone);
                smartMeterToPricePlanAccounts.Add("smart-meter-4", Supplier.TheGreenEco);
                return smartMeterToPricePlanAccounts;
            }
        }
    }
}
