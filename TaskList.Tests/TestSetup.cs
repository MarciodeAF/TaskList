using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Controllers;

namespace TaskList.Tests
{
    public class TestSetup
    {
        public TestSetup()
        {
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                     path: "appsettings.json",
                     optional: false,
                     reloadOnChange: true)
                .AddEnvironmentVariables()
               // .AddCommandLine()               
               .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddTransient<TasksController, TasksController>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
