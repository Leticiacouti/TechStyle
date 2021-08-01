using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Interface.Repositorios;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class SegmentoRepositorio : BaseRepositorio<Segmento>, ISegmentoRepositorio
    {
        private readonly Contexto _contexto;

        public SegmentoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public override bool Incluir(Segmento segmento)
        {
            return base.Incluir(segmento);
        }

        public override bool Alterar(Segmento segmento)
        {
            return base.Alterar(segmento);
        }
        public override List<Segmento> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }
        public override Segmento SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
        public bool ExisteAlteracao(string categoria, string subCategoria)
        {
            return _contexto.Segmento.Any(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()
                                            && x.SubCategoria == subCategoria.Trim().ToUpper());
        }
    }
}
