using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Entidades
{
    public class DadosCadastrais
    {
        public virtual int Id_empresa { get; set; }
        public virtual string Nm_empresa { get; set; }
        public virtual string Ds_endereco { get; set; }
        public virtual string Nm_contato { get; set; }
    }
}
