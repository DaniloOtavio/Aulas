using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Aula.Lib.Aula01;

namespace Aula.UnitTest.Aula01Testes.Exemplo01Testes
{
    public class CalculoPVporMargem
    {
        [Fact]
        public void CalculaLCZero()
        {
            decimal LC = Exemplo01.CalculaPV_LC(150M, 0M);

            Assert.Equal(150, LC);
        }
        [Fact]
        public void CalculaPCZero()
        {
            decimal LC = Exemplo01.CalculaPV_LC(0M, 30M);

            Assert.Equal(0, LC);
        }
        [Fact]
        public void CalculaTesteProprio()
        {
            decimal LC = Exemplo01.CalculaPV_LC(300M, 50.75M);

            Assert.Equal(350.75M, LC);
        }

        [Fact]
        public void CalculaTesteExemplo()
        {
            //https://www.shopify.com.br/ferramentas/calculadora-margem-de-lucro (custo 50 / margem 33)
            decimal LC = Exemplo01.CalculaPV_LC(50M, 16.5M);

            Assert.Equal(66.5M, LC);
        }


    }
}
