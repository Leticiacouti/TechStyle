using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class ProdutoRepositorio
    {
        public List<Produto> listaDeProdutos;
        public ProdutoRepositorio()
        {
            listaDeProdutos = new List<Produto>();
        }

        public bool Incluir(string nome, string cor, string marca, string modelo, string material,
                            string sku, string tamanho, Segmento segmento, decimal valorVenda)
        {
            var produto = new Produto();
            produto.Cadastrar(nome, material, cor, tamanho, modelo, marca, segmento, sku, valorVenda);

            if (Existe(produto))
                return false;

            listaDeProdutos.Add(produto);
            return true;
        }

        public bool Alterar(int id, string nome, string material, string cor, string tamanho, string modelo, 
                            string marca, Segmento segmento, string sku, decimal valorVenda)
        {
            Produto produtoEncontrado = new();
            produtoEncontrado = SelecionarPorId(id);

            Produto produtoLista = new();
            produtoLista = listaDeProdutos.Find(x => x.Nome == nome && x.Material == material && x.Cor == cor
                                                && x.Tamanho == tamanho && x.Modelo == modelo && x.Marca == marca
                                                && x.SKU == sku && x.ValorVenda == valorVenda);

            if (produtoLista != null)
            {
                if (Existe(produtoLista))
                    return false;
            }
            else
                produtoEncontrado.AlterarItemProduto(nome, material, cor, tamanho, modelo, marca, segmento, sku,
                                                     valorVenda);
            return true;
        }

        public bool AlterarValorVenda(int id, decimal valor)
        {        
            var produtoEncontrado = SelecionarPorId(id);

            if (produtoEncontrado != null)
            {
                produtoEncontrado.AlterarValorVenda(valor);
                return true;
            }
            else
                return false;
        }

        public Produto SelecionarPorId(int id)
        {
            return listaDeProdutos.FirstOrDefault(x => x.Id == id);
        }

        //Filtro para os itens do produto
        //public List<Segmento> SelecionarPorNome(string nome)
        //{
        //    return listaDeSegmentos.Where(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()).ToList();
        //}

        public List<Produto> SelecionarTudo()
        {
            return listaDeProdutos.OrderBy(x => x.Id).ToList();
        }

        public bool Existe(Produto produto)
        {
            return listaDeProdutos.Any(x => x.Nome.Trim().ToLower() == produto.Nome.Trim().ToLower() &&
                                       x.Cor.Trim().ToLower() == produto.Cor.Trim().ToLower() &&
                                       x.Marca.Trim().ToLower() == produto.Marca.Trim().ToLower() &&
                                       x.Modelo.Trim().ToLower() == produto.Modelo.Trim().ToLower() &&
                                       x.Material.Trim().ToLower() == produto.Material.Trim().ToLower() &&
                                       x.SKU.Trim().ToLower() == produto.SKU.Trim().ToLower() &&
                                       x.Tamanho.Trim().ToLower() == produto.Tamanho.Trim().ToLower() &&
                                       x.Segmento == produto.Segmento);
        }
    }
}

