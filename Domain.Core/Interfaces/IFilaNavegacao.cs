using System.Collections.Generic;

namespace Domain.Core.Interfaces
{
    public interface IFilaNavegacao
    {
        public List<IPlanoNavegacao> __fila__ { get; set; }

        public void AdicionarNavegacao(IPlanoNavegacao _planoDeNavegacao);
        public List<IPlanoNavegacao> ExibirNavegacoes();
        public void CancelarNavegacao(IPlanoNavegacao _planoDeNavegacao);
        public void TrocarPosicao(IPlanoNavegacao _planoDeNavegacao, int _posicoes);
        public void LiberarNavegacao(IPlanoNavegacao _planoDeNavegacao);
        public List<IPlanoNavegacao> AcessarHistoricoDeNavegacao(ITitulo _titulo);
    }
}
