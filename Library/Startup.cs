using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library
{  
    public class Startup 
    {
        public IServiceProvider Build(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }       
    }
}
