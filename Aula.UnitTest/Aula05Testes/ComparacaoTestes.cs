using Aula.Lib.Aula05;
using System;
using System.Linq;
using Xunit;

namespace Aula.UnitTest.Aula05Testes
{
    public class ComparacaoTestes
    {

        [Fact]
        public void Comparacao_Quantidade()
        {
            var valores = new int[] { 0, 1, 2, 3, 4 };
            var resultado = Comparacao.Ordenar(valores);

            Assert.Equal(5, resultado.Length);
        }

        [Fact]
        public void Comparacao_OrdenaNull()
        {
            Assert.Throws<ArgumentNullException>(() => Comparacao.Ordenar(null));
        }
        [Fact]
        public void Comparacao_Ordena0()
        {
            var valores = new int[0];
            var resultado = Comparacao.Ordenar(valores);

            var esperado = new int[0];

            Assert.Equal(esperado, resultado);
        }
        [Fact]
        public void Comparacao_Ordena1()
        {
            var valores = new int[] { 0 };
            var resultado = Comparacao.Ordenar(valores);

            var esperado = new int[] { 0 };

            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void Comparacao_Ordena3()
        {
            var valores = new int[] { 0, 3, 2 };
            var resultado = Comparacao.Ordenar(valores);

            var esperado = new int[] { 0, 2, 3 };

            Assert.Equal(esperado, resultado);
        }
        [Fact]
        public void Comparacao_Ordena5()
        {
            var valores = new int[] { 0, 3, 2, 1, 4 };
            var resultado = Comparacao.Ordenar(valores);

            var esperado = new int[] { 0, 1, 2, 3, 4 };

            Assert.Equal(esperado, resultado);
        }
        [Fact]
        public void Comparacao_Ordena10()
        {
            var valores = new int[] { 0, 3, 2, 1, 4, 7, 12, 9, 15, 16 };
            var resultado = Comparacao.Ordenar(valores);

            var esperado = new int[] { 0, 1, 2, 3, 4, 7, 9, 12, 15, 16 };

            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void Comparacao_OrdenaN()
        {
            Random r = new Random();

            int quantidade = r.Next(2, 20);

            var valores = new int[quantidade];
            for (int i = 0; i < quantidade; i++)
            {
                valores[i] = r.Next();
            }

            var resultado = Comparacao.Ordenar(valores);

            var esperado = valores.OrderBy(o => o).ToArray();

            Assert.Equal(esperado, resultado);
        }

    }
}
