using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Administrativo
{
    public class Titulo : Base
    {
        public string NumeroTitulo { get; set; }
        public Socio Socio { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public List<Dependente> Dependentes { get; set; }
        public List<Embarcacao> Embarcacoes { get; set; }
        public List<Advertencia> Advertencias { get; set; }
        public List<CobrancaFinanceira> ListaCobrancaFinanceira { get; set; }
        public List<Tripulante> Tripulantes { get; set; }


    }



    public enum TipoUsuario
    {
        Administrados, Cliente
    }
}
