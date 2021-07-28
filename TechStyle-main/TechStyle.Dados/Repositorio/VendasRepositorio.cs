using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class VendasRepositorio : BaseRepositorio<Vendas>
    {
        private readonly ProdutoRepositorio _prodRepo = new();

        public void Incluir()
        {
            var venda = new Vendas();
            base.Incluir(venda);
        }
    }
}
