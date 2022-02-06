using Domain.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Core.Interfaces
{
    public interface IFactoryPlanoNavegacao
    {
        public INauticoRepository __nauticoRepository__ { get; set; }


        public IPlanoNavegacao CriacaoPlanoDeNavegacao(IResponsavel _responsavel, ITitulo _titulo, IEmbarcacao _embarcacao,
            DateTime _dataSaida, DateTime _dataRetorno, string _destino, List<IPassageiro> _passageiros);
    }
}
