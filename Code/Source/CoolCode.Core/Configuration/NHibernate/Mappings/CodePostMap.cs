using CoolCode.Domain;
using FluentNHibernate.Mapping;

namespace CoolCode.Core.Configuration.NHibernate.Mappings
{
    public class CodePostMap : ClassMap<CodePost>
    {
        public CodePostMap()
        {
            Id(p => p.CodePostId).GeneratedBy.Identity();
            Map(p => p.Timestamp);
            References(p => p.Author);
            References(p => p.Language);
            HasManyToMany(p => p.Categories);
            Map(p => p.Title);
            Map(p => p.Code);
            HasMany(p => p.Comments);
        }
    }
}