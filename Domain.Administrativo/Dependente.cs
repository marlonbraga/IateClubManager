using Domain.Core;
using Domain.Core.Interfaces;
using System;

namespace Domain.Administrativo
{
    public class Dependente : PessoaFisica, IDependente
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public bool ValidaDepententes(Titulo titulo)
        {
            if (titulo.Dependentes.Count <= 2)
            {
                return true;
            }

            return false;
        }

    }
}