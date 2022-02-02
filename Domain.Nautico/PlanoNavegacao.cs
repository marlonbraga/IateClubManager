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
    public class PlanoNavegacao : IPlanoNavegacao
    {
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public String Destino { get; set; }
        public IResponsavel Responsavel { get; set; }
        public List<IPassageiro> Passageiros { get; set; }
        public IEmbarcacao Embarcacao { get; set; }

        public PlanoNavegacao(DateTime DataSaida, DateTime DataRetorno, String Destino, IResponsavel Responsavel, List<IPassageiro> Passageiros, IEmbarcacao Embarcacao)
        {
            this.DataSaida = DataSaida;
            this.DataRetorno = DataRetorno;
            this.Destino = Destino;
            this.Responsavel = Responsavel;
            this.Passageiros = Passageiros;
            this.Embarcacao = Embarcacao;
        }
    }
}