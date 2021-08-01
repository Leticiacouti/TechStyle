using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Interface.Repositorios
{
    public interface IBaseRepositorio<T>
    {
        T SelecionarPorId(int id);
        List<T> SelecionarTudo();
    }
}
