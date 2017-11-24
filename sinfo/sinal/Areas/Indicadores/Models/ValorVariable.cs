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
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ValorVariableId { get; set; }

        /// <summary>
        /// LLave foranea de la tabla variable
        /// </summary>
        [Column("VariableId")]
        [Display(Name = "Variable")]
        public int VariableId { get; set; }

        /// <summary>
        /// Fecha registro variable
        /// </summary>
        [Column("Fecha")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Valor variable
        /// </summary>
        [Column("Valor")]
        [Display(Name = "Valor")]
        public int Valor { get; set; }

        /// <summary>
        /// LLave foranea de la tabla institución
        /// </summary>
        [Column("InstitucionId")]
        [Display(Name = "Institución")]
        public int InstitucionId { get; set; }

        /// <summary>
        /// Estado valor variable
        /// </summary>
        [Required]
        [Column("Vigente")]
        [Display(Name = "Vigente")]
        public bool Vigente { get; set; }

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

        #region Funciones calculadas
        /// <summary>
        /// función que calcula la Tasa de mortalidad en menores de un año - Mortalidad Infantil.
        /// </summary>
        public int CalculoIndicadorUno()
        {
            return 0;
        }





        #endregion


    }
}