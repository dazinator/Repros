using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Xamarin.Standard.Hosting;

using System.Linq;

namespace Todo
{
    public class Startup : IStartup
    {

        public void RegisterServices(IServiceCollection services)
        {
            // Register services here.
            services.AddEntityFrameworkSqlite();
            services.AddDbContext<TodoItemDatabase>();
                     
            services.AddSingleton<IPageProvider, PageProvider>();
         //   services.AddSingleton<IServersProvider, ServersProvider>();
            services.AddTransient<App>();     
            

            RegisterPages(services);

            //  services.AddSingleton<IPageProvider>((sp) => { return new PageProvider(sp, sp.GetRequiredService<IAccountService>()); });
            
        }

        public void OnConfigured(IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TodoItemDatabase>();
                db.Database.EnsureCreated();
                db.Database.Migrate();

                var allServers = db.Servers.ToArray();
                db.Servers.RemoveRange(allServers);

                db.Servers.Add(new Server() { Name = "Debug" });
                db.Servers.Add(new Server() { Name = "CI" });
                db.Servers.Add(new Server() { Name = "Test" });
                db.Servers.Add(new Server() { Name = "UAT" });
                db.Servers.Add(new Server() { Name = "Live" });

                db.SaveChanges();
            }
        }

        public virtual void RegisterPages(IServiceCollection services)
        {
            // Register various pages.
            services.AddTransient<TodoListPage>();
            services.AddTransient<TodoItemPage>();
            services.AddTransient<AccountSelectPage>();
        }

    }
}

