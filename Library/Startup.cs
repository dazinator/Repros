using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library
{
    public class Startup 
    {
        public IServiceProvider Build(IServiceCollection services, Func<IServiceCollection, IServiceProvider> buildProvider )
        {           
            return buildProvider?.Invoke(services);           
        }       
    }
}
