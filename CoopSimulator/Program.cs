using CoopSimulator.App;
using CoopSimulator.Service.Extension;
using CoopSimulator.Service.Enum;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using CoopSimulator.Model.Core;
using System.Collections.Generic;
using CoopSimulator.Service.Concrete;
using CoopSimulator.Service.Constant;
using CoopSimulator.Service.Services.Lifecycle;
using System.Linq;
using CoopSimulator.Service.Validator.Rabbit;

namespace CoopSimulator
{
    class Program
    {
        public class SimulatorApp
        {
            public DateTime StartDate { get; set; } = new DateTime(2021, 01, 01);
            public DateTime EndDate { get; set; }
            public List<IPoultry> PoultryList { get; set; }
            public SimulatorApp()
            {
                IConfiguration config = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory))
               .AddJsonFile("appconfig.json", true, true)
               .Build();

                int timeSpend = Convert.ToInt32(config.GetSection("SimulationDayLife").Value);

                EndDate = StartDate.AddDays(100);

                PoultryList = new List<IPoultry>()
                {
                    new Poultry() { BirthDate = StartDate.AddYears(-1), isMale = true, isPregnant = false, PoultryEnum = (int)PoultryEnum.Rabbit },
                    new Poultry() { BirthDate = StartDate.AddYears(-1), isMale = false, isPregnant = false, PoultryEnum = (int)PoultryEnum.Rabbit }
                };
            }

            public void Run()
            {
                ILifecycle lifecycle = PoultryEnum.Rabbit.GetLifecycle(PoultryList);

                for (DateTime date = StartDate; date <= EndDate; date = date.AddDays(CommonConstant._one))
                {
                    lifecycle.Date = date;
                    lifecycle.NextDay();
                }

                int femaleRabbitNumber = PoultryList.Where(condition => condition.isMale == false).Count();
                int maleRabbitNumber = PoultryList.Count() - femaleRabbitNumber;

                Console.WriteLine("Dişi tavşan sayısı = {0}", femaleRabbitNumber);
                Console.Read();
                Console.WriteLine("Erkek tavşan sayısı = {0}", maleRabbitNumber);
                Console.Read();

                foreach (IPoultry poultry in PoultryList)
                {
                    RabbitProvider rabbitProvider = new RabbitProvider(poultry, EndDate);
                    Console.WriteLine(rabbitProvider.GetAge());
                }

                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            Startup.ConfigureService(serviceCollection);

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                serviceProvider.GetRequiredService<SimulatorApp>().Run();
            }
        }
    }
}
