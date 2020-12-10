using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Aula.Lib.Aula01;

namespace Aula.UnitTest.Aula01Testes
{
    public class CalculaPVMKDoc
    {
        [Fact]
        public void CalculaPVMkZero()
        {
            decimal pv = Exemplo01.CalculaPV_MK_Doc(100, 0);

            Assert.Equal(0, pv);
        }
        [Fact]
        public void CalculaPVPCZero()
        {
            decimal pv = Exemplo01.CalculaPV_MK_Doc(0, 2M);

            Assert.Equal(0, pv);
        }
    }
}
