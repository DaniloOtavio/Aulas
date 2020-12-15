using Aula.Lib.Aula01;
using Xunit;

namespace Aula.UnitTest.Aula01Testes.Exemplo01Testes
{
    public class CalculoDeMarkup
    {
        [Fact]
        public void ExemploDoSite01()
        {
            //https://fia.com.br/blog/markup/
            decimal mk = Exemplo01.CalcularMarkup(45M, 91.83M);

            Assert.Equal(2.0407M, mk, 4);
        }
        [Fact]
        public void ExemploDoSite02()
        {
            //https://www.marketingparaindustria.com.br/gestao-vendas/calculo-markup/
            decimal mk = Exemplo01.CalcularMarkup(55M, 99.99M);

            //O ideal seria 1.81, mas com o precision 2 está arredondando - Ver com Rafael
            Assert.Equal(1.818M, mk,4);
        }

        [Fact]
        public void TesteMarkupDivisaoZero()
        {
            decimal mk = Exemplo01.CalcularMarkup(0, 100M);
            Assert.Equal(0M, mk);
        }
        
        [Fact]
        public void TesteMarkupNaoPercentual()
        {
            decimal mk = Exemplo01.CalcularMarkup(50M, 100M);

            Assert.Equal(2M, mk);
        }
        [Fact]
        public void TesteMarkupVendaNaoZero()
        {
            //Testando se o PV zerado também vai dar zero
            decimal mk = Exemplo01.CalcularMarkup(100M, 0M);
            Assert.Equal(0M, mk);
        }

        [Fact]
        public void ExemploProprio()
        {
            decimal mk = Exemplo01.CalcularMarkup(65M, 175M);

            Assert.Equal(2.6923M, mk, 4);
        }
        [Fact]
        public void ExemploSite()
        {
            decimal mk = Exemplo01.CalcularMarkup(70M, 154M);

            Assert.Equal(2.2M, mk,4);
        }

    }
}
