using Aula.Lib.Aula03;
using Aula.Lib.Aula03.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var c = ClienteView2.RemoverCliente(3);

            Assert.Equal("Gertrudes", c.Nome);

        }

        private static void InjectaDepndecia()
        {
            ClienteView2.BancoClientes = new FakeDB();
        }
        class FakeDB : ICliente
        {
            List<Lib.Aula02.Models_DB.ClienteDB> clientes;

            public FakeDB()
            {
                clientes = new List<Lib.Aula02.Models_DB.ClienteDB>();

                clientes.Add(new Lib.Aula02.Models_DB.ClienteDB()
                {
                    Codigo = 1,
                    Nome = "Zé"
                });
                clientes.Add(new Lib.Aula02.Models_DB.ClienteDB()
                {
                    Codigo = 2,
                    Nome = "Peter"
                });
                clientes.Add(new Lib.Aula02.Models_DB.ClienteDB()
                {
                    Codigo = 3,
                    Nome = "Gertrudes"
                });
                clientes.Add(new Lib.Aula02.Models_DB.ClienteDB()
                {
                    Codigo = 4,
                    Nome = "Jão"
                });
            }

            public Lib.Aula02.Models_DB.ClienteDB CarregaCliente(int CodigoCliente)
            {
                foreach(var c in clientes)
                {
                    if (c.Codigo == CodigoCliente) return c;
                }
                return null;
            }

            public Lib.Aula02.Models_DB.ClienteDB RemoveCliente(int CodigoCliente)
            {
                foreach (var c in clientes)
                {
                    if (c.Codigo == CodigoCliente)
                    {
                        clientes.Remove(c);
                        return c;
                    }
                }
                return null;
            }
        }

    }
}
