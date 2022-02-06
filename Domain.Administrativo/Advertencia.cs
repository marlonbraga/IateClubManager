using Domain.Core.Interfaces;
using System;

namespace Domain.Administrativo
{
    public class Advertencia : IAdvertencia
    {
        public bool Impeditiva { get; set; }
        public bool Vigente { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Descricao { get; set; }

        public Advertencia()
        {

        }

        public Advertencia(bool impeditiva, bool vigente)
        {
            Impeditiva = impeditiva;
            Vigente = vigente;
        }

        public Advertencia(bool impeditiva, bool vigente, DateTime dataEmissao, string descricao)
        {
            Impeditiva = impeditiva;
            Vigente = vigente;
            DataEmissao = dataEmissao;
            Descricao = descricao;
        }
    }
}
