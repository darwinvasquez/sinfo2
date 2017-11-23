using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    /// <summary>
    /// Tabla que permite almacenar los valores historicos de las variables
    /// </summary>
    [Table("ValorVariable")]
    public class ValorVariable
    {
        /// <summary>
        /// Autoincromento Valor Variable
        /// </summary>
        [Column("ValorVariableId"), Key]
        public int ValorVariableId { get; set; }

        /// <summary>
        /// LLave foranea de la tabla variable
        /// </summary>
        [Column("VariableId")]
        public int VariableId { get; set; }

        /// <summary>
        /// Fecha registro variable
        /// </summary>
        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Valor variable
        /// </summary>
        [Column("Valor")]
        public int Valor { get; set; }

        /// <summary>
        /// LLave foranea de la tabla institución
        /// </summary>
        [Column("InstitucionId")]
        public int InstitucionId { get; set; }

        /// <summary>
        /// Estado valor variable
        /// </summary>
        [Required]
        [Column("Vigente")]
        public bool Vigente { get; set; }


        /// <summary>
        /// Nombre institucion
        /// </summary>
        [Required]
        [Column("Nombre")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        public string Nombre { get; set; }


        #region Propiedades de navegación

        /// <summary>
        /// Propiedad de navegacion hacia la variable
        /// </summary>
        [ForeignKey("VariableId")]
        public virtual Variable Variable { get; set; }

        /// <summary>
        /// Propiedad de navegacion hacia la institucion
        /// </summary>
        [ForeignKey("InstitucionId")]
        public virtual Institucion Institucion { get; set; }

        #endregion
    }
}