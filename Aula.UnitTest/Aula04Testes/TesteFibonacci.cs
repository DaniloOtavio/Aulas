using Aula.Lib.Aula04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula.UnitTest.Aula04Testes
{
    public class TesteFibonacci
    {
        [Fact]
        public void TestaFibonacci1()
        {
            var resultado = ExercicioAula04.Fibonacci(10);

            Assert.Equal(new int[11] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 }, resultado);
        }
        [Fact]
        public void TestaFibonacci2()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public void TestaFibonacci3()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public void TestaFibonacci4()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public void TestaFibonacci5()
        {
            throw new NotImplementedException();
        }
    }
}
