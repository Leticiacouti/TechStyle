using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dominio.Interface.Repositorios;
using TechStyle.Dominio.Interface.Services;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Services
{
    public class VendasService : IVendasService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public VendasService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public List<Vendas> SelecionarTudo()
        {
            return _bibliotecaRepositorio.VendasRepositorio.SelecionarTudo();
        }

        public Vendas SelecionarPorId(int id)
        {
            return _bibliotecaRepositorio.VendasRepositorio.SelecionarPorId(id);
        }

        public bool RealizarVenda(List<ItemDeVendaDTO> dto)
        {
            // Inclusão do objeto venda no repositorio e atribuição dos 'itemvenda' a ele
            Vendas vendas = new();
            _bibliotecaRepositorio.VendasRepositorio.Incluir(vendas);

            List<ItemDeVenda> itemDeVenda = new();

            foreach (var x in dto)
            {
                itemDeVenda.Add(new ItemDeVenda
                {
                    IdProduto = x.IdProduto,
                    Quantidade = x.Quantidade,
                    IdVenda = vendas.Id
                });
            }
            vendas.ItemDeVenda = itemDeVenda;
            _bibliotecaRepositorio.VendasRepositorio.Alterar(vendas);

            // Realização da venda:

            // Calculo de valor total da venda

            var vendaCompleta = _bibliotecaRepositorio.VendasRepositorio.SelecionarPorId(vendas.Id);

            foreach (var iV in vendaCompleta.ItemDeVenda)
            {
                vendaCompleta.ValorTotal += iV.Quantidade * iV.Produto.ValorVenda;
            }
            _bibliotecaRepositorio.VendasRepositorio.Alterar(vendaCompleta);

            // Validação da realização da venda:
            if (VerificarEstoque(itemDeVenda) == 0)
            {
                foreach (ItemDeVenda iV in vendaCompleta.ItemDeVenda)
                {
                    Estoque estoqueVenda = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(iV.IdProduto);
                    estoqueVenda.Quantidade -= iV.Quantidade;
                    _bibliotecaRepositorio.EstoqueRepositorio.Alterar(estoqueVenda);
                }
                vendaCompleta.Realizada = true;
                _bibliotecaRepositorio.VendasRepositorio.Alterar(vendaCompleta);
                return true;
            }
            else
            {
                vendaCompleta.Realizada = false;
                _bibliotecaRepositorio.VendasRepositorio.Alterar(vendaCompleta);
                return false;
            }
        }

        private int VerificarEstoque(List<ItemDeVenda> itemVenda)
        {
            int count = 0;
            foreach (ItemDeVenda x in itemVenda)
            {
                Estoque estoqueVenda = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(x.IdProduto);
                if (estoqueVenda.Quantidade <= x.Quantidade)
                {
                    count += 1;
                }
                else
                    count += 0;
            }
            foreach (ItemDeVenda y in itemVenda)
            {
                Produto produtoVenda = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(y.IdProduto);
                if (produtoVenda.Status == false)
                {
                    count += 1;
                }
            }
            return count;
        }
    }
}
