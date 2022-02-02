using Domain.Core;
using Domain.Core.Interfaces;
using Domain.Nautico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResponsavel = Domain.Core.Interfaces.IResponsavel;
using Responsavel = Domain.Core.Responsavel;

namespace Domain.Nautico
{
	public class FactoryPlanoNavegacao
	{
        public PlanoNavegacao CriacaoPlanoDeNavegacao(IResponsavel Responsavel, ITitulo Titulo, IEmbarcacao Embarcacao,
            DateTime DataSaida, DateTime DataRetorno, string Destino, List<IPassageiro> Passageiros)
		{
			if (!ValidarEmbarcacao(Titulo, Embarcacao))
			{
                return null;
            }
            if (!ValidaHabilitacaoNautica(Responsavel))
            {
                return null;
            }
            if (!ValidaAdvertencia(Titulo))
            {
                return null;
            }
            if (!ValidaPendenciaFinanceira(Titulo))
            {
                return null;
            }
            return new PlanoNavegacao(DataSaida, DataRetorno, Destino, Responsavel, Passageiros, Embarcacao);
        }

        private bool ValidarEmbarcacao(ITitulo Titulo, IEmbarcacao Embarcacao)
        {
            List<IEmbarcacao> EmbarcacoesValidas = Titulo.Embarcacoes;

            IEmbarcacao retorno = EmbarcacoesValidas.Find(x => x == Embarcacao);
            if (retorno == null)
            {
                return false;
            }
            return true;
        }

        private bool ValidaHabilitacaoNautica(IResponsavel Responsavel)
        {
            return Responsavel.HabilitacaoNautica is not null;
        }

        private bool ValidaAdvertencia(ITitulo Titulo)
        {
            foreach (IAdvertencia advertencia in Titulo.Advertencias)
            {
                if (advertencia.Impeditiva && advertencia.Vigente)
                    return false;
            }
            return true;
        }

        public bool ValidaPendenciaFinanceira(ITitulo Titulo)
        {
            foreach (ICobrancaFinanceira lista in Titulo.CobrancasFinanceiras)
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
