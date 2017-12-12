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
    [Table("Indicador")]
    public class Indicador
    {
        public Indicador()
        {
            this.Variable = new HashSet<Variable>();
        }
        /// <summary>
        /// Autoincromento Indicador
        /// </summary>
        [Column("IndicadorId", Order =1), Key]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndicadorId { get; set; }

        /// <summary>
        /// Categoria del derecho asociado al indicador
        /// </summary>        
        [Column("CategoriaDerechoId", Order =2)]
        [Display(Name = "Categoría")]
        public int CategoriaDerechoId { get; set; }

        ///// <summary>
        ///// Numero indicador
        ///// </summary>        
        [Column("Numero", Order = 3)]
        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        ///// <summary>
        ///// Nombre del indicador
        ///// </summary>
        [Column("Nombre", Order = 4)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        ///// <summary>
        ///// Objectivo del indicador
        ///// </summary>
        [Column("Objetivo", Order = 5)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "Objectivo")]
        public string Objetivo { get; set; }

        ///// <summary>
        ///// Ciclos vitales que cubre el indicador
        ///// </summary>
        [Column("CicloVital", Order = 6)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "Ciclo Vital")]
        public string CicloVital { get; set; }

        ///// <summary>
        ///// Definicion del indicador
        ///// </summary>
        [Column("Definicion", Order = 7)]
        [Required]
        [StringLength(4000, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 4000")]
        [Display(Name = "Definición")]
        public string Definicion { get; set; }

        ///// <summary>
        ///// Interpretacion del indicador
        ///// </summary>
        [Column("Interpretacion", Order = 8)]
        [Required]
        [StringLength(4000, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 4000")]
        [Display(Name = "Interpretación")]
        public string Interpretacion { get; set; }

        ///// <summary>
        ///// Informacion adicional del indicador
        ///// </summary>
        [Column("InformacionAdicional", Order = 9)]
        [StringLength(4000, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 4000")]
        [Display(Name = "Información Adicional")]
        public string InformacionAdicional { get; set; }

        ///// <summary>
        ///// Formula del indicador
        ///// </summary>
        [Column("Formula", Order = 10)]
        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 500")]
        [Display(Name = "Fórmula")]
        public string Formula { get; set; }

        ///// <summary>
        ///// Unidad de medida del indicador
        ///// </summary>
        [Column("UnidadMedida", Order = 11)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "Unidad Medida")]
        public string UnidadMedida { get; set; }        

        ///// <summary>
        ///// Estado del indicador
        ///// </summary>
        [Required]
        [Column("Vigente", Order = 14)]
        [Display(Name = "Vigente")]
        public bool Vigente { get; set; }

        ///// <summary>
        ///// Usuario crea
        ///// </summary>
        [Column("UsuarioCreacion")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "UsuarioCreacion")]
        public string UsuarioCreacion { get; set; }

        ///// <summary>
        ///// Fecha crea
        ///// </summary>
        [Column("FechaCreacion")]
        [Display(Name = "FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        ///// <summary>
        ///// Maquina crea
        ///// </summary>
        [Column("MaquinaCreacion")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son {0}")]
        [Display(Name = "MaquinaCreacion")]
        public string MaquinaCreacion { get; set; }

        #region Propiedades de navegación
        /// <summary>
        /// Propiedad de navegacion hacia la categoria de derecho del indicador
        /// </summary>
        [ForeignKey("CategoriaDerechoId")]
        public virtual CategoriaDerecho CategoriaDerecho { get; set; }

        /// <summary>
        /// Propiedad de navegacion hacia Indicador variable
        /// </summary>       
        public virtual ICollection<Variable> Variable { get; set; }

        /// <summary>
        /// Propiedad de navegacion hacia análisis
        /// </summary>       
        public virtual ICollection<Analisis> Analisis { get; set; }

        #endregion

    }
}