using Aula.Lib.Aula04;
using System;
using Xunit;

namespace Aula.UnitTest.Aula04Testes
{
    public class TesteFibonacci
    {
        [Fact]
        public void TestaFibonacci_10()
        {
            var resultado = ExercicioAula04.Fibonacci(10);
            Assert.Equal(10, resultado.Length);
            Assert.Equal(new int[10] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }, resultado);
        }
        [Fact]
        public void TestaFibonacci_15()
        {
            var resultado = ExercicioAula04.Fibonacci(15);

            Assert.Equal(new int[15] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 }, resultado);
        }
        [Fact]
        public void TestaFibonacci_35()
        {
            var resultado = ExercicioAula04.Fibonacci(35);
            Assert.Equal(35, resultado.Length);
            Assert.Equal(new int[35] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887 }, resultado);
        }
        [Fact]
        public void TestaFibonacci_46()
        {
            var resultado = ExercicioAula04.Fibonacci(46);
            Assert.Equal(46, resultado.Length);
            Assert.Equal(new int[46] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170 }, resultado);
        }
        [Fact]
        public void TestaFibonacci_50()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ExercicioAula04.Fibonacci(50));
        }
        [Fact]
        public void TestaFibonacciN()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ExercicioAula04.Fibonacci(-2));
            //var resultado = ExercicioAula04.Fibonacci(-2);

            //Assert.Equal(Array.Empty<int>(), resultado);
        }

        [Fact]
        public void TestaFibonacciZero()
        {
            var resultado = ExercicioAula04.Fibonacci(0);
            Assert.Empty(resultado);
            Assert.Equal(Array.Empty<int>(), resultado);
        }
    }
}
