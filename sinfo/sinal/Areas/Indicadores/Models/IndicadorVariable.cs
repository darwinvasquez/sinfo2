using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    /// <summary>
    /// Tabla que permite unir los indicadores y las variables
    /// </summary>
    [Table("IndicadorVariable")]
    public class IndicadorVariable
    {
        /// <summary>
        /// Autoincromento Indicador Variable
        /// </summary>
        [Column("IndicadorVariableId", Order = 1), Key]
        public int IndicadorVariableId { get; set; }

        /// <summary>
        /// LLave foranea del Indicador
        /// </summary>
        [Column("IndicadorId", Order = 2)]
        public int IndicadorId { get; set; }

        /// <summary>
        /// LLave foranea de la variable
        /// </summary>
        [Column("VariableId", Order = 3)]
        public int VariableId { get; set; }
        
        /// <summary>
        /// Estado de Indicador Variable
        /// </summary>
        [Required]
        [Column("Vigente", Order = 4)]
        public bool Vigente { get; set; }

        #region Propiedades de navegación
        /// <summary>
        /// Propiedad de navegacion hacia el indicador
        /// </summary>
        [ForeignKey("IndicadorId")]
        public virtual Indicadors Indicadors { get; set; }

        /// <summary>
        /// Propiedad de navegacion hacia la variable
        /// </summary>
        [ForeignKey("VariableId")]
        public virtual Variable Variable { get; set; }

        #endregion
    }
}