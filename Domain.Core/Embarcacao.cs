using Domain.Core.Interfaces;
using System.Collections.Generic;

namespace Domain.Core
{
    public class Embarcacao : IEmbarcacao
    {
        public string Nome { get; set; }
        public string RegistroMarinha { get; set; }
        public string PorteNautico { get; set; }
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
