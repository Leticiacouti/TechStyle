using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Interface.Repositorios
{
    public interface IBibliotecaRepositorio
    {
        public IProdutoRepositorio ProdutoRepositorio { get; }
        public ISegmentoRepositorio SegmentoRepositorio { get; }
        public IEstoqueRepositorio EstoqueRepositorio { get; }
        public IItemDeVendaRepositorio ItemDeVendaRepositorio { get; }
        public IVendasRepositorio VendasRepositorio { get; }
    }
}
