using System.Collections.Generic;

namespace Domain.Administrativo
{
    public class Embarcacao : Base
    {
        public string Nome { get; set; }
        public string RegistroMarinha { get; set; }
        public string TamanhoEmbarcacao { get; set; }
        public EMotor TipoMotor { get; set; }
        public ECombustivel TipoCombustivel { get; set; }
        public TipoVagaEmbarcacao tipoVagaEmbarcacao { get; set; }
        


        public bool ValidaQuantidadeEmbarcacao(List<Embarcacao> embarcacoes)
        {

            if (embarcacoes.Count <= 2)
            {
                return true;
            }

            return false;
        }
    
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