using System;

namespace Aula.Lib.Aula01
{
    public class Exemplo01
    {
        /// <summary>
        /// CalculaMarkup
        /// </summary>
        /// <param name="PC">Preço de Custo</param>
        /// <param name="PV">Preço de Venda</param>
        /// <returns>Retorna o Markup calculado</returns>
        public static decimal CalcularMarkup(decimal PC, decimal PV)
        {
            if (PC == 0) return 0; 
            
            decimal mk = PV / PC;

            return mk;
        }


        public static decimal CalculaLucro(decimal pc, decimal pv)
        {
            if (pv == 0) return 0; 
            if (pv < pc) return 0; 

            decimal LC = pv - pc;
            
            return LC;
        }

        public static decimal CalculaPV_MK(decimal pc, decimal mk)
        {
            decimal PV = pc * mk;

            return PV;
        }

        public static decimal CalculaPV_MLC(decimal pc, decimal mlc)
        {
            if (pc == 0 && mlc == 0) return 0;
            decimal PV = pc + (pc * (mlc / 100));
            
            return PV;
        }

        /// <summary>
        /// Calcular Preço de Venda com Base em Markup
        /// </summary>
        /// <param name="pc">Preço de Custo</param>
        /// <param name="mkup">Markup</param>
        /// <returns>Retorna o preço de venda do produto com base no preço de custo e markup informados</returns>
        public static decimal CalculaPV_MK_Doc(decimal pc, decimal mkup)
        {
            decimal PV = pc * mkup;

            return PV;
        }
    }
}
