using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Cadastro.Entidades;


namespace Cadastro.NHibernate.Mapping
{
    public class CadastroMapping : ClassMap<DadosCadastrais>
    {
        public CadastroMapping()
        {
            Id(a => a.Id_empresa);
            Map(a => a.Nm_empresa);
            Map(a => a.Ds_endereco);
            Map(a => a.Nm_contato);
            Table("tb_cadastro");
        }
    }
}
