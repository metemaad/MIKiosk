using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Cfg.Loquacious;
using NHibernate.Validator.Engine;
using Configuration = NHibernate.Cfg.Configuration;

namespace MIKiosk.BusinessLayer.Infrastructure
{
        public class DataAccess
        {
            public static string ConnectionString { get; set; }
            public static ISessionFactory SessionFactory
            {
                get
                {
                    if (_sessionFactory != null && !_sessionFactory.IsClosed)
                    {
                        return _sessionFactory;
                    }
                    else
                    {
                        _sessionFactory = CreateSessionFactory();
                        return _sessionFactory;
                    }
                }
            }

            private static ValidatorEngine validator;
            public static ValidatorEngine Validator
            {
                get
                {
                    if (validator == null)
                    {
                        validator = new ValidatorEngine();
                        var nhvConfig = InitializeValidationEngine();
                        validator.Configure(nhvConfig);
                    }
                    return validator;
                }
            }

            public static ISession NhSession
            {
                get
                {
                    if (_nhSession != null && _nhSession.IsOpen)
                        return _nhSession;
                    else
                    {
                        _nhSession = SessionFactory.OpenSession();
                        return _nhSession;
                    }
                }
            }

            private static ISession _nhSession;
            private static ISessionFactory _sessionFactory;
            public static void CreateDatabase()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
                Fluently.Configure()
                    .Database(MsSqlConfiguration
                                  .MsSql2008
                                  .ConnectionString(ConnectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
                    .ExposeConfiguration(CreateSchema)
                    .BuildConfiguration();
            }

            private static NHibernate.Validator.Cfg.Loquacious.FluentConfiguration InitializeValidationEngine()
            {
                var nhvConfig =
                    new NHibernate.Validator.Cfg.Loquacious.FluentConfiguration();
                nhvConfig
                    .SetDefaultValidatorMode(ValidatorMode.UseAttribute)
                    .Register(typeof(DataAccess).Assembly.ValidationDefinitions())
                    .IntegrateWithNHibernate
                    .AvoidingDDLConstraints()
                    .And
                    .RegisteringListeners();

                return nhvConfig;
            }

            private static void CreateSchema(Configuration cfg)
            {
                var schemaExport = new SchemaExport(cfg);
                schemaExport.Drop(false, true);
                schemaExport.Create(false, true);
            }

            public static void UpdateDatabase()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
                CreateSessionFactory();
                Fluently.Configure()
                    .Database(MsSqlConfiguration
                                  .MsSql2008
                                  .ConnectionString(ConnectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
                    .ExposeConfiguration(UpdateSchema)
                    .BuildConfiguration();
            }

            private static void UpdateSchema(Configuration cfg)
            {
                var schemaUpdate = new SchemaUpdate(cfg);
                schemaUpdate.Execute(false, true);

            }

            private static ISessionFactory CreateSessionFactory()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
                var config = Fluently.Configure()
                    .Database(MsSqlConfiguration
                                  .MsSql2008
                                  .ConnectionString(ConnectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
                    .ExposeConfiguration(UpdateSchema)
                    .BuildConfiguration();
                config.Initialize(Validator);
                return config.BuildSessionFactory();
            }

            public static void Flush()
            {
                NhSession.Close();
            }
        }
 
}
