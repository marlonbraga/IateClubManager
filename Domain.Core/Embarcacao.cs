using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Embarcacao : IEmbarcacao
    {
        public String Nome { get; set; }
        public String RegistroMarinha { get; set; }
        public String PorteNautico { get; set; }
		public string TamanhoEmbarcacao { get; set; }
		EMotor IEmbarcacao.TipoMotor { get; set; }
		ECombustivel IEmbarcacao.TipoCombustivel { get; set; }

		public bool ValidaQuantidadeEmbarcacao(List<IEmbarcacao> embarcacoes)
        {
            if (embarcacoes.Count <= 2)
            {
                return true;
            }
            return false;
        }
    }
}
