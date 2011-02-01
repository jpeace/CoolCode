using CoolCode.Core.Configuration.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using StructureMap.Configuration.DSL;

namespace CoolCode.Core.Configuration.StructureMap
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("CoolCode")))
                .Mappings
                (
                    m => m
                        .FluentMappings
                        .AddFromAssemblyOf<NHibernateConfigMarker>()
                        .Conventions.AddFromAssemblyOf<NHibernateConfigMarker>()
                        .Conventions.Add(ForeignKey.EndsWith("Id"))
                )
                .BuildSessionFactory();

            For<ISessionFactory>().Singleton().Use(sessionFactory);
            For<ISession>().HybridHttpOrThreadLocalScoped().Use(context =>
            {
                var session = context.GetInstance<ISessionFactory>().OpenSession();
                session.FlushMode = FlushMode.Commit;
                return session;
            });
        }
    }
}