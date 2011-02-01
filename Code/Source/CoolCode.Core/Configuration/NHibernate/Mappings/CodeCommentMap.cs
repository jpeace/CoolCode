using CoolCode.Domain;
using FluentNHibernate.Mapping;

namespace CoolCode.Core.Configuration.NHibernate.Mappings
{
    public class CodeCommentMap : ClassMap<CodeComment>
    {
        public CodeCommentMap()
        {
            Id(c => c.CodeCommentId).GeneratedBy.Identity();
            Map(c => c.Timestamp);
            References(c => c.Author);
            Map(c => c.Body);
            References(c => c.Post);
        }
    }
}