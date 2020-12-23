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
        public void TestaMultiploDe2Pares()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(0, 10);

            Assert.Equal(new double[] { 0, 2, 4, 6, 8 }, resultado);
        }
        [Fact]
        public void TestaMultiploDe2Impares()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(7, 21);

            Assert.Equal(new double[] { 8, 10, 12, 14, 16, 18, 20 }, resultado);
        }
        [Fact]
        public void TestaMultiploDe2ParImpar()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(6, 15);

            Assert.Equal(Array.Empty<double>(), resultado);
        }
        [Fact]
        public void TestaMultiploDe2ImparPar()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(3, 18);

            Assert.Equal(Array.Empty<double>(), resultado);
        }
        [Fact]
        public void TestaMultiploDe2InicioMaiorQueFim()
        {
            var resultado = ExercicioAula04.NumerosParesEntre(18, 2);

            Assert.Equal(Array.Empty<double>(), resultado);
        }
    }
}
