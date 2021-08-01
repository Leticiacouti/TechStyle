using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.DTO;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Interface.Services
{
    public interface IEstoqueService
    {
        bool CadastrarProdutoNoEstoque(EstoqueDTO dto);
        bool AlterarLocal(int idEstoque, EstoqueDTO dto);
        bool AlterarQuantidadeMinima(int idEstoque, EstoqueDTO dto);
        List<Estoque> SelecionarTudo();
        Estoque SelecionarPorId(int id);
    }
}
