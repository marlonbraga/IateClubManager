using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Nautico
{
    public class PlanoNavegacao
    {
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public String Destino { get; set; }
        public Responsavel Responsavel { get; set; }
        public List<Passageiro> Passageiros { get; set; }

        public Socio Socio { get; set; }
        public Embarcacao Embarcacao { get; set; }

        public PlanoNavegacao(DateTime DataSaida, DateTime DataRetorno, String Destino, Responsavel Responsavel, List<Passageiro> Passageiros)
        {
            this.DataSaida = DataSaida;
            this.DataRetorno = DataRetorno;
            this.Destino = Destino;
            this.Responsavel = Responsavel;
            this.Passageiros = Passageiros;
        }

        private bool ValidarEmbarcacao(Embarcacao Embarcacao)
        {
            List<Embarcacao> EmbarcacoesValidas = Socio.Embarcacoes;

            Embarcacao retorno = EmbarcacoesValidas.Find(x => x==Embarcacao);
            if (retorno == null)
                return false;
           return true;
        }

        private bool ValidarUsuario(Usuario Usuario)
        {
            //TODO: Fazer isso aqui
            return true;
        }


        private bool ValidarFinanceiro()
        {
            //TODO: Fazer isso aqui
            return true;
        }


        private bool ValidarAdvertencia()
        {
            //TODO: Fazer isso aqui
            return true;
        }
    }
}