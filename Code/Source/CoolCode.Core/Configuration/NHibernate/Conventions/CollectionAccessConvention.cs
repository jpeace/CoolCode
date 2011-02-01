using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace CoolCode.Core.Configuration.NHibernate.Conventions
{
    public class CollectionAccessConvention : ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            instance.Access.CamelCaseField(CamelCasePrefix.Underscore);
        }
    }
}