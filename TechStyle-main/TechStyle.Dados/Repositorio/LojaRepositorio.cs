using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class LojaRepositorio : BaseRepositorio<Loja>
    {
        public bool Incluir(Produto produto, int qtdMinima)
        {
            var loja = new Loja();
            loja.Cadastrar(produto, qtdMinima);

            if (Existe(loja))
                return false;

            base.Incluir(loja);
            return true;
        }

        public Loja SelecionarPorId(int id)
        {
            return contexto.Loja.FirstOrDefault(x => x.Id == id);
        }

        public bool Existe(Loja loja)
        {
            return contexto.Loja.Any(x => x.Produto == loja.Produto);
        }
    }
}
