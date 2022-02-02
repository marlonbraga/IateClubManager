using Domain.Core;
using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (String.IsNullOrEmpty( tripulante.HabilitacaoNautica ))
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace( tripulante.HabilitacaoNautica ))
            {
                return false;
            }

            return true;
        }
    }
}
