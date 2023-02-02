using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTest.DI
{
    public class DITest
    {
        public static void Test()
        {
          ServiceCollection services = new ServiceCollection();
            services.AddScoped<Controller>();
            services.AddScoped<ILogService, LogService>();
            
            using (var serviceProvider = services.BuildServiceProvider())
            {
                Controller? controller = serviceProvider.GetRequiredService<Controller>();
                controller.SayHello();
            }
        }


    }

    public interface ILogService
    {
        void Log(string message);
    }

    public class LogService : ILogService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Controller
    {
        public ILogService LogService { get; set; }

        public Controller(ILogService logService)
        {
            LogService = logService;
        }

        public void SayHello()
        {
            LogService.Log("Hello");
        }
    }
}
