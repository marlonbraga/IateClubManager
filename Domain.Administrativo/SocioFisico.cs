using Domain.Core;
using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResponsavel = Domain.Core.Interfaces.IResponsavel;

namespace Domain.Administrativo
{
	public class SocioFisico : PessoaFisica, ISocio, IResponsavel
	{
		public HabilitacaoNautica HabilitacaoNautica { get; set; }
	}
}
