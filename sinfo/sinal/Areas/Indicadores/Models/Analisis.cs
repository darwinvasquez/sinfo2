using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    /// <summary>
    /// Tabla que permite registrar los analisis de los indicadores
    /// </summary>
    [Table("Analisis")]
    public class Analisis
    {
        /// <summary>
        /// Autoincromento Analisis
        /// </summary>
        [Column("AnalisisId"), Key]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnalisisId { get; set; }

        /// <summary>
        /// Llave foranea del indicador
        /// </summary>        
        [Column("IndicadorId")]
        [Display(Name = "Indicador")]
        public int IndicadorId { get; set; }

        ///// <summary>
        ///// Descripion del analisis
        ///// </summary>
        [Column("Descripcion")]
        [Required]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        ///// <summary>
        ///// Estado del registro
        ///// </summary>
        [Column("Vigente")] 
        [Display(Name = "Vigente")]
        public bool Vigente { get; set; }

        ///// <summary>
        ///// Usuario crea analisis
        ///// </summary>
        [Column("UsuarioCreacion")]      
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "UsuarioCreacion")]
        public string UsuarioCreacion { get; set; }

        ///// <summary>
        ///// Fecha crea analisis
        ///// </summary>
        [Column("FechaCreacion")]       
        [Display(Name = "FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        ///// <summary>
        ///// Maquina crea analisis
        ///// </summary>
        [Column("MaquinaCreacion")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son {0}")]
        [Display(Name = "MaquinaCreacion")]
        public string MaquinaCreacion { get; set; }

        #region Propiedades de navegación
        /// <summary>
        /// Propiedad de navegacion hacia los indicador
        /// </summary>
        [ForeignKey("IndicadorId")]
        public virtual Indicador Indicador { get; set; }
        #endregion

    }
}