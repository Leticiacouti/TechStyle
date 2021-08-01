using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Interface.Repositorios
{
    public interface IProdutoRepositorio
    {
        bool Incluir(Produto produto);
        bool Alterar(Produto produto);
        Produto SelecionarPorId(int id);
        List<Produto> SelecionarTudo();
        Produto ProcurarPorNome(string nome);
    }
}
