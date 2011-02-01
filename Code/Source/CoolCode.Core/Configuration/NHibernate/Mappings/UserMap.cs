using CoolCode.Domain;
using FluentNHibernate.Mapping;

namespace CoolCode.Core.Configuration.NHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.UserId).GeneratedBy.Identity();
            Map(u => u.Username);
            Map(u => u.Password);
            References(u => u.Profile);
        }
    }
}