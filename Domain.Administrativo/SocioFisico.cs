using Domain.Core;
using Domain.Core.Interfaces;
using IResponsavel = Domain.Core.Interfaces.IResponsavel;

namespace Domain.Administrativo
{
    public class SocioFisico : PessoaFisica, ISocio, IResponsavel
    {
        public HabilitacaoNautica HabilitacaoNautica { get; set; }
    }
}
