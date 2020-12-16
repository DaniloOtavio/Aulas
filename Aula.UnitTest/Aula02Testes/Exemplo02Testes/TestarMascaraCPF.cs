using Xunit;
using Aula.Lib.Aula02;

namespace Aula.UnitTest.Aula02Testes.Exemplo02Testes
{
    public class TestarMascaraCPF
    {
        // Usando os mesmos CPFs do TestarValidadeCPF
        [Fact]
        public void TestaCPF_Mascara()
        {
            string CPF = Exemplo02.AplicarMascaraCPF("28471678039");

            Assert.Equal("284.716.780-39", CPF);
        } 
    }
}
