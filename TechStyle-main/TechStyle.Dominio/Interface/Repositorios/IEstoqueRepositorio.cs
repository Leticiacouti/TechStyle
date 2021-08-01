using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Interface.Repositorios
{
    public interface IEstoqueRepositorio
    {
        Estoque SelecionarPorId(int id);
        bool Incluir(Estoque estoque);
        bool Alterar(Estoque estoque);
        Estoque PesquisarPorProduto(int idProduto);
        List<Estoque> SelecionarTudo();
    }
}
