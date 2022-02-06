using Domain.Core;
using Domain.Core.Interfaces;
using System.Collections.Generic;

namespace Domain.Administrativo
{
    public class FactoryTitulo
    {
        public ITitulo CadastrarTitulo(string _numero, ISocio _socio, TipoUsuario _tipoUsuario)
        {
            return new Titulo()
            {
                NumeroTitulo = _numero,
                Socio = _socio,
                TipoUsuario = _tipoUsuario,
                Dependentes = new List<IDependente>(),
                Embarcacoes = new List<IEmbarcacao>(),
                Advertencias = new List<IAdvertencia>(),
                CobrancasFinanceiras = new List<ICobrancaFinanceira>(),
                Tripulantes = new List<ITripulante>()
            };
        }

        public ITitulo CadastrarTitulo(string _numero, ISocio _socio, TipoUsuario _tipoUsuario, List<IDependente> _dependente, List<IEmbarcacao> _embarcacao, List<ITripulante> _tripulante)
        {
            return new Titulo()
            {
                NumeroTitulo = _numero,
                Socio = _socio,
                TipoUsuario = _tipoUsuario,
                Dependentes = _dependente,
                Embarcacoes = _embarcacao,
                Advertencias = new List<IAdvertencia>(),
                CobrancasFinanceiras = new List<ICobrancaFinanceira>(),
                Tripulantes = _tripulante
            };
        }

        public ITitulo CadastraDependentes(ITitulo _titulo, List<IDependente> _dependentes)
        {
            ITitulo novoTitulo = _titulo;
            _titulo.Dependentes = _dependentes;
            return novoTitulo;
        }

        public ITitulo CadastraTripulantes(ITitulo _titulo, List<ITripulante> _tripulantes)
        {
            ITitulo novoTitulo = _titulo;
            _titulo.Tripulantes = _tripulantes;
            return novoTitulo;
        }

        public ITitulo CadastraEmbarcacao(ITitulo _titulo, List<IEmbarcacao> _embarcacoes)
        {
            ITitulo novoTitulo = _titulo;
            _titulo.Embarcacoes = _embarcacoes;
            return novoTitulo;
        }
    }
}
