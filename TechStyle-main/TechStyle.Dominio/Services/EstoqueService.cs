﻿using System;
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
    public class EstoqueService : IEstoqueService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public EstoqueService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public bool CadastrarProdutoNoEstoque(EstoqueDTO dto)
        {
            Produto produtoValidador = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(dto.IdProduto);
            Estoque estoqueValidador = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(produtoValidador.Id);

            if (estoqueValidador == null)
            {
                Estoque produto = new();
                produto.IdProduto = dto.IdProduto;
                produto.Local = dto.Local;
                produto.QuantidadeMin = dto.QuantidadeMin;
                produto.Quantidade = 0;
                _bibliotecaRepositorio.EstoqueRepositorio.Incluir(produto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarLocal(int idEstoque, string local) 
        {
            Estoque estoque = _bibliotecaRepositorio.EstoqueRepositorio.SelecionarPorId(idEstoque);

            if (string.IsNullOrEmpty(local.Trim()))
            {
                return false;
            }
            else
            {
                estoque.Local = local;
                return _bibliotecaRepositorio.EstoqueRepositorio.Alterar(estoque);
            }
        }

        public bool AlterarQuantidadeMinima(int idEstoque, double valor) 
        {
            Estoque estoque = _bibliotecaRepositorio.EstoqueRepositorio.SelecionarPorId(idEstoque);

            if (valor <= 0)
            {
                return false;
            }
            else
            {
                estoque.QuantidadeMin = valor;
                return _bibliotecaRepositorio.EstoqueRepositorio.Alterar(estoque);
            }
        }

        public List<Estoque> SelecionarTudo()
        {
            return _bibliotecaRepositorio.EstoqueRepositorio.SelecionarTudo();
        }

        public Estoque SelecionarPorId(int id)
        {
            return _bibliotecaRepositorio.EstoqueRepositorio.SelecionarPorId(id);
        }

        public void SomarEstoque(int id, int quant)
        {
            Estoque estoque = _bibliotecaRepositorio.EstoqueRepositorio.SelecionarPorId(id);
            estoque.Quantidade += quant;
            _bibliotecaRepositorio.EstoqueRepositorio.Alterar(estoque);
        }
    }
}
