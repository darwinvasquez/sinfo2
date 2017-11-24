using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sinal.Areas.Indicadores.Models
{
    public class CalculoIndicador
    {
        private ContextIndicador db = new ContextIndicador();

        #region Funciones calculadas
        /// <summary>
        /// función que calcula la Tasa de mortalidad en menores de un año - Mortalidad Infantil.
        /// </summary>
        public int CalculoIndicadorUnoPorAno(int ano)
        {

            /// <summary>
            /// 3 Número de defunciones de mujeres por complicaciones durante el embarazo, parto o puerperio
            /// </summary>                   
            var var3 = db.ValorVariable.Where(x => x.Variable.VariableId == 3 && x.Vigente == true && x.Fecha.Year == ano).Sum(x => x.Valor);
            
            /// <summary>
            /// 4 Número total de nacidos vivos
            /// </summary>
            var var4 = db.ValorVariable.Where(x => x.Variable.VariableId == 4 && x.Vigente == true && x.Fecha.Year == ano).Sum(x => x.Valor);
            int result = (var3 / var4) * 100000;      

            return result;
        }

        #endregion
    }
}