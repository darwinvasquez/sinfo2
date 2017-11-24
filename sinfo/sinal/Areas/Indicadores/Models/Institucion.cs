using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    /// <summary>
    /// Tabla que permite almacenar las instituciones
    /// </summary>
    [Table("Institucion")]
    public class Institucion
    {
        /// <summary>
        /// Autoincromento institucion
        /// </summary>
        [Column("InstitucionId"), Key]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstitucionId { get; set; }

        /// <summary>
        /// Nombre institucion
        /// </summary>
        [Required]
        [Column("Nombre")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Estado institucion
        /// </summary>
        [Required]
        [Column("Vigente")]
        [Display(Name = "Vigente")]
        public bool Vigente { get; set; }

        #region Propiedades de navegación
        /// <summary>
        /// Propiedad de navegacion hacia valor variable
        /// </summary>       
        public virtual ICollection<ValorVariable> ValorVariable { get; set; }

        #endregion
    }
}