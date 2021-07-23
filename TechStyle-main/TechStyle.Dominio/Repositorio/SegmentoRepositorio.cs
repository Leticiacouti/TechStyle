using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class SegmentoRepositorio
    {
        public  List<Segmento> listaDeSegmentos;

        public SegmentoRepositorio()
        {
            listaDeSegmentos = new List<Segmento>();
        }
        
        public bool Incluir(string categoria, string subcategoria)
        {
            var segmento = new Segmento();
            segmento.Cadastrar(categoria, subcategoria);

            if (Existe(segmento))
                return false;

            listaDeSegmentos.Add(segmento);
            return true;
        }

        public bool Alterar(string categoria, string subCategoria, int id)
        {
            var segmentoEncontrado = SelecionarPorId(id);

            Segmento segmentoLista = listaDeSegmentos.Find(x => x.Categoria == categoria && x.SubCategoria == subCategoria);
            if(segmentoLista != null)
            {
                if (Existe(segmentoLista))
                    return false;
            }
            else
                segmentoEncontrado.Alterar(categoria, subCategoria);
                return true;
            /*
             
                1, feminino, praia
                2, feminino, social
                3, feminino, fitness

            procurar item na lista por id

            SegmentoRepo.VericarDuplicidade(feminino, lingerie)
            Segmento.Alterar( 3, feminino, lingerie)




            */


            /*  var segmentoEncontrado = SelecionarPorId(id);

                if (segmentoEncontrado != null)
                {
                    if(Existe(segmentoEncontrado) != true)
                    {
                        Segmento seg = new Segmento();
                     segmentoEncontrado.Categoria = string.IsNullOrEmpty(categoria.Trim()) ? Categoria : categoria;
                     segmentoEncontrado.SubCategoria = string.IsNullOrEmpty(subCategoria.Trim()) ? SubCategoria : subCategoria;
                    }
                }*/
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
