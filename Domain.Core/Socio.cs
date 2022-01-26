using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Socio
    {
        public String Titular { get; set; }
        public String Telefone { get; set; }
        public String Endereco { get; set; }
        public String HabilitacaoNautica { get; set; }

        public List<Embarcacao> Embarcacoes { get; set; }
    }
}
