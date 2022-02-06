using Domain.Core;
using Domain.Core.Interfaces;
using System.Collections.Generic;

namespace Infrastructure
{
    public class AdministrativoRepository
    {
        private readonly List<ITitulo> __memoryTitulo__;

        public List<ICobrancaFinanceira> BuscarHistoricoDePagamentos(ITitulo _titulo)
        {
            List<ICobrancaFinanceira> resposta = new();
            foreach (ICobrancaFinanceira cobranca in _titulo.CobrancasFinanceiras)
            {
                if (cobranca.Pago)
                {
                    resposta.Add(cobranca);
                }
            }
            return resposta;
        }

        public void CriarPagamento(ICobrancaFinanceira _cobrancaFinanceira)
        {
            _cobrancaFinanceira.Pago = true;
        }

        public void DeletarPagamento(ICobrancaFinanceira _cobrancaFinanceira)
        {
            _cobrancaFinanceira.Pago = false;
        }

        public ITitulo BuscarTituloPor(ISocio _socio)
        {
            foreach (ITitulo item in __memoryTitulo__)
            {
                if (item.Socio == _socio)
                {
                    return item;
                }
            }
            return null;
        }

        public ITitulo BuscarTituloPor(string _numeroTitulo)
        {
            foreach (ITitulo item in __memoryTitulo__)
            {
                if (item.NumeroTitulo == _numeroTitulo)
                {
                    return item;
                }
            }
            return null;
        }

        public ITitulo CriarTitulo(ITitulo _titulo)
        {
            __memoryTitulo__.Add(_titulo);
            return _titulo;
        }

        public List<ITitulo> BuscarTitulos()
        {
            return __memoryTitulo__;
        }

        public void AtualizarTitulo(ITitulo _tituloAntigo, ITitulo _tituloNovo)
        {
            __memoryTitulo__.Remove(_tituloAntigo);
            __memoryTitulo__.Add(_tituloNovo);
        }

        public void DeletarTitulo(ITitulo _titulo)
        {
            __memoryTitulo__.Remove(_titulo);
        }
    }
}
