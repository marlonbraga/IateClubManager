using Domain.Core;
using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using IResponsavel = Domain.Core.Interfaces.IResponsavel;

namespace Domain.Nautico
{
    public class PlanoNavegacao : IPlanoNavegacao
    {
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public string Destino { get; set; }
        public IResponsavel Responsavel { get; set; }
        public List<IPassageiro> Passageiros { get; set; }
        public IEmbarcacao Embarcacao { get; set; }
        public ITitulo Titulo { get; set; }

        public PlanoNavegacao(DateTime DataSaida, DateTime DataRetorno, string Destino, IResponsavel Responsavel, List<IPassageiro> Passageiros, IEmbarcacao Embarcacao, ITitulo Titulo)
        {
            this.DataSaida = DataSaida;
            this.DataRetorno = DataRetorno;
            this.Destino = Destino;
            this.Responsavel = Responsavel;
            this.Passageiros = Passageiros;
            this.Embarcacao = Embarcacao;
            this.Titulo = Titulo;
        }
    }
}