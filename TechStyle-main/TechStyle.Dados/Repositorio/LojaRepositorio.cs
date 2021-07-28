using Microsoft.EntityFrameworkCore;
using System.Linq;
using TechStyle.Dominio.Modelo;
using TechStyle.Dominio.Repositorio;

namespace TechStyle.Dados.Repositorio
{
    public class LojaRepositorio : BaseRepositorio<Loja>
    {
        private readonly EstoqueRepositorio _estoqueRepo;

        public LojaRepositorio()
        {
            _estoqueRepo = new();
        }

        public bool Incluir(Produto produto, int qtdMinima)
        {
            var loja = new Loja();
            loja.Cadastrar(produto.Id, qtdMinima);

            if (Existe(loja))
                return false;

            return base.Incluir(loja);
        }

        public void TransferirParaLoja(int idLoja, Estoque estoque, int quantidade) // TODO: Arrumar estoque, nao atualiza no SQL
        {
            var loja = SelecionarPorId(idLoja);
            loja.AdicionarNaLoja(quantidade, estoque);
            base.Alterar(loja);
            _estoqueRepo.Alterar(estoque);
            contexto.SaveChanges();
        }

        public Loja SelecionarPorId(int id)
        {
            contexto.Loja.Include(e => e.Produto).ToList();
            return contexto.Loja.FirstOrDefault(x => x.Id == id);
        }

        public bool Existe(Loja loja)
        {
            return contexto.Loja.Any(x => x.Produto == loja.Produto);
        }
    }
}
