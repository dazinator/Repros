using Android.App;
using Android.OS;
using Android.Content.PM;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Reflection;
using Xamarin.Standard.Hosting;
using MonoDroid.ViewLifecycleManager;

namespace Todo
{

    [Activity(Label = "Todo", Icon = "@drawable/icon", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        //  private static Lazy<IServiceProvider> _serviceProvider;

        protected override void OnCreate(Bundle bundle)
        {
            ServiceProvider = new Lazy<IServiceProvider>(() =>
            {
                IServiceCollection services = new ServiceCollection();
                services.AddAndroidHostingEnvironment();
                var sp = services.BuildServiceProvider();
                var serviceProvider = MainApp.Current.Initialise<IStartup>(services, s=>  s.BuildServiceProvider(), sp);
                return serviceProvider;
            });

            // on subsequent launches - re-register lifecycle hooks. because in destroy, we unregister.
            if (ServiceProvider.IsValueCreated)
            {
                var lifecyclehooks = ServiceProvider.Value.GetRequiredService<IDroidViewLifecycleManager>();
                lifecyclehooks.Register();
            }

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            try
            {
                var app = ServiceProvider.Value.GetRequiredService<global::Todo.App>();
                LoadApplication(app);
            }
            catch (ReflectionTypeLoadException e)
            {

                throw;
            }


        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            var lifecyclehooks = ServiceProvider.Value.GetRequiredService<IDroidViewLifecycleManager>();
            lifecyclehooks.Unregister();

        }

        public Lazy<IServiceProvider> ServiceProvider { get; private set; }


    }




}


