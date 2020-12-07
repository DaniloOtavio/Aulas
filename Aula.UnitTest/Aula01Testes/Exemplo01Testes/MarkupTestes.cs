using Aula.Lib.Aula01;
using Xunit;

namespace Aula.UnitTest.Aula01Testes.Exemplo01Testes
{
    public class MarkupTestes
    {
        [Fact]
        public void TesteMarkupExemploDoSite()
        {
            decimal mk = Exemplo01.CalcularMarkup(45M, 91.83M);

            Assert.Equal(2.04M, mk, 2);
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

    }
}
