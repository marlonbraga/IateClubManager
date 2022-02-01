using System;

namespace Domain.Administrativo
{
    public class Socio : Base
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public TipoPessoa TipoPessoa { get; set; }
        public string Documento { get; set; }
        

    }

    public enum TipoPessoa
    {
        PessoaFisica, PessoaJuridica
    }
}
