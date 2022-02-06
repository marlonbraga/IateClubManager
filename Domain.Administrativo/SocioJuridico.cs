using Domain.Core;
using Domain.Core.Interfaces;
using IResponsavel = Domain.Administrativo.Interfaces.IResponsavel;

namespace Domain.Administrativo
{
    public class SocioJuridico : PessoaJuridica, ISocio
    {
        public IResponsavel Responsavel { get; set; }
    }
}
