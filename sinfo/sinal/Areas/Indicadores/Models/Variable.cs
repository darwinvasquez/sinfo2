using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    /// <summary>
    /// Tabla que permite registrar las variables
    /// </summary>
    [Table("Variable")]
    public class Variable
    {
        /// <summary>
        /// Autoincromento Variable
        /// </summary>
        [Column("VariableId", Order = 1), Key]
        public int IndicadorId { get; set; }
        
        /// <summary>
        /// Nombre variable
        /// </summary>
        [Column("Nombre", Order = 2)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        public string Nombre { get; set; }

        /// <summary>
        /// Estado de variable
        /// </summary>
        [Required]
        [Column("Vigente", Order = 3)]
        public bool Vigente { get; set; }

        #region Propiedades de navegación
        /// <summary>
        /// Propiedad de navegacion hacia Indicador variable
        /// </summary>       
        public virtual ICollection<Indicador> Indicador { get; set; }

        /// <summary>
        /// Propiedad de navegacion hacia ValorVariable
        /// </summary>       
        public virtual ICollection<ValorVariable> ValorVariable { get; set; }

        #endregion
    }
}