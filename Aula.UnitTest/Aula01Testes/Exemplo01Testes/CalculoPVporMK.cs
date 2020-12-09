using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Aula.Lib.Aula01;

namespace Aula.UnitTest.Aula01Testes.Exemplo01Testes
{
    public class CalculoPVporMK
    {
        [Fact]
        public void CalculoPCZero()
        {
            decimal mk = Exemplo01.CalculaPV_MK(0M, 1.35M);

            Assert.Equal(0, mk);
        }[Fact]
        public void CalculoMKZero()
        {
            decimal mk = Exemplo01.CalculaPV_MK(100M, 0);

            Assert.Equal(0, mk);
        }
        [Fact]
        public void CalculoExemploExterno()
        {
            //https://fia.com.br/blog/markup/
            decimal mk = Exemplo01.CalculaPV_MK(45M, 2.04M);

            Assert.Equal(91.83M, mk);
        }
        [Fact]
        public void CalculoExemploProprio()
        {
            decimal mk = Exemplo01.CalculaPV_MK(500, 1.33M);

            Assert.Equal(665M, mk);
        }
    }
}
