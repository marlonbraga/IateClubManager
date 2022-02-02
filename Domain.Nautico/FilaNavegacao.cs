using Domain.Nautico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Nautico
{
	public class FilaNavegacao
	{
		private List<IPlanoNavegacao> Fila { get; set; }

		public void AdicionarNavegacao(IPlanoNavegacao planoDeNavegacao)
		{
			Fila.Add(planoDeNavegacao);
		}
		public List<IPlanoNavegacao> ExibirNavegacoes()
		{
			return Fila;
		}
		public void CancelarNavegacao(IPlanoNavegacao planoDeNavegacao)
		{
			Fila.Remove(planoDeNavegacao);
		}
		public void TrocarPosicao(IPlanoNavegacao planoDeNavegacao, int posicoes)
		{
			int indice = Fila.IndexOf(planoDeNavegacao);
			Fila.RemoveAt(indice);
			Fila.Insert(indice + posicoes, planoDeNavegacao);
		}
		public void LiberarNavegacao(IPlanoNavegacao planoDeNavegacao)
		{
			Fila.Remove(planoDeNavegacao);
		}
	}
}
