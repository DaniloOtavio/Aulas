using System;

namespace Aula.Lib.Aula01
{   
    /// <summary>
    /// Classe feita para aprender a calcular Margem de Lucro, Markup e Preço de Venda utilizando-se dos dois métodos de precificação anteriores
    /// </summary>
    public static class Exemplo01
    {
        #region CalcularMarkup
        /// <summary>
        /// CalculaMarkup
        /// </summary>
        /// <param name="PC">Preço de Custo</param>
        /// <param name="PV">Preço de Venda</param>
        /// <returns>Retorna o Markup calculado</returns>
        public static decimal CalcularMarkup(decimal PC, decimal PV)
        {
            if (PC == 0) return 0;

            //https://www.logaster.com.br/profit-margin-calculator/
            decimal mk = 1 + ((PV - PC) / PC);

            return mk;
        }
        #endregion
        #region CalcularMargemDeLucro
        /// <summary>
        /// CalculaMargemDeLucro
        /// </summary>
        /// <param name="pc">Preço de Custo</param>
        /// <param name="pv">Preço de Venda</param>
        /// <returns>Retorna a Margem de Lucro calculada</returns>
        public static decimal CalcularMargemDeLucro(decimal pc, decimal pv)
        {
            if (pv == 0) return 0; 
            if (pv < pc) return 0;

            decimal Lucro = (pv - pc) / pv;

            return Lucro;
        }
        #endregion
        #region CalcularPV_Markup
        /// <summary>
        /// CalcularPreçoDeVendaMarkup
        /// </summary>
        /// <param name="pc">Preço de Custo</param>
        /// <param name="mk">Markup</param>
        /// <returns>Retorna o preço de venda calculado através do Markup</returns>
        public static decimal CalcularPV_Markup(decimal pc, decimal mk)
        {
            decimal PV = pc * mk;

            return PV;
        }
        #endregion
        #region CalcularPV_MargemDeLucro
        /// <summary>
        /// CalcularPreçoDeVendaMargemDeLucro
        /// </summary>
        /// <param name="pc">Preço de Custo</param>
        /// <param name="mlc">Margem de Lucro</param>
        /// <returns>Retorna o preço de venda calculado através da Margem de Lucro</returns>
        public static decimal CalcularPV_MargemDeLucro(decimal pc, decimal mlc)
        {

            decimal PV = pc * (1 + (mlc / 100));
            
            return PV;
        }
        #endregion
    }
}
