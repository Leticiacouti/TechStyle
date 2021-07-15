using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class SegmentoRepositorio
    {
        private List<Segmento> listaDeSegmentos; // nossa tabela de mentirinha

        public SegmentoRepositorio()
        {
            listaDeSegmentos = new List<Segmento>();
        }

        public bool Incluir(string categoria, string subcategoria)
        {
            var segmento = new Segmento();
            segmento.Cadastrar(listaDeSegmentos.Count + 1, categoria, subcategoria);

            if (Existe(segmento))
                return false;

            listaDeSegmentos.Add(segmento);
            return true;
        }

        public bool Alterar(int id, Segmento segmento)
        {
            var segmentoEncontrado = SelecionarPorId(id);

            if (Existe(segmento))
                return false;
            else
            {
                
                int indice = listaDeSegmentos.FindIndex(x => x == segmentoEncontrado);
                listaDeSegmentos[indice] = segmento;
                
            } return true;
        }

        public Segmento SelecionarPorId(int id)
        {
            return listaDeSegmentos.FirstOrDefault(x => x.Id == id);
        }

        public List<Segmento> SelecionarPorCategoria(string categoria)
        {
            return listaDeSegmentos.Where(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()).ToList();
        }

       public List<Segmento> SelecionarTudo()
       {
            return listaDeSegmentos.OrderBy(x => x.Categoria).ToList();
       }

        public bool Existe(Segmento segmento)
        {
            return listaDeSegmentos.Any(x => x.Categoria.Trim().ToLower() == segmento.Categoria.Trim().ToLower()
                                            && x.SubCategoria.Trim().ToLower() == segmento.SubCategoria.Trim().ToLower());
            
        }
    }
}
