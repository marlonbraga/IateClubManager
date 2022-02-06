using Domain.Core;
using Domain.Core.Interfaces;
using System.Collections.Generic;

namespace Domain.Administrativo
{
    public class Tripulante : PessoaFisica, ITripulante
    {
        public string HabilitacaoNautica { get; set; }

        public bool ValidacaoQuantidadeTripulante(List<Tripulante> Tripulantes)
        {
            if (Tripulantes.Count <= 2)
            {
                return true;
            }

            return false;
        }

        public bool ValidaHabilitacaoNautica(Tripulante tripulante)
        {

            if (string.IsNullOrEmpty(tripulante.HabilitacaoNautica))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(tripulante.HabilitacaoNautica))
            {
                return false;
            }

            return true;
        }
    }
}
