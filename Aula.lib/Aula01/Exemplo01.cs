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



    }
}
