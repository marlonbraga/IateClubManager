using System;
using System.Collections.Generic;

namespace Domain.Administrativo
{
    public class CobrancaFinanceira
    {
        public decimal ValorMensalidade { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }


        public bool ValidaPendenciaFinanceira(List<CobrancaFinanceira> listaCobrancaFinanceira)
        {
            foreach (var lista in listaCobrancaFinanceira)
            {
                if (lista.Pago == false && lista.DataVencimento <= DateTime.Now.AddMonths(-3))
                {
                    return true;
                }
            }
            return false;
        }
    }
}