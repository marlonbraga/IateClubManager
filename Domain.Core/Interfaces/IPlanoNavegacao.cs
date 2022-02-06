using System;
using System.Collections.Generic;

namespace Domain.Core.Interfaces
{
    public interface IPlanoNavegacao
    {
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public string Destino { get; set; }
        public IResponsavel Responsavel { get; set; }
        public List<IPassageiro> Passageiros { get; set; }
        public IEmbarcacao Embarcacao { get; set; }
        public ITitulo Titulo { get; set; }
    }
}
