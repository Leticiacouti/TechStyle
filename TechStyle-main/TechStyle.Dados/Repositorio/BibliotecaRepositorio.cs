using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Interface.Repositorios;
using TechStyle.Dominio.Repositorio;

namespace TechStyle.Dados.Repositorio
{
    public class BibliotecaRepositorio : IBibliotecaRepositorio
    {
        private readonly Contexto _contexto;
        public IEstoqueRepositorio EstoqueRepositorio { get; }
        public IItemDeVendaRepositorio ItemDeVendaRepositorio { get; }
        public IProdutoRepositorio ProdutoRepositorio { get; }
        public ISegmentoRepositorio SegmentoRepositorio { get; }
        public IVendasRepositorio VendasRepositorio { get; }

        public BibliotecaRepositorio(Contexto contexto)
        {
            _contexto = contexto;
            EstoqueRepositorio = new EstoqueRepositorio(contexto);
            ItemDeVendaRepositorio = new ItemDeVendaRepositorio(contexto);
            ProdutoRepositorio = new ProdutoRepositorio(contexto);
            SegmentoRepositorio = new SegmentoRepositorio(contexto);
            VendasRepositorio = new VendasRepositorio(contexto);
        }
    }
}
