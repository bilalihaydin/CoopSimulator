using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using static CoopSimulator.Program;

namespace CoopSimulator.App
{
    public class Startup
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddSingleton<SimulatorApp>();
        }
    }
}
