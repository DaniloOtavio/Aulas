using System;

namespace Aula.Lib.Aula01
{
    public class Exemplo01
    {
        public static decimal CalcularMarkup(decimal PC, decimal PV)
        {
            if (PC == 0)
            {
                return 0;
            }

            decimal mk = PV / PC;

            return mk;
        }


        public static decimal CalculaLucro(decimal pc, decimal pv)
        {
            throw new NotImplementedException();
            
        }

        public static decimal CalculaPV_MK(decimal pc, decimal mk)
        {
            throw new NotImplementedException();
        }

        public static decimal CalculaPV_LC(decimal pc, decimal lc)
        {
            throw new NotImplementedException();
        }

    }
}
