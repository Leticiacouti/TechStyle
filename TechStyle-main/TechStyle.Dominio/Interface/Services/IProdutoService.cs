using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Interface.Services
{
    public interface IProdutoService
    {
        bool CadastrarProduto(ProdutoDTO dto);
        bool Alterar(int id, ProdutoDTO dto);
        List<Produto> SelecionarTudo();
        Produto SelecionarPorId(int id);
        void AlterarStatus(int id);
        bool Validar(ProdutoDTO dto);
    }
}
