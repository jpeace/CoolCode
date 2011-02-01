using System.Web.Routing;
using CoolCode.Core.Configuration.StructureMap;
using CoolCode.Web.Configuration.Fubu;
using FubuCore;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace CoolCode.Web.Configuration
{
    public static class Bootstrapper
    {
        private static IContainer BootstrapStructureMap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<CoreRegistry>());
            var container = ObjectFactory.Container;
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(container));
            return container;
        }

        public static void Bootstrap(RouteCollection routes)
        {
            UrlContext.Reset();

            var container = BootstrapStructureMap();
            
            FubuApplication
                .For<CoolCodeFubuRegistry>()
                .StructureMap(() => container)
                .Bootstrap(routes);
        }
    }
}