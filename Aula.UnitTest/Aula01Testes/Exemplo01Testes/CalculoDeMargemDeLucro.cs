using Aula.Lib.Aula01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula.UnitTest.Aula01Testes.Exemplo01Testes
{
    public class CalculoDeMargemDeLucro
    {
        [Fact]
        public void CalculoLucroExemploExterno()
        {
            //https://blog.contaazul.com/saiba-como-calcular-a-margem-de-lucro-de-um-produto-e-da-empresa#:~:text=Basicamente%2C%20o%20lucro%20%C3%A9%20a,%3D%20receitas%20totais%20%E2%80%93%20custos).
            decimal mk = Exemplo01.CalcularMargemDeLucro(13.000M, 20.000M);

            Assert.Equal(0.35M, mk,4);
        }
        [Fact]
        public void CalculaTesteProprio()
        {
            decimal mk = Exemplo01.CalcularMargemDeLucro(320M, 540M);

            Assert.Equal(0.4074M, mk,4);
        }
        [Fact]
        public void CalculaPVZero()
        {
            decimal mk = Exemplo01.CalcularMargemDeLucro(pc: 13.000M, 0M);

            Assert.Equal(0, mk);
        }
        [Fact]
        public void CalculaPCZero()
        {
            decimal mk = Exemplo01.CalcularMargemDeLucro(0M, 100M);

            Assert.Equal(mk, mk);
        }


    }
}
