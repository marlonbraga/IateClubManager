using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public abstract class PessoaFisica
    {
        public String CPF { get; set; }
        public String RG { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Endereço { get; set; }
    }
}
