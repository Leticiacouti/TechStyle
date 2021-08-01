using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Interface.Repositorios;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        private readonly Contexto _contexto;
        public ProdutoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public override bool Incluir(Produto produto)
        {
            return base.Incluir(produto);
        }

        public override bool Alterar(Produto produto)
        {
            return base.Alterar(produto);
        }

        public override Produto SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }

        public override List<Produto> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }

        public Produto ProcurarPorNome(string nome)
        {
            return contexto.Produto.FirstOrDefault(x => x.Nome == nome);
        }
    }
}

