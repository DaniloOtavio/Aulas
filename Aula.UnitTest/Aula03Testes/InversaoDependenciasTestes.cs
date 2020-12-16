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
            injectaDepndecia();

            var c = ClienteView2.TrazerCliente(4);
            Assert.Equal("Jão", c.Nome);
        }
        [Fact]
        public void TestarCliente_Null()
        {
            injectaDepndecia();

            Assert.Throws<InvalidOperationException>(() => ClienteView2.TrazerCliente(12));
        }


        private void injectaDepndecia()
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
        }

    }
}
