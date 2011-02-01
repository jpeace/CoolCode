using CoolCode.Domain;
using FluentNHibernate.Mapping;

namespace CoolCode.Core.Configuration.NHibernate.Mappings
{
    public class UserProfileMap : ClassMap<UserProfile>
    {
        public UserProfileMap()
        {
            Id(p => p.UserProfileId).GeneratedBy.Identity();
            Map(p => p.FirstName);
            Map(p => p.LastName);
            Map(p => p.Email);
            Map(p => p.Company);
            References(p => p.User);
        }
    }
}