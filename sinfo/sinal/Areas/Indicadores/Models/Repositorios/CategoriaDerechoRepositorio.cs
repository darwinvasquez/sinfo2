using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models.Repositorios
{
    public class CategoriaDerechoRepositorio : Repositorio<CategoriaDerecho>
    {
        public List<CategoriaDerecho> GetByName(string name)
        {
            return DbSet.Where(a => a.Descripcion.Contains(name)).ToList();
        }
    }
}