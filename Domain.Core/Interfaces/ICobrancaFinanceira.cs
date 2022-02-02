using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
