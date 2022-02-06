using Domain.Core.Interfaces;

namespace Domain.Core
{
    public class Responsavel : PessoaFisica, IResponsavel
    {
        public HabilitacaoNautica HabilitacaoNautica { get; set; }
    }
}
