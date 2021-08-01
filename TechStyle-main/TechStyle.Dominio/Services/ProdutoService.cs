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
    public class ProdutoService : IProdutoService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public ProdutoService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public bool CadastrarProduto(ProdutoDTO dto)
        {
            Produto produtoValidacao = _bibliotecaRepositorio.ProdutoRepositorio.ProcurarPorNome(dto.Nome.ToLower());

            bool validacao = Validar(dto);


            if (produtoValidacao == null && validacao == true)
            {
                Produto produto = new();
                produto.Nome = dto.Nome.ToLower();
                produto.ValorVenda = (double)dto.ValorVenda;
                produto.Cor = dto.Cor;
                produto.Marca = dto.Marca;
                produto.Material = dto.Material;
                produto.Modelo = dto.Modelo;
                produto.SKU = dto.SKU;
                produto.Tamanho = dto.Tamanho;
                produto.IdSegmento = dto.IdSegmento; 
                produto.Status = false;
                _bibliotecaRepositorio.ProdutoRepositorio.Incluir(produto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Alterar(int id, ProdutoDTO dto)
        {
            Produto produto = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(id);
            Produto nomeValidaocao = _bibliotecaRepositorio.ProdutoRepositorio.ProcurarPorNome(dto.Nome);
            if (nomeValidaocao == null)
            {
                produto.Nome = string.IsNullOrEmpty(dto.Nome.Trim()) ? produto.Nome : dto.Nome.ToLower();
                produto.ValorVenda = (dto.ValorVenda <= 0) ? produto.ValorVenda : (double)dto.ValorVenda;
                produto.SKU = string.IsNullOrEmpty(dto.SKU.Trim()) ? produto.SKU : dto.SKU.ToLower();
                produto.Material = string.IsNullOrEmpty(dto.Material.Trim()) ? produto.Material : dto.Material.ToLower();
                produto.Cor = string.IsNullOrEmpty(dto.Cor.Trim()) ? produto.Cor : dto.Cor.ToLower();
                produto.Marca = string.IsNullOrEmpty(dto.Marca.Trim()) ? produto.Marca : dto.Marca.ToLower();
                produto.Modelo = string.IsNullOrEmpty(dto.Modelo.Trim()) ? produto.Modelo : dto.Modelo.ToLower();
                produto.Tamanho = string.IsNullOrEmpty(dto.Tamanho.Trim()) ? produto.Tamanho : dto.Tamanho.ToLower();
                _bibliotecaRepositorio.ProdutoRepositorio.Alterar(produto);

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Produto> SelecionarTudo()
        {
            return _bibliotecaRepositorio.ProdutoRepositorio.SelecionarTudo();
        }

        public Produto SelecionarPorId(int id)
        {
            return _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(id);
        }

        public void AlterarStatus(int id)
        {
            Produto produto = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(id);

            produto.Status = !produto.Status;

            _bibliotecaRepositorio.ProdutoRepositorio.Alterar(produto);
        }
         public bool Validar(ProdutoDTO dto)
        {
            int count = 0;

            int valorVenda = (dto.ValorVenda <= 0) ? (count+=1) : count;
            int nome = string.IsNullOrEmpty(dto.Nome.Trim()) ? (count += 1) : count;
            int sku = string.IsNullOrEmpty(dto.SKU.Trim()) ? (count += 1) : count;
            int material = string.IsNullOrEmpty(dto.Material.Trim()) ? (count += 1) : count;
            int cor = string.IsNullOrEmpty(dto.Cor.Trim()) ? (count += 1) : count;
            int marca = string.IsNullOrEmpty(dto.Marca.Trim()) ? (count += 1) : count;
            int modelo = string.IsNullOrEmpty(dto.Modelo.Trim()) ? (count += 1) : count;
            int tamanho = string.IsNullOrEmpty(dto.Tamanho.Trim()) ? (count += 1) : count;

            if(count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
