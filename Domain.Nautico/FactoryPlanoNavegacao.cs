using Domain.Core;
using Domain.Core.Interfaces;
using Domain.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using IResponsavel = Domain.Core.Interfaces.IResponsavel;

namespace Domain.Nautico
{
    public class FactoryPlanoNavegacao : IFactoryPlanoNavegacao
    {
        public INauticoRepository __nauticoRepository__ { get; set; }

        public FactoryPlanoNavegacao(INauticoRepository _nauticoRepository)
        {
            __nauticoRepository__ = _nauticoRepository;
        }

        public IPlanoNavegacao CriacaoPlanoDeNavegacao(IResponsavel _responsavel, ITitulo _titulo, IEmbarcacao _embarcacao,
            DateTime _dataSaida, DateTime _dataRetorno, string _destino, List<IPassageiro> _passageiros)
        {
            if (ValidaCriacaoDePlanoDeNavegacao(_responsavel, _titulo, _embarcacao))
            {
                PlanoNavegacao planoNavegacao = new(_dataSaida, _dataRetorno, _destino, _responsavel, _passageiros, _embarcacao, _titulo);
                __nauticoRepository__.CriacaoPlanoDeNavegacao(planoNavegacao);
                return planoNavegacao;
            }
            return null;
        }

        public bool ValidaCriacaoDePlanoDeNavegacao(IResponsavel _responsavel, ITitulo _titulo, IEmbarcacao _embarcacao)
        {
            if (!ValidarEmbarcacao(_titulo, _embarcacao))
            {
                return false;
            }
            if (!ValidaHabilitacaoNautica(_responsavel))
            {
                return false;
            }
            if (!ValidaAdvertencia(_titulo))
            {
                return false;
            }
            if (!ValidaPendenciaFinanceira(_titulo))
            {
                return false;
            }
            return true;
        }

        private bool ValidarEmbarcacao(ITitulo _titulo, IEmbarcacao _embarcacao)
        {
            List<IEmbarcacao> EmbarcacoesValidas = _titulo.Embarcacoes;

            IEmbarcacao retorno = EmbarcacoesValidas.Find(x => x == _embarcacao);
            if (retorno == null)
            {
                return false;
            }
            return true;
        }

        private bool ValidaHabilitacaoNautica(IResponsavel _responsavel)
        {
            return _responsavel.HabilitacaoNautica is not null;
        }

        private bool ValidaAdvertencia(ITitulo _titulo)
        {
            foreach (IAdvertencia advertencia in _titulo.Advertencias)
            {
                if (advertencia.Impeditiva && advertencia.Vigente)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidaPendenciaFinanceira(ITitulo _titulo)
        {
            foreach (ICobrancaFinanceira lista in _titulo.CobrancasFinanceiras)
            {
                if (lista.Pago == false && lista.DataVencimento <= DateTime.Now.AddMonths(-3))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
