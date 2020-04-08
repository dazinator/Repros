using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ChildContainerAndAddLogging
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var logEventHistory = new LogEventHistory();

            var services = new ServiceCollection();
            services.AddLogging(a =>
            {
                a.ClearProviders();

                var testProvider = new TestLoggerProvider(logEventHistory, "root");
                a.AddProvider(testProvider);
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            var rootAutofacContainer = builder.Build();


            // create a child scope e.g for a tenant.
            // SEE https://autofaccn.readthedocs.io/en/latest/lifetime/working-with-scopes.html#adding-registrations-to-a-lifetime-scope

            using (var tenantScope = rootAutofacContainer.BeginLifetimeScope("TENANT", (builder) =>
             {
                 ServiceCollection services = new ServiceCollection();
                 services.AddLogging(a =>
                 {
                     a.ClearProviders(); // this can't clear root level loggers so we end up with more providers registered than it appears.

                     var testProvider = new TestLoggerProvider(logEventHistory, "child");
                     a.AddProvider(testProvider);
                 });
                 builder.Populate(services);
             }))
            {
                // simulates what happens at the start of a request for this tenant.
                using (var requestScope = tenantScope.BeginLifetimeScope())
                {
                    // log something at.. which providers will log the event?
                    // our intention is for only the one TestLoggerProvider at child level to log an event.
                    var logger = tenantScope.Resolve<ILogger<Program>>();
                    logger.LogInformation("We want the child provider to log this..");

                    var allLogs = logEventHistory.GetLogs();
                    foreach (var item in allLogs)
                    {
                        if (item.ProviderName == "root")
                        {
                            throw new Exception("We didn't want the root logger provider to interfere at child scope!");
                        }
                    }
                }             
            }
        }
    }
}
