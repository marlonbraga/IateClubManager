using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Financas
{
    public class PendenciaFinanceira
    {
        public DateTime DataCobranca { get; set; }
        public float Valor { get; set; }
        public Socio Socio { get; set; }
    }
}
