using Domain.Administrativo;
using Domain.Core;
using Domain.Core.Interfaces;
using Domain.Nautico;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Responsavel = Domain.Core.Responsavel;

namespace IateClubeManage.Infraestrutura
{
    [TestClass]
    public class NauticoInfraestruturaTestes
    {
        public ITitulo __titulo__;
        public DateTime __dataSaida__;
        public DateTime __dataRetorno__;
        public List<IPassageiro> __passageiros__;
        public IEmbarcacao __embarcacao__;
        public List<ICobrancaFinanceira> __listaCobrancaFinanceira__;
        public List<IAdvertencia> __listaAdvertencia__;

        [TestInitialize]
        public void TestInitialize()
        {
            IResponsavel responsavel = new Responsavel()
            {
                HabilitacaoNautica = new HabilitacaoNautica()
            };
            __dataSaida__ = DateTime.Now;
            __dataRetorno__ = DateTime.Now.AddDays(3);
            __passageiros__ = new() { new Passageiro() };
            __embarcacao__ = new Embarcacao();
            __listaAdvertencia__ = new()
            {
                new Advertencia(false, true),
                new Advertencia(true, false),
                new Advertencia(false, false),
            };
            __listaCobrancaFinanceira__ = new()
            {
                new CobrancaFinanceira(),
                new CobrancaFinanceira(),
                new CobrancaFinanceira(),
            };
            __titulo__ = new Titulo()
            {
                Dependentes = new List<IDependente>(),
                Embarcacoes = new List<IEmbarcacao>() { __embarcacao__ },
                Advertencias = __listaAdvertencia__,
                CobrancasFinanceiras = __listaCobrancaFinanceira__,
                Tripulantes = new List<ITripulante>()
            };
        }

        [TestMethod]
        public async Task CriacaoPlanoDeNavegacao_ParametrosCorretos_Sucesso()
        {
            //Arrange
            List<IPlanoNavegacao> expectedResponse = new List<IPlanoNavegacao>() {
                new PlanoNavegacao(__dataSaida__, __dataRetorno__, "dummyDestino", null, __passageiros__, __embarcacao__, __titulo__)
            };
            NauticoRepository nauticoRepository = new();

            nauticoRepository.CriacaoPlanoDeNavegacao(expectedResponse[0]);

            //Assert
            Assert.AreEqual(1, nauticoRepository.__memoryDatabasePlanosNavegacao__.Count);
        }

        [TestMethod]
        public async Task AcessarHistoricoDeNavegacao_ParametrosCorretos_Sucesso()
        {
            //Arrange
            List<IPlanoNavegacao> expectedResponse = new List<IPlanoNavegacao>() {
                new PlanoNavegacao(__dataSaida__, __dataRetorno__, "dummyDestino", null, __passageiros__, __embarcacao__, __titulo__)
            };
            NauticoRepository nauticoRepository = new();
            nauticoRepository.__memoryDatabasePlanosNavegacao__ = expectedResponse;

            nauticoRepository.CriacaoPlanoDeNavegacao(expectedResponse[0]);

            //Assert
            Assert.AreEqual(2, nauticoRepository.__memoryDatabasePlanosNavegacao__.Count);
        }
    }
}
