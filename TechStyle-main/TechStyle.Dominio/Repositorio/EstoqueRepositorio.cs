using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class EstoqueRepositorio
    {
        public List<Estoque> listaEstoque;
        public EstoqueRepositorio()
        {
            listaEstoque = new List<Estoque>();
        }

        public bool Incluir(Produto produto, int qtdMinima, string local)
        {
            var estoque = new Estoque();
            estoque.Cadastrar(produto, qtdMinima, local);

            if (Existe(estoque))
                return false;

            listaEstoque.Add(estoque);
            return true;
        }

        public bool AlterarLocal(int id, string local)
        {
            Estoque estoqueEncontrado = new();
            estoqueEncontrado = SelecionarPorId(id);
            estoqueEncontrado.AlterarLocal(local);
            return true;
        }

        public void AlterarQtdMinima(int id, int qtdMin)
        {
            Estoque estoqueEncontrado = new();
            estoqueEncontrado = SelecionarPorId(id);
            estoqueEncontrado.AlterarQuantidadeMinima(qtdMin);
        }

        public Estoque SelecionarPorId(int id)
        {
            return listaEstoque.FirstOrDefault(x => x.Id == id);
        }

        //Filtro para os itens do produto
        //public List<Segmento> SelecionarPorNome(string nome)
        //{
        //    return listaDeSegmentos.Where(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()).ToList();
        //}

        public List<Estoque> SelecionarTudo()
        {
            return listaEstoque.OrderBy(x => x.Id).ToList();
        }

        public bool Existe(Estoque estoque)
        {
            return listaEstoque.Any(x => x.Produto == estoque.Produto);
        }

        public void TransferirParaLoja(int id, int qtd) 
        {
            Estoque estoqueEncontrado = SelecionarPorId(id);
            
            estoqueEncontrado.QuantidadeLocal -= qtd;
        }
    }
}

