using Domain.Core;
using Domain.Core.Interfaces;
using System.Collections.Generic;

namespace Domain.Administrativo
{
    public class Titulo : ITitulo
    {
        public string NumeroTitulo { get; set; }
        public ISocio Socio { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public List<IDependente> Dependentes { get; set; }
        public List<IEmbarcacao> Embarcacoes { get; set; }
        public List<IAdvertencia> Advertencias { get; set; }
        public List<ICobrancaFinanceira> CobrancasFinanceiras { get; set; }
        public List<ITripulante> Tripulantes { get; set; }
    }
}
