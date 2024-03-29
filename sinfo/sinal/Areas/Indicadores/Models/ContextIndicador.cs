﻿using System;
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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Indicador>()
        //        .HasMany(up => up.Variable)
        //        .WithMany(varible => varible.Indicador)
        //        .Map( mc =>
        //        {
        //            mc.ToTable("VariableIndicadors");
        //            mc.MapLeftKey("IndicadorId");
        //            mc.MapRightKey("VariableId");
        //        }
        //        );
        //    base.OnModelCreating(modelBuilder);
        //}

        public virtual  DbSet<CategoriaDerecho> CategoriaDerecho { get; set; }
        public virtual DbSet<Indicador> Indicador { get; set; }
        public virtual DbSet<Variable> Variable { get; set; }
        public virtual DbSet<ValorVariable> ValorVariable { get; set; }
        public virtual DbSet<Institucion> Institucion { get; set; }
        public virtual DbSet<Analisis> Analisis { get; set; }
    }
}