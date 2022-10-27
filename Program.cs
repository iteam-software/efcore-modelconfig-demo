// See https://aka.ms/new-console-template for more information

using System.Reflection;
using efcore_modelconfig_demo;
using efcore_modelconfig_demo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services => {
      var types = Assembly.GetExecutingAssembly().GetTypes();
      var model_type = typeof(IModel);
      foreach (var type in types) {
        if (type == model_type || !type.IsAssignableTo(model_type)) {
          continue;
        }
        
        services.AddSingleton(model_type, type);
      }

      services.AddDbContext<TaskingContext>(config => {
        config.UseInMemoryDatabase("TaskingDB");
      });
      services.AddHostedService<Runner>();
    })
    .Build();

await host.StartAsync();