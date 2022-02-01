using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Administrativo
{
    public class Advertencia
    {
        public TipoAdvertencia TipoAdvertencia { get; set; }
        public bool Vigente { get; set; }


        public bool EImpeditivo(List<Advertencia> ListaAdvertencia)
        {
            foreach (var adv in ListaAdvertencia)
            {
                if (adv.TipoAdvertencia == TipoAdvertencia.Impeditiva)
                    return true;
            }
            
            return false;
        }


    }


    public enum TipoAdvertencia
    {
        Impeditiva, NaoImpeditiva
    }
}
