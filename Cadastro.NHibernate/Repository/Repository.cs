using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastro.NHibernate.Interface;
using NHibernate;
using NHibernate.Linq;

namespace Cadastro.NHibernate.Repository
{
    public class Repository<T> : IRepository<T> where T :class
    {
        public void Inserir(T entity)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir. " + ex.Message);
                    }
                }
            }
        }

        public void Alterar(T entity)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao alterar. " + ex.Message);
                    }
                }
            }
        }

        public void Excluir(T entity)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao exclcluir. " + ex.Message);
                    }
                }
            }
        }

        public T ObtemPorId(int id)
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                return session.Get<T>(id);
            }
        }


        public IList<T> Consultar()
        {
            using (ISession session = FluentSessionFactory.AbrirSession())
            {
                return (from e in session.Query<T>() select e).ToList();
            }
        }
    }
}
