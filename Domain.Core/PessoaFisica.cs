namespace Domain.Core
{
    public abstract class PessoaFisica
    {
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereço { get; set; }
    }
}
