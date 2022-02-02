﻿using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface ITitulo
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

    public enum TipoUsuario
    {
        Administrados, Cliente
    }
}
