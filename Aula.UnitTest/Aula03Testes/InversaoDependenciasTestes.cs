using Aula.Lib.Aula03;
using Aula.Lib.Aula03.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace Aula.UnitTest.Aula03Testes
{
    public class InversaoDependenciasTestes
    {
        [Fact]
        public void TesteCliente11()
        {
            InjectaDepndecia();

            var c = ClienteView2.TrazerCliente(4);
            Assert.Equal("Jão", c.Nome);
        }
        [Fact]
        public void TestarCliente_Null()
        {
            InjectaDepndecia();
            Assert.Throws<InvalidOperationException>(() => ClienteView2.TrazerCliente(12));
        }
        [Fact]
        public void TestaRemoverCliente_Null()
        {
            InjectaDepndecia();
            Assert.Throws<InvalidOperationException>(() => ClienteView2.RemoverCliente(15));

        }
        [Fact]
        public void TestaRemoverCliente()
        {
            InjectaDepndecia();

            ClienteView2.RemoverCliente(3); 
        }

        [Fact]
        public void EditaCliente()
        {
            InjectaDepndecia();

            var nomeOriginal = ClienteView2.TrazerCliente(4);
            Assert.Equal("Jão", nomeOriginal.Nome);

            ClienteView2.EditarCliente(4, "John");

            //Assert.Equal("John", novoNome.Nome);
        }

        private static void InjectaDepndecia()
        {
            ClienteView2.BancoClientes = new FakeDB();
        }
        class FakeDB : ICliente
        {
            readonly List<Lib.Aula02.Models_DB.ClienteDB> clientes;

            public FakeDB()
            {
                clientes = new List<Lib.Aula02.Models_DB.ClienteDB>
                {
                    new Lib.Aula02.Models_DB.ClienteDB()
                    {
                        Codigo = 1,
                        Nome = "Zé"
                    },
                    new Lib.Aula02.Models_DB.ClienteDB()
                    {
                        Codigo = 2,
                        Nome = "Peter"
                    },
                    new Lib.Aula02.Models_DB.ClienteDB()
                    {
                        Codigo = 3,
                        Nome = "Gertrudes"
                    },
                    new Lib.Aula02.Models_DB.ClienteDB()
                    {
                        Codigo = 4,
                        Nome = "Jão"
                    }
                };
            }

            public Lib.Aula02.Models_DB.ClienteDB CarregaCliente(int CodigoCliente)
            {
                foreach(var c in clientes)
                {
                    if (c.Codigo == CodigoCliente) return c;
                }
                return null;
            }

            public void EditaCliente(int CodigoCliente, string Nome)
            {
                foreach (var c in clientes)
                {
                    if (c.Codigo == CodigoCliente)
                    {
                        c.Nome = Nome;
                        return;
                    }
                }
                
            }

            public bool RemoveCliente(int CodigoCliente)
            {
                foreach (var c in clientes)
                {
                    if (c.Codigo == CodigoCliente)
                    {
                        clientes.Remove(c); 
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
