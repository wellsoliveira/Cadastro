using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.NHibernate.Interface
{
    public interface IRepository<T>
    {
        void Inserir(T entity);
        void Alterar(T entity);
        void Excluir(T entity);
        T ObtemPorId(int id);
        IList<T> Consultar();
    }
}
