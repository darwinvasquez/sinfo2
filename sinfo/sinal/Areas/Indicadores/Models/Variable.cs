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
        public Variable()
        {
            this.Indicador = new HashSet<Indicador>();
        }

        /// <summary>
        /// Autoincromento Variable
        /// </summary>
        [Column("VariableId", Order = 1), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int VariableId { get; set; }
        
        /// <summary>
        /// Nombre variable
        /// </summary>
        [Column("Nombre", Order = 2)]
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La canitdad máxima de caracteres son 255")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Estado de variable
        /// </summary>
        [Required]
        [Column("Vigente", Order = 3)]
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


        /// <summary>
        /// Nombre variable
        /// </summary> 
        [NotMapped]
        [Required]       
        [Display(Name ="Indicador")] 
        public int IndicadorId { get; set; }



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