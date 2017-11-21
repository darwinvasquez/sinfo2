using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    /// <summary>
    /// Tabla que permite almacenar la categoria del indicador
    /// </summary>
    [Table("CategoriaDerecho")]
    public class CategoriaDerecho
    {
        /// <summary>
        /// Autoincromento categoria derecho
        /// </summary>
        [Column("CategoriaDerechoId"), Key]
        public int CategoriaDerechoId { get; set; }

        /// <summary>
        /// Descripcion de la categoria
        /// </summary>
        [Required]
        [Column("Descripcion")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Estado de la categoria
        /// </summary>
        [Required]
        [Column("Vigente")]
        public bool Vigente { get; set; }

        #region Propiedades de navegación

        /// <summary>
        /// Propiedad de navegación hacia el indicador
        /// </summary>
        //
        public List<Indicador> Indicador { get; set; }

        #endregion
    }
}