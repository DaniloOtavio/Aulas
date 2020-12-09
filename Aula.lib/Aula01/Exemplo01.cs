using System;

namespace Aula.Lib.Aula01
{
    public class Exemplo01
    {
        public static decimal CalcularMarkup(decimal PC, decimal PV)
        {
            if (PC == 0) { return 0; }
            
            decimal mk = PV / PC;

            return mk;
        }


        public static decimal CalculaLucro(decimal pc, decimal pv)
        {
            if (pv == 0) { return 0; }
            if (pv < pc) { return 0; }

            decimal LC = pv - pc;
            
            return LC;
        }

        public static decimal CalculaPV_MK(decimal pc, decimal mk)
        {
            decimal PV = pc * mk;

            return PV;
        }

        public static decimal CalculaPV_LC(decimal pc, decimal lc)
        {
            if (lc == 0) { return pc; }
            if (pc == 0) { return lc; }
            
            decimal PV = pc + lc;
             
            return PV;
        }

    }
}
