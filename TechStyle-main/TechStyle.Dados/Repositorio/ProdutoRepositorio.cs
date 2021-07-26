using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>
    {
        public bool Incluir(string nome, string cor, string marca, string modelo, string material,
                            string sku, string tamanho, Segmento segmento, decimal valorVenda)
        {
            var produto = new Produto();
            produto.Cadastrar(nome, material, cor, tamanho, modelo, marca, segmento.Id, sku, valorVenda);

            if (Existe(produto))
                return false;
            
            return base.Incluir(produto);
        }

        public bool Alterar(int id, string nome, string material, string cor, string tamanho, string modelo, 
                            string marca, Segmento segmento, string sku, decimal valorVenda)
        {
            var produtoEncontrado = SelecionarPorId(id);
            Produto produtoNovo = new();
            produtoNovo.Cadastrar(nome, material, cor, tamanho,modelo,marca,segmento.Id,sku,valorVenda);

            if (!Existe(produtoNovo))
            {
                produtoEncontrado.AlterarItemProduto(nome, material, cor, tamanho, modelo, marca, segmento, sku, valorVenda);
                return base.Alterar(produtoEncontrado);
            }

            return false;
        }

        public bool AlterarValorVenda(int id, decimal valor)
        {        
            var produtoEncontrado = SelecionarPorId(id);

            if (produtoEncontrado != null)
            {
                produtoEncontrado.AlterarValorVenda(valor);
                contexto.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<Produto> SelecionarTudo()
        {
            return contexto.Produto.OrderBy(x => x.Id).ToList();
        }

        public bool Existe(Produto produto) //TODO: verificar se é necessario ter produtos com mesmos nomes
        {
            return contexto.Produto.Any(x => x.Nome.Trim().ToLower() == produto.Nome.Trim().ToLower());
        }
    }
}

