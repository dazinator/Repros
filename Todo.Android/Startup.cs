using Android.App;
using Gluon.Client.UserAccount.Android;
using Microsoft.Extensions.DependencyInjection;
using MonoDroid.ViewLifecycleManager;
using Xamarin.Standard.Hosting.Android;

namespace Todo
{
    public class Startup : AndroidStartup
    {
        public Startup(AppContextProvider context) : base(context)
        {
        }

        public override void RegisterServices(IServiceCollection services)
        {

            // services.
            services.RegisterAndroidViewLifecycleManager(MainApp.Current);

            services.AddAndroidUserAccountService((options) => {
                options.DefaultAccountType = "com.flexforce.jwt";
                options.Options = new Android.OS.Bundle(); // additional bundle that will be passed to the authenticator when workign with accounts.
                options.Options.PutString("Environment", "Debug");
            });
           // return services;           
           
        }    
    }

}


