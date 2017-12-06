using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models

{ 
    /// <summary>
    /// Tabla que permite almacenar los seguimiento de los indicadores
    /// </summary>
    [Table("Analisis")]
    public class Analisis
    {
        /// <summary>
        /// Autoincremento seguimiento
        /// </summary>
        [Column("AnalisisId"), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int SeguimientoId { set; get; }

        /// <summary>
        /// LLave foranea Indicador
        /// </summary>
        [Column("IndicadorId")]
        [Display(Name = "Indicador")]
        public int IndicadorId { get; set; }


        /// <summary>
        /// Descripcion detallada del seguimiento de los indicadores
        /// </summary>
        [Column("Descripcion")]
        [Required]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son {0}")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha en que se crea el registro
        /// </summary>
        [Column("FechaCreacion")]      
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("UsuarioCreacion")]      
        [Display(Name = "Usuario Creacion")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son {0}")]
        public string UsuarioCreacion { get; set; }

        [Column("MaquinaCreacion")]      
        [Display(Name = "Maquina Creacion")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son {0}")]
        public string MaquinaCreacion { get; set; }

        #region Propiedades de Navegacion
        
        /// <summary>
        /// Propiedad de navegacion hacia el indicador
        /// </summary>
        [ForeignKey("IndicadorId")]
        public virtual Indicador Indicador { set; get; }

        #endregion
    }
}