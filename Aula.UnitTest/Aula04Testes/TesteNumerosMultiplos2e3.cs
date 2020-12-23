using Aula.Lib.Aula04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula.UnitTest.Aula04Testes
{
    public class TesteNumerosMultiplos2e3
    {
        [Fact]
        public void TestaMultiplos2e3_1()
        {
            var resultado = ExercicioAula04.NumerosMultiplo2e3Entre(0, 10);

            Assert.Equal(new int[7] { 0, 2, 3, 4, 6, 8, 9 }, resultado);
        }
        [Fact]
        public void TestaMultiplos2e3_2()
        {
            var resultado = ExercicioAula04.NumerosMultiplo2e3Entre(0, 15);

            Assert.Equal(new int[10] { 0, 2, 3, 4, 6, 8, 9, 10, 12, 14 }, resultado);
        }
    }
}
