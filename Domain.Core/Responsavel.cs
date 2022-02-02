using Domain.Core;
using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
	public class Responsavel : PessoaFisica, IResponsavel
	{
		public HabilitacaoNautica HabilitacaoNautica { get; set; }
	}
}
