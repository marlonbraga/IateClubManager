using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class PessoaJuridica : Usuario
    {
        public String CNPJ { get; set; }
        public String RazaoSocial { get; set; }

    }
}
