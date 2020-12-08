using Aula.Lib.Aula01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aula.UnitTest.Aula01Testes.Exemplo01Testes
{
    public class CalculoLucroTestes
    {
        [Fact]
        public void CalculoLucroExemploExterno()
        {
            //https://blog.contaazul.com/saiba-como-calcular-a-margem-de-lucro-de-um-produto-e-da-empresa#:~:text=Basicamente%2C%20o%20lucro%20%C3%A9%20a,%3D%20receitas%20totais%20%E2%80%93%20custos).
            decimal mk = Exemplo01.CalculaLucro(13.000M, 20.000M);

            Assert.Equal(7.000M, mk);
        }
        [Fact]
        public void CalculaTesteProprio()
        {
            decimal mk = Exemplo01.CalculaLucro(320M, 540M);

            Assert.Equal(220M, mk);
        }
        [Fact]
        public void CalculaPVZero()
        {
            decimal mk = Exemplo01.CalculaLucro(pc: 13.000M, 0M);

            Assert.Equal(0, mk);
        }
        [Fact]
        public void CalculaPCZero()
        {
            decimal mk = Exemplo01.CalculaLucro(0M, 100M);

            Assert.Equal(mk, mk);
        }


    }
}
