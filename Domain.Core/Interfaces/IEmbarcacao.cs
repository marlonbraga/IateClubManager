using System.Collections.Generic;

namespace Domain.Core.Interfaces
{
    public interface IEmbarcacao
    {
        public string Nome { get; set; }
        public string RegistroMarinha { get; set; }
        public string TamanhoEmbarcacao { get; set; }
        public EMotor TipoMotor { get; set; }
        public ECombustivel TipoCombustivel { get; set; }

        public bool ValidaQuantidadeEmbarcacao(List<IEmbarcacao> embarcacoes);
    }

    public enum TipoVagaEmbarcacao
    {
        Molhada, Seca, Seca_Coberta
    }

    public enum ECombustivel
    {
        Diesel, Gasolina
    }

    public enum EMotor
    {
        Centro, Popa
    }
}
