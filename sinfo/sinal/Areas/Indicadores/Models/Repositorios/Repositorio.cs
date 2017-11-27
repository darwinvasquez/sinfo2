using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace sinal.Areas.Indicadores.Models.Repositorios
{
    public class Repositorio<T> where T : class
    {
        private ContextIndicador context = null;

        protected DbSet<T> DbSet { get; set; }

        public Repositorio()
        {
            context = new ContextIndicador();
            DbSet = context.Set<T>();
        }

        public Repositorio(ContextIndicador context)
        {
            this.context = context;
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }   
}