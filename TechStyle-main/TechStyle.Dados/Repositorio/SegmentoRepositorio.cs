using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class SegmentoRepositorio
    {
        private readonly Contexto contexto;

        public SegmentoRepositorio()
        {
            contexto = new Contexto();
        }

        public bool Incluir(string categoria, string subcategoria)
        {
            var segmento = new Segmento();
            segmento.Cadastrar(categoria, subcategoria);

            if (Existe(segmento))
                return false;

            contexto.Segmento.Add(segmento);
            contexto.SaveChanges();
            return true;
        }

        public bool Alterar(int id, string categoria, string subcategoria)
        {
            var segmentoEncontrado = SelecionarPorId(id);
            //var segmento = new Segmento();
            //segmento.Cadastrar(listaDeSegmentos.Count + 1, categoria, subcategoria);

            if (!Existe(segmentoEncontrado) || ExisteAlteracao(categoria, subcategoria))
            {
                return false;
            }

            segmentoEncontrado.Alterar(categoria, subcategoria);
            contexto.Segmento.Update(segmentoEncontrado);
            contexto.SaveChanges();
            return true;
        }


        public Segmento SelecionarPorId(int id)
        {
            return contexto.Segmento.FirstOrDefault(x => x.Id == id);
        }

        public List<Segmento> SelecionarPorCategoria(string categoria)
        {
            return contexto.Segmento.Where(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()).ToList();
        }

        public List<Segmento> SelecionarTudo()
        {
            return contexto.Segmento.OrderBy(x => x.Categoria).ToList();
        }

        public bool Existe(Segmento segmento)
        {
            return contexto.Segmento.Any(x => x.Categoria.Trim().ToLower() == segmento.Categoria.Trim().ToLower()
                                            && x.SubCategoria.Trim().ToLower() == segmento.SubCategoria.Trim().ToLower());

        }
        public bool ExisteAlteracao(string categoria, string subcategoria)
        {
            return contexto.Segmento.Any(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()
                                            && x.SubCategoria == subcategoria.Trim().ToUpper());
        }
    }
}
