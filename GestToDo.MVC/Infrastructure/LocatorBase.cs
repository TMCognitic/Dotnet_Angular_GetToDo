using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestToDo.MVC.Infrastructure
{
    public abstract class LocatorBase
    {
        protected IServiceProvider Container { get; private set; }

        protected LocatorBase()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            Container = services.BuildServiceProvider();
        }


        protected abstract void ConfigureServices(IServiceCollection services);
    }
}