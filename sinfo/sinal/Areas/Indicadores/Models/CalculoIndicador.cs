using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sinal.Areas.Indicadores.Models
{
    public class CalculoIndicador
    {
        private ContextIndicador db = new ContextIndicador();

        #region Funciones calculadas
        /// <summary>
        /// función que calcula la Tasa de mortalidad en menores de un año - Mortalidad Infantil.
        /// </summary>
        public double calculoIndicadorUno(int ano)
        {
            //Variables locales
            double var1 = 0;
            double var2 = 0;

            //Validar si existe registro en el año
            bool valVar1 = db.ValorVariable.Where(x => x.Variable.VariableId == 3 && x.Vigente == true).Any(x => x.Fecha.Year == ano);

            if (valVar1)
            {
                //Número de defunciones de mujeres por complicaciones durante el embarazo, parto o puerperio
                var1 = db.ValorVariable.Where(x => x.Variable.VariableId == 3 && x.Fecha.Year == ano && x.Vigente == true).Sum(x => x.Valor);
            }
            else
            {
                var1 = 0;
            }

            // Validar si existe el año
            bool valVar2 = db.ValorVariable.Where(x => x.Variable.VariableId == 4 && x.Vigente == true).Any(x => x.Fecha.Year == ano);

            if (valVar2)
            {
                //Número total de nacidos vivos
                var2 = db.ValorVariable.Where(x => x.Variable.VariableId == 4 && x.Fecha.Year == ano && x.Vigente == true).Sum(x => x.Valor);
            }
            else
            {
                var2 = 0;
            }

            double result = ((var1 / var2) * 100000);

            if (Double.IsNaN(result))
            {
                return 0;
            }
            return result;          
        }

        public List<SelectListItem> resultadoIndicadorPorId(int id)
        {
            var ano = new List<SelectListItem>();

            switch (id)
            {
                case 1:
                    var anoInd1 = db.ValorVariable.Where(x => x.Variable.VariableId == 3 || x.Variable.VariableId == 4).GroupBy(s => new { s.Fecha.Year }).Select(x => new { id = x.Key, ano = x.Key.Year }).OrderByDescending(x => x.ano);
                    foreach (var item in anoInd1)
                    {
                        ano.Add(new SelectListItem { Text = Convert.ToString(item.ano), Value = Convert.ToString(calculoIndicadorUno(item.ano)) });
                    } 
                    break;

                case 2:
                    var dat = db.ValorVariable.Where(x => x.Variable.VariableId == 3 || x.Variable.VariableId == 4);
                    break;
            }

            return ano;
        }

        #endregion
    }
}