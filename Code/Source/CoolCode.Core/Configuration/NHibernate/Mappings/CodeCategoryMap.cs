using CoolCode.Domain;
using FluentNHibernate.Mapping;

namespace CoolCode.Core.Configuration.NHibernate.Mappings
{
    public class CodeCategoryMap : ClassMap<CodeCategory>
    {
        public CodeCategoryMap()
        {
            Id(c => c.CodeCategoryId).GeneratedBy.Identity();
            Map(c => c.Name);
        }
    }
}