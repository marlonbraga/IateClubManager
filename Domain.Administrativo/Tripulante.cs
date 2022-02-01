using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Administrativo
{
    public class Tripulante : Base
    {
        public string HabilitacaoNautica { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }


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
