using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    public class ContextIndicador: DbContext
    {
        public ContextIndicador()
            : base("DefaultConnection")
        {
        }
        public  DbSet<CategoriaDerecho> CategoriaDerecho { get; set; }
        public  DbSet<Indicador> Indicador { get; set; }
        public  DbSet<Variable> Variable { get; set; }       
    }
}