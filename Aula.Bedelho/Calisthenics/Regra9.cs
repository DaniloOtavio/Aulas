using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Bedelho.Calisthenics
{
    public class Regra9
    {
        // No {Getters and Setters}

        void run()
        {
            var jogo = new Jogo();

            //jogo.GolsCasa = 7;
            jogo.MarcarGolCasa();
        }

        public class Jogo
        {
            //public int GolsCasa { get; set; }
            //public int GolsFora { get; set; }

            public int GolsCasa { get; private set; } = 0;
            public int GolsFora { get; private set; } = 0;

            public void MarcarGolCasa() => GolsCasa++;
            public void MarcarGolFora() => GolsFora++;

        }

    }
}
