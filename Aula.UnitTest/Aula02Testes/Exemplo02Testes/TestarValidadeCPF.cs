using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Aula.Lib.Aula02;

namespace Aula.UnitTest.Aula02Testes.Exemplo02Testes
{
    public class TestarValidadeCPF
    {
        [Fact]
        public void CPFProprio()
        {
            bool Valida = Exemplo02.VerificarCPF("365.224.568-77");

            Assert.True(Valida);
        }
        [Fact]
        public void CPF4Devs1()
        {
            bool Valida = Exemplo02.VerificarCPF("284.716.780-39");

            Assert.True(Valida);
        }
        [Fact]
        public void CPF4Devs2()
        {
            bool Valida = Exemplo02.VerificarCPF("868.587.470-01");

            Assert.True(Valida);
        }
        [Fact]
        public void CPF4Devs3()
        {
            bool Valida = Exemplo02.VerificarCPF("983.114.230-67");

            Assert.True(Valida);
        }
        [Fact]
        public void CPFInvalido()
        {
            bool Valida = Exemplo02.VerificarCPF("658.874.365-55");

            Assert.False(Valida);
        }
        [Fact]
        public void CPFInvalido2()
        {
            bool Valida = Exemplo02.VerificarCPF("284.716.780-38");

            Assert.False(Valida);
        }
        [Fact]
        public void CPF4Devs3_SemMascara()
        {
            bool Valida = Exemplo02.VerificarCPF("98311423067");

            Assert.True(Valida);
        }
    }
}
