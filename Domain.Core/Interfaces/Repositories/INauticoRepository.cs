using System.Collections.Generic;

namespace Domain.Core.Interfaces.Repositories
{
    public interface INauticoRepository
    {
        public List<IPlanoNavegacao> __memoryDatabasePlanosNavegacao__ { get; set; }
        public List<IPlanoNavegacao> __memoryDatabaseFila__ { get; set; }

        public IPlanoNavegacao CriacaoPlanoDeNavegacao(IPlanoNavegacao _planoNavegacao);

        public void AdicionarNavegacao(IPlanoNavegacao _planoNavegacao);

        public List<IPlanoNavegacao> ExibirNavegacoes();

        public List<IPlanoNavegacao> ExibirFilaNavegacoes();

        public void CancelarNavegacao(IPlanoNavegacao _planoNavegacao);

        public void TrocarPosicao(IPlanoNavegacao _planoNavegacao, int _posicoes);

        public void LiberarNavegacao(IPlanoNavegacao _planoNavegacao);
        public List<IPlanoNavegacao> AcessarHistoricoDeNavegacao(ITitulo _titulo);
    }
}
