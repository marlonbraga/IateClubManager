using Domain.Core;
using Domain.Core.Interfaces;
using Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;

namespace Infrastructure
{
    public class NauticoRepository : INauticoRepository
    {
        public List<IPlanoNavegacao> __memoryDatabasePlanosNavegacao__ { get; set; }
        public List<IPlanoNavegacao> __memoryDatabaseFila__ { get; set; }


        public NauticoRepository()
        {
            __memoryDatabasePlanosNavegacao__ = new();
            __memoryDatabaseFila__ = new();
        }

        public IPlanoNavegacao CriacaoPlanoDeNavegacao(IPlanoNavegacao _planoNavegacao)
        {
            __memoryDatabasePlanosNavegacao__.Add(_planoNavegacao);
            return _planoNavegacao;
        }

        public void AdicionarNavegacao(IPlanoNavegacao _planoNavegacao)
        {
            __memoryDatabaseFila__.Add(_planoNavegacao);
        }

        public List<IPlanoNavegacao> ExibirNavegacoes()
        {
            return __memoryDatabasePlanosNavegacao__;
        }

        public List<IPlanoNavegacao> ExibirFilaNavegacoes()
        {
            return __memoryDatabaseFila__;
        }

        public void CancelarNavegacao(IPlanoNavegacao _planoNavegacao)
        {
            __memoryDatabasePlanosNavegacao__.Remove(_planoNavegacao);
        }

        public void TrocarPosicao(IPlanoNavegacao _planoNavegacao, int _posicoes)
        {
            int indice = __memoryDatabaseFila__.IndexOf(_planoNavegacao);
            __memoryDatabaseFila__.RemoveAt(indice);
            __memoryDatabaseFila__.Insert(indice + _posicoes, _planoNavegacao);
        }

        public void LiberarNavegacao(IPlanoNavegacao _planoNavegacao)
        {
            __memoryDatabaseFila__.Remove(_planoNavegacao);
        }

        public List<IPlanoNavegacao> AcessarHistoricoDeNavegacao(ITitulo _titulo)
        {
            List<IPlanoNavegacao> historico = new();
            foreach (IPlanoNavegacao item in __memoryDatabasePlanosNavegacao__)
            {
                if (item.Titulo == _titulo)
                {
                    historico.Add(item);
                }
            }
            return historico;
        }
    }
}
