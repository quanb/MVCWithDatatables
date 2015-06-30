using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithDatatables.Models
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                                            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c =>
                                            c.FromConnectionStringWithKey("CompanySampleConnString")))
                                            .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Company>())
                                            //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                                            .BuildConfiguration()
                                            .BuildSessionFactory();
            return sessionFactory.OpenSession();

        }
    }
}