using Domain.Core;
using System;
using System.Collections.Generic;

namespace Domain.Socios
{
    public class Titulo
    {
        public String Numero { get; set; }
        public List<Embarcacao> Embarcacoes { get; set; }
        public String TipoVaga { get; set; }
    }
}
