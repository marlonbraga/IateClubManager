using Domain.Administrativo;
using Domain.Core;
using Domain.Core.Interfaces;
using Domain.Nautico;
using Domain.Nautico.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResponsavel = Domain.Core.Interfaces.IResponsavel;
using Responsavel = Domain.Core.Responsavel;

namespace IateClubeManage.Domain.Testes.Dominio.Nautico
{
	[TestClass]
	public class FactoryPlanoNavegacaoTestes
	{
		[TestMethod]
		public void ValidaAdvertencia_SemAdvertenciaSemPendencias_Sucesso()
		{
			FactoryPlanoNavegacao factoryPlanoNavegacao = new();
			IResponsavel responsavel = new Responsavel() {
				HabilitacaoNautica = new HabilitacaoNautica()
			};
			DateTime DataSaida = DateTime.Now;
			DateTime DataRetorno = DateTime.Now.AddDays(3);
			string Destino = "dummyDestino";
			List<IPassageiro> Passageiros = new() {new Passageiro()};
			IEmbarcacao Embarcacao = new Embarcacao();
			List<Advertencia> listaCobrancaFinanceira = new()
			{
				new Advertencia(false, true),
				new Advertencia(true, false),
				new Advertencia(false, false),
			};
			Titulo titulo = new Titulo()
			{
				Dependentes = new List<IDependente>(),
				Embarcacoes = new List<IEmbarcacao>() { Embarcacao },
				Advertencias = new List<IAdvertencia>(),
				CobrancasFinanceiras = new List<ICobrancaFinanceira>(),
				Tripulantes = new List<ITripulante>()
			};

			PlanoNavegacao resposta = factoryPlanoNavegacao.CriacaoPlanoDeNavegacao(responsavel, titulo, Embarcacao,
			DataSaida, DataRetorno, Destino, Passageiros);

			Assert.IsNotNull(resposta);
		}

		[TestMethod]
		public void ValidaAdvertencia_EmbarcacaoErrada_Erro()
		{
			FactoryPlanoNavegacao factoryPlanoNavegacao = new();
			IResponsavel responsavel = new Responsavel()
			{
				HabilitacaoNautica = new HabilitacaoNautica()
			};
			DateTime DataSaida = DateTime.Now;
			DateTime DataRetorno = DateTime.Now.AddDays(3);
			string Destino = "dummyDestino";
			List<IPassageiro> Passageiros = new() { new Passageiro() };
			IEmbarcacao Embarcacao = new Embarcacao();
			List<Advertencia> listaCobrancaFinanceira = new()
			{
				new Advertencia(false, true),
				new Advertencia(true, false),
				new Advertencia(false, false),
			};
			Titulo titulo = new Titulo()
			{
				Dependentes = new List<IDependente>(),
				Embarcacoes = new List<IEmbarcacao>() { new Embarcacao() },
				Advertencias = new List<IAdvertencia>(),
				CobrancasFinanceiras = new List<ICobrancaFinanceira>(),
				Tripulantes = new List<ITripulante>()
			};

			PlanoNavegacao resposta = factoryPlanoNavegacao.CriacaoPlanoDeNavegacao(responsavel, titulo, Embarcacao,
			DataSaida, DataRetorno, Destino, Passageiros);

			Assert.IsNull(resposta);
		}

		[TestMethod]
		public void ValidaAdvertencia_Advertencia_Erro()
		{
			FactoryPlanoNavegacao factoryPlanoNavegacao = new();
			IResponsavel responsavel = new Responsavel()
			{
				HabilitacaoNautica = new HabilitacaoNautica()
			};
			DateTime DataSaida = DateTime.Now;
			DateTime DataRetorno = DateTime.Now.AddDays(3);
			string Destino = "dummyDestino";
			List<IPassageiro> Passageiros = new() { new Passageiro() };
			IEmbarcacao Embarcacao = new Embarcacao();
			List<Advertencia> listaCobrancaFinanceira = new()
			{
				new Advertencia(false, true),
				new Advertencia(true, false),
				new Advertencia(false, false),
			};
			Titulo titulo = new Titulo()
			{
				Dependentes = new List<IDependente>(),
				Embarcacoes = new List<IEmbarcacao>() { Embarcacao },
				Advertencias = new List<IAdvertencia>() { new Advertencia(true, true)},
				CobrancasFinanceiras = new List<ICobrancaFinanceira>(),
				Tripulantes = new List<ITripulante>()
			};

			PlanoNavegacao resposta = factoryPlanoNavegacao.CriacaoPlanoDeNavegacao(responsavel, titulo, Embarcacao,
			DataSaida, DataRetorno, Destino, Passageiros);

			Assert.IsNull(resposta);
		}


		[TestMethod]
		public void ValidaAdvertencia_PendenciaFinanceira_Erro()
		{
			FactoryPlanoNavegacao factoryPlanoNavegacao = new();
			IResponsavel responsavel = new Responsavel()
			{
				HabilitacaoNautica = new HabilitacaoNautica()
			};
			DateTime DataSaida = DateTime.Now;
			DateTime DataRetorno = DateTime.Now.AddDays(3);
			string Destino = "dummyDestino";
			List<IPassageiro> Passageiros = new() { new Passageiro() };
			IEmbarcacao Embarcacao = new Embarcacao();
			List<Advertencia> listaCobrancaFinanceira = new()
			{
				new Advertencia(false, true),
				new Advertencia(true, false),
				new Advertencia(false, false),
			};
			Titulo titulo = new Titulo()
			{
				Dependentes = new List<IDependente>(),
				Embarcacoes = new List<IEmbarcacao>() { Embarcacao },
				Advertencias = new List<IAdvertencia>() { },
				CobrancasFinanceiras = new List<ICobrancaFinanceira>() { new CobrancaFinanceira(200, DateTime.Now.AddMonths(-4), false) },
				Tripulantes = new List<ITripulante>()
			};

			PlanoNavegacao resposta = factoryPlanoNavegacao.CriacaoPlanoDeNavegacao(responsavel, titulo, Embarcacao,
			DataSaida, DataRetorno, Destino, Passageiros);

			Assert.IsNull(resposta);
		}

		[TestMethod]
		public void ValidaAdvertencia_SemHabilitacaoNautica_Erro()
		{
			FactoryPlanoNavegacao factoryPlanoNavegacao = new();
			IResponsavel responsavel = new Responsavel()
			{
				HabilitacaoNautica = null
			};
			DateTime DataSaida = DateTime.Now;
			DateTime DataRetorno = DateTime.Now.AddDays(3);
			string Destino = "dummyDestino";
			List<IPassageiro> Passageiros = new() { new Passageiro() };
			IEmbarcacao Embarcacao = new Embarcacao();
			List<Advertencia> listaCobrancaFinanceira = new()
			{
				new Advertencia(false, true),
				new Advertencia(true, false),
				new Advertencia(false, false),
			};
			Titulo titulo = new()
			{
				Dependentes = new List<IDependente>(),
				Embarcacoes = new List<IEmbarcacao>() { Embarcacao },
				Advertencias = new List<IAdvertencia>() { },
				CobrancasFinanceiras = new List<ICobrancaFinanceira>(),
				Tripulantes = new List<ITripulante>()
			};

			PlanoNavegacao resposta = factoryPlanoNavegacao.CriacaoPlanoDeNavegacao(responsavel, titulo, Embarcacao,
			DataSaida, DataRetorno, Destino, Passageiros);

			Assert.IsNull(resposta);
		}
	}
}
