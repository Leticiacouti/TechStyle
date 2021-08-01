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
        bool AlterarLocal(int idEstoque, string local);
        bool AlterarQuantidadeMinima(int idEstoque, double valor);
        List<Estoque> SelecionarTudo();
        Estoque SelecionarPorId(int id);
        void SomarEstoque(int id, int quant); //todo adicionei
    }
}
