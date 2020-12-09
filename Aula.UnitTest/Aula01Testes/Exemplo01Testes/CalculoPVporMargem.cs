﻿using System;
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



    }
}
