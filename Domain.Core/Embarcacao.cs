using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Embarcacao
    {
        public String Nome { get; set; }
        public String RegistroMarinha { get; set; }
        public String PorteNautico { get; set; }
        public String TipoMotor { get; set; }
        public String TipoCombustivel { get; set; }
    }
}
