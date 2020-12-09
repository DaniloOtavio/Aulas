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
        public void CalculaPVMLCProprio()
        {
            decimal pv = Exemplo01.CalculaPV_MLC(50M, 25M);

            Assert.Equal(62.5M, pv);
        }
        [Fact]
        public void CalculaPVMLCExemplo()
        {
            //https://blog.contaazul.com/saiba-como-calcular-a-margem-de-lucro-de-um-produto-e-da-empresa#:~:text=O%20c%C3%A1lculo%20da%20margem%20de,13%20mil%20no%20mesmo%20per%C3%ADodo.

            decimal pv = Exemplo01.CalculaPV_MLC(13_000M, 35M);

            Assert.Equal(17550M, pv);
        }




    }
}
