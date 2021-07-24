using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class LojaRepositorio
    {
        public List<Loja> ListaLoja = new List<Loja>();

        public bool Incluir(Produto produto, int qtdMinima)
        {
            var loja = new Loja();
            loja.Cadastrar(produto, qtdMinima);

            if (Existe(loja))
                return false;

            ListaLoja.Add(loja);
            return true;
        }

        public Loja SelecionarPorId(int id)
        {
            return ListaLoja.FirstOrDefault(x => x.Id == id);
        }

        public bool Existe(Loja loja)
        {
            return ListaLoja.Any(x => x.Produto == loja.Produto);
        }
    }
}
