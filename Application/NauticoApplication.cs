using Domain.Core;
using Domain.Core.Interfaces;
using Domain.Core.Interfaces.Repositories;
using Domain.Nautico;
using Infrastructure;
using System;
using System.Collections.Generic;

namespace Application
{
    public class NauticoApplication
    {
        public INauticoRepository __nauticoRepository__ { get; set; }
        public IFactoryPlanoNavegacao __factoryPlanoNavegacao__ { get; set; }
        public IFilaNavegacao __filaNavegacao__ { get; set; }

        public NauticoApplication(INauticoRepository _nauticoRepository = null, IFactoryPlanoNavegacao _factoryPlanoNavegacao = null)
        {
            __nauticoRepository__ = _nauticoRepository ?? new NauticoRepository();
            __factoryPlanoNavegacao__ = _factoryPlanoNavegacao ?? new FactoryPlanoNavegacao(__nauticoRepository__);
            __filaNavegacao__ = FilaNavegacao.GetInstance(__nauticoRepository__);
        }

        public IPlanoNavegacao CriacaoPlanoDeNavegacao(IResponsavel _responsavel, ITitulo _titulo, IEmbarcacao _embarcacao,
            DateTime _dataSaida, DateTime _dataRetorno, string _destino, List<IPassageiro> _passageiros)
        {
            IPlanoNavegacao planoNavegacao = __factoryPlanoNavegacao__.CriacaoPlanoDeNavegacao(_responsavel, _titulo, _embarcacao, _dataSaida, _dataRetorno, _destino, _passageiros);
            __filaNavegacao__.AdicionarNavegacao(planoNavegacao);

            return planoNavegacao;
        }

        private void AdicionarNavegacao(IPlanoNavegacao _planoNavegacao)
        {
            __nauticoRepository__.AdicionarNavegacao(_planoNavegacao);
        }

        public List<IPlanoNavegacao> ExibirNavegacoes()
        {
            return __filaNavegacao__.ExibirNavegacoes();
        }

        public void CancelarNavegacao(IPlanoNavegacao _planoNavegacao)
        {
            __filaNavegacao__.CancelarNavegacao(_planoNavegacao);
        }

        public void TrocarPosicao(IPlanoNavegacao _planoNavegacao, int _posicao)
        {
            __filaNavegacao__.TrocarPosicao(_planoNavegacao, _posicao);
        }

        public void LiberarNavegacao(IPlanoNavegacao _planoNavegacao)
        {
            __filaNavegacao__.LiberarNavegacao(_planoNavegacao);
        }

        public List<IPlanoNavegacao> AcessarHistoricoDeNavegacao(ITitulo _titulo)
        {
            return __filaNavegacao__.AcessarHistoricoDeNavegacao(_titulo);
        }
    }
}
