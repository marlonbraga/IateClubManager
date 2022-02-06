using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IateClubeManage.Domain.Testes.Dominio.Adminitrativo
{
    [TestClass]
    public class CobrancaFinanceiraTestes
    {
        //[TestMethod]
        //public void ValidaPendenciaFinanceira_PendenciaEm1Meses_Sucesso()
        //{
        //	//Arrange
        //	var cobrancaFinanceira = new CobrancaFinanceira();
        //	List<CobrancaFinanceira> listaCobrancaFinanceira = new()
        //	{
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-4), true),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-3), true),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-2), true),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-1), false),
        //		new CobrancaFinanceira(500, DateTime.Now, true),
        //	};

        //	//Act
        //	bool resposta = cobrancaFinanceira.ValidaPendenciaFinanceira(listaCobrancaFinanceira);

        //	//Assert
        //	Assert.IsTrue(resposta);
        //}

        //[TestMethod]
        //public void ValidaPendenciaFinanceira_PendenciaEm4Meses_Erro()
        //{
        //	//Arrange
        //	var cobrancaFinanceira = new CobrancaFinanceira();
        //	List<CobrancaFinanceira> listaCobrancaFinanceira = new()
        //	{
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-4), false),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-3), true),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-2), true),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-1), true),
        //		new CobrancaFinanceira(500, DateTime.Now, true),
        //	};

        //	//Act
        //	bool resposta = cobrancaFinanceira.ValidaPendenciaFinanceira(listaCobrancaFinanceira);

        //	//Assert
        //	Assert.IsFalse(resposta);
        //}

        //[TestMethod]
        //public void ValidaPendenciaFinanceira_PendenciaEm3Meses_Erro()
        //{
        //	//Arrange
        //	var cobrancaFinanceira = new CobrancaFinanceira();
        //	List<CobrancaFinanceira> listaCobrancaFinanceira = new()
        //	{
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-4), true),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-3), false),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-2), true),
        //		new CobrancaFinanceira(500, DateTime.Now.AddMonths(-1), true),
        //		new CobrancaFinanceira(500, DateTime.Now, true),
        //	};

        //	//Act
        //	bool resposta = cobrancaFinanceira.ValidaPendenciaFinanceira(listaCobrancaFinanceira);

        //	//Assert
        //	Assert.IsFalse(resposta);
        //}
    }
}
