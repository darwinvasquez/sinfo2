using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    /// <summary>
    /// Tabla que permite registrar los indicadores
    /// </summary>
    [Table("Indicadors")]
    public class Indicadors
    {
        /// <summary>
        /// Autoincromento Indicador
        /// </summary>
        [Column("IndicadorId", Order = 1), Key]
        public int IndicadorId { get; set; }

        /// <summary>
        /// Categoria del derecho asociado al indicador
        /// </summary>        
        [Column("CategoriaDerechoId", Order = 2)]
        public int CategoriaDerechoId { get; set; }

        /// <summary>
        /// Numero indicador
        /// </summary>        
        [Column("Numero", Order = 3)]
        [Required]
        public int Numero { get; set; }

        /// <summary>
        /// Nombre del indicador
        /// </summary>
        [Column("Nombre", Order = 4)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        public string Nombre { get; set; }

        /// <summary>
        /// Objectivo del indicador
        /// </summary>
        [Column("Objetivo", Order = 5)]
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 100")]
        public string Objetivo { get; set; }

        /// <summary>
        /// Ciclos vitales que cubre el indicador
        /// </summary>
        [Column("CicloVital", Order = 6)]
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 100")]
        public string CicloVital { get; set; }

        /// <summary>
        /// Definicion del indicador
        /// </summary>
        [Column("Definicion", Order = 7)]
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 100")]
        public string Definicion { get; set; }

        /// <summary>
        /// Interpretacion del indicador
        /// </summary>
        [Column("Interpretacion", Order = 8)]
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 100")]
        public string Interpretacion { get; set; }

        /// <summary>
        /// Informacion adicional del indicador
        /// </summary>
        [Column("InformacionAdicional", Order = 9)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 500")]
        public string InformacionAdicional { get; set; }

        /// <summary>
        /// Formula del indicador
        /// </summary>
        [Column("Formula", Order = 10)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        public string Formula { get; set; }

        /// <summary>
        /// Unidad de medida del indicador
        /// </summary>
        [Column("UnidadMedida", Order = 11)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        public string UnidadMedida { get; set; }
        
        /// <summary>
        /// Fuente del indicador:
        /// </summary>
        [Column("Fuente", Order = 12)]
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 200")]
        public string Fuente { get; set; }

        /// <summary>
        /// Origen del indicador: corresponde al unidad que la generar (Nacional o Local)
        /// </summary>
        [Column("Origen", Order = 13)]
        [Required]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 6")]
        public string Origen { get; set; }

        /// <summary>
        /// Estado del indicador
        /// </summary>
        [Required]
        [Column("Vigente", Order = 14)]
        public bool Vigente { get; set; }

        #region Propiedades de navegación
        /// <summary>
        /// Propiedad de navegacion hacia la categoria de derecho del indicador
        /// </summary>
        [ForeignKey("CategoriaDerechoId")]
        public virtual CategoriaDerecho CategoriaDerecho { get; set; }

        #endregion

    }
}