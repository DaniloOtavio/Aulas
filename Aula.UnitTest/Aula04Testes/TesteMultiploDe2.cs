using Aula.Lib.Aula04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Aula.UnitTest.Aula04Testes
{
    public class TesteMultiploDe2
    {
        [Fact]
        public void TestaNumerosPares1()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(0, 10);

            Assert.Equal(new double[] { 0, 2, 4, 6, 8 }, resultado);
        }
        [Fact]
        public void TestaNumerosPares2()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(7, 25);

            Assert.Equal(new double[] { 8,10,12,14,16,18,20,22,24 }, resultado);
        }
        [Fact]
        public void TestaNumerosPares3()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(105, 108);

            Assert.Equal(new double[] { 106 }, resultado);
        }
        [Fact]
        public void TestaNumerosPares4()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(199, 220);

            Assert.Equal(new double[] { 200, 202, 204, 206, 208, 210, 212, 214, 216, 218 }, resultado);
        }
    }
}
