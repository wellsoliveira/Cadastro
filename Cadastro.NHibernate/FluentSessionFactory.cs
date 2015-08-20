using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;


namespace Cadastro.NHibernate
{
    public class FluentSessionFactory
    {
        private static string ConnectionString = @"database=dbTeste; server=WELLINGTON-NB\SQLEXPRESS; Integrated Security=true;";
        private static ISessionFactory session;

        public static ISessionFactory CriarSession()
        {
            if (session != null)
            {
                return session;
            }

            IPersistenceConfigurer configDB = MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString);

            var configMap = Fluently.Configure().Database(configDB).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Mapping.CadastroMapping>());
            try
            {
                session = configMap.BuildSessionFactory();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return session;
        }

        public static ISession AbrirSession()
        {
            return CriarSession().OpenSession();
        }
    }
}
