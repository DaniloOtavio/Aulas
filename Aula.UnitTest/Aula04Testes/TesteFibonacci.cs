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
            var resultado = ExercicioAula04.Fibonacci(15);

            Assert.Equal(new int[16] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610 }, resultado);
        }
        [Fact]
        public void TestaFibonacci3()
        {
            var resultado = ExercicioAula04.Fibonacci(35);

            Assert.Equal(new int[36] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465 }, resultado);
        }
        [Fact]
        public void TestaFibonacci4()
        {
            var resultado = ExercicioAula04.Fibonacci(46);

            Assert.Equal(new int[47] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903 }, resultado);
        }
        [Fact]
        public void TestaFibonacci5()
        {
            var resultado = ExercicioAula04.Fibonacci(50);

            Assert.Equal(Array.Empty<int>(), resultado);
        }
    }
}
