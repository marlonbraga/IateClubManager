using Domain.Core;
using Domain.Core.Interfaces;
using Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;

namespace Domain.Nautico
{
    public class FilaNavegacao : IFilaNavegacao
    {
        public List<IPlanoNavegacao> __fila__ { get; set; }
        public INauticoRepository __nauticoRepository__ { get; set; }
        private static FilaNavegacao __intance__;

        private FilaNavegacao(INauticoRepository _nauticoRepository)
        {
            __nauticoRepository__ = _nauticoRepository;
        }

        public static IFilaNavegacao GetInstance(INauticoRepository _nauticoRepository)
        {
            if (__intance__ is null)
            {
                __intance__ = new FilaNavegacao(_nauticoRepository);
            }
            return __intance__;
        }

        public void AdicionarNavegacao(IPlanoNavegacao _planoDeNavegacao)
        {
            __nauticoRepository__.AdicionarNavegacao(_planoDeNavegacao);
        }
        public List<IPlanoNavegacao> ExibirNavegacoes()
        {
            return __nauticoRepository__.ExibirFilaNavegacoes();
        }
        public void CancelarNavegacao(IPlanoNavegacao _planoDeNavegacao)
        {
            __nauticoRepository__.CancelarNavegacao(_planoDeNavegacao);
        }
        public void TrocarPosicao(IPlanoNavegacao _planoDeNavegacao, int _posicoes)
        {
            __nauticoRepository__.TrocarPosicao(_planoDeNavegacao, _posicoes);
        }
        public void LiberarNavegacao(IPlanoNavegacao _planoDeNavegacao)
        {
            __nauticoRepository__.LiberarNavegacao(_planoDeNavegacao);
        }
        public List<IPlanoNavegacao> AcessarHistoricoDeNavegacao(ITitulo _titulo)
        {
            return __nauticoRepository__.AcessarHistoricoDeNavegacao(_titulo);
        }
    }
}
