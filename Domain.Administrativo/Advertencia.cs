using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Administrativo
{
    public class Advertencia : IAdvertencia
    {
        public bool Impeditiva { get; set; }
        public bool Vigente { get; set; }
        public DateTime DataEmissao { get; set; }
        public String Descricao { get; set; }

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
