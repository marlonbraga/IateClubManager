using Domain.Core;
using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Administrativo
{
    public class CobrancaFinanceira : ICobrancaFinanceira
    {
        public decimal ValorMensalidade { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }

		public CobrancaFinanceira()
		{
                
		}

		public CobrancaFinanceira(decimal valorMensalidade, DateTime dataVencimento, bool pago)
		{
			ValorMensalidade = valorMensalidade;
			DataVencimento = dataVencimento;
			Pago = pago;
		}

		public bool ValidaPendenciaFinanceira(ITitulo Titulo)
		{
            foreach (var lista in Titulo.CobrancasFinanceiras)
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