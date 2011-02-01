using System.Web.Routing;
using CoolCode.Core.Configuration.StructureMap;
using CoolCode.Web.Configuration.Fubu;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace CoolCode.Web.Configuration
{
    public static class Bootstrapper
    {
        private static IContainer BootstrapStructureMap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<CoreRegistry>());
            return ObjectFactory.Container;
        }

        public static void Bootstrap(RouteCollection routes)
        {
            var container = BootstrapStructureMap();
            
            FubuApplication
                .For<CoolCodeFubuRegistry>()
                .StructureMap(() => container)
                .Bootstrap(routes);
        }
    }
}