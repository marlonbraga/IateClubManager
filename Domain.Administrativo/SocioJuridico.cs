using Domain.Administrativo.Interfaces;
using Domain.Core;
using Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResponsavel = Domain.Administrativo.Interfaces.IResponsavel;

namespace Domain.Administrativo
{
	public class SocioJuridico : PessoaJuridica, ISocio
	{
		public IResponsavel Responsavel { get; set; }
	}
}
