using Application;
using Domain.Administrativo;
using Domain.Core;
using Domain.Core.Interfaces;
using Domain.Core.Interfaces.Repositories;
using Domain.Nautico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Responsavel = Domain.Core.Responsavel;

namespace IateClubeManage.Aplicação
{
    [TestClass]
    public class NauticoApplicationTestes
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
            PlanoNavegacao expectedResponse = new PlanoNavegacao(DateTime.Now, DateTime.Now, "dummyDestino", null, null, null, null);
            Mock<INauticoRepository> nauticoRepository = new Mock<INauticoRepository>();
            nauticoRepository.Setup(w => w.CriacaoPlanoDeNavegacao(It.IsAny<IPlanoNavegacao>()));
            //.ReturnsAsync(expectedResponse);

            Mock<IFactoryPlanoNavegacao> factoryPlanoNavegacao = new Mock<IFactoryPlanoNavegacao>();
            factoryPlanoNavegacao.Setup(w => w.CriacaoPlanoDeNavegacao(It.IsAny<IResponsavel>(), It.IsAny<ITitulo>(), It.IsAny<IEmbarcacao>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<List<IPassageiro>>()))
                .Returns(expectedResponse);

            NauticoApplication nauticoApplication = new(nauticoRepository.Object, factoryPlanoNavegacao.Object);
            IPlanoNavegacao planoNavegacao = nauticoApplication.CriacaoPlanoDeNavegacao(null, null, null, DateTime.Now, DateTime.Now, "dummyDestino", null);

            //Assert
            Assert.IsNotNull(planoNavegacao);
        }

        [TestMethod]
        public async Task AcessarHistoricoDeNavegacao_ParametrosCorretos_Sucesso()
        {
            //Arrange
            List<IPlanoNavegacao> expectedResponse = new List<IPlanoNavegacao>() {
                new PlanoNavegacao(__dataSaida__, __dataRetorno__, "dummyDestino", null, __passageiros__, __embarcacao__, __titulo__)
            };
            Mock<INauticoRepository> nauticoRepository = new Mock<INauticoRepository>();
            nauticoRepository.Setup(w => w.AcessarHistoricoDeNavegacao(It.IsAny<ITitulo>()))
                .Returns(expectedResponse);

            NauticoApplication nauticoApplication = new(nauticoRepository.Object);
            List<IPlanoNavegacao> historico = nauticoApplication.AcessarHistoricoDeNavegacao(__titulo__);

            //Assert
            Assert.IsNotNull(historico);
        }
    }
}
