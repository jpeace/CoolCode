using CoolCode.Domain;
using FluentNHibernate.Mapping;

namespace CoolCode.Core.Configuration.NHibernate.Mappings
{
    public class CodeLanguageMap : ClassMap<CodeLanguage>
    {
        public CodeLanguageMap()
        {
            Id(l => l.CodeLanguageId).GeneratedBy.Identity();
            Map(l => l.Name);
        }
    }
}