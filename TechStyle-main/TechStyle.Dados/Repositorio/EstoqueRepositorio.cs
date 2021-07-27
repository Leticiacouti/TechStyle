using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class EstoqueRepositorio : BaseRepositorio<Estoque>
    {
       
        public bool Incluir(Produto produto, int qtdMinima, string local)
        {
            var estoque = new Estoque();
            estoque.Cadastrar(produto.Id, qtdMinima, local);

            if (Existe(estoque))
                return false;

            return base.Incluir(estoque);
        }

        public bool AlterarLocal(int id, string local)
        {
            Estoque estoqueEncontrado = SelecionarPorId(id);
            estoqueEncontrado.AlterarLocal(local);
            return base.Alterar(estoqueEncontrado);
        }

        public void AlterarQtdMinima(int id, int qtdMin)
        {
            Estoque estoqueEncontrado = SelecionarPorId(id);
            estoqueEncontrado.AlterarQuantidadeMinima(qtdMin);
            base.Alterar(estoqueEncontrado);
        }

        //Filtro para os itens do produto
        //public List<Segmento> SelecionarPorNome(string nome)
        //{
        //    return listaDeSegmentos.Where(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()).ToList();
        //}

        public List<Estoque> SelecionarTudo()
        {
            return contexto.Estoque.OrderBy(x => x.Id).ToList();
        }

        public Estoque SelecionarPorProduto(Produto produto)
        {
            contexto.Estoque.Include(e => e.Produto).ToList();
            return contexto.Estoque.FirstOrDefault(x => x.Produto.Id == produto.Id);
        }

        public bool Existe(Estoque estoque)
        {
            return contexto.Estoque.Any(x => x.Produto == estoque.Produto);
        }

        
    }
}