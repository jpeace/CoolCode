using StructureMap.Configuration.DSL;

namespace CoolCode.Core.Configuration.StructureMap
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
                     {
                         x.AssemblyContainingType<CoreRegistry>();
                         x.IncludeNamespaceContainingType<CoreRegistry>();
                         x.ExcludeType<CoreRegistry>();
                         x.LookForRegistries();
                     });
        }
    }
}