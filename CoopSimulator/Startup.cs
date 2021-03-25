using Microsoft.Extensions.DependencyInjection;
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
