using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Interface.Repositorios
{
    public interface ISegmentoRepositorio
    {
        bool Incluir(Segmento segmento);
        bool Alterar(Segmento segmento);
        Segmento SelecionarPorId(int id);
        List<Segmento> SelecionarTudo();
        bool ExisteAlteracao(string categoria, string subCategoria);

    }
}
