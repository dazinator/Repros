using Library;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();

            var startup = new Startup();
            var serviceProvider = startup.Build(collection, services => services.BuildServiceProvider());

        }
    }
}
