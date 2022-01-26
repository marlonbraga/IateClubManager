using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Nautico
{
    public class Tripulante : PessoaFisica
    {
        public String CategoriaDeHabilitacao { get; set; }
        public String NumeroDeHabilitacao { get; set; }
    }
}
