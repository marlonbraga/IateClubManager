using System;

namespace Domain.Core.Interfaces
{
    public interface ICobrancaFinanceira
    {
        public decimal ValorMensalidade { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }

        public bool ValidaPendenciaFinanceira(ITitulo Titulo);
    }
}
