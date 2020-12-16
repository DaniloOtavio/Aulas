using Aula.Lib.Aula02.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula03
{
    public class ClienteView2 : Aula02.View.ClienteView
    {
        public static Interfaces.ICliente BancoClientes;

        public static ClienteDB TrazerCliente(int CodigoCliente)
        {
            var c = BancoClientes.CarregaCliente(CodigoCliente);
            if (c == null) throw new InvalidOperationException();
            return c;
        }
        public static ClienteDB[] TrazerClientes(int[] CodigoCliente)
        {
            List<ClienteDB> lst = new List<ClienteDB>();

            foreach(var c in CodigoCliente)
            {
                lst.Add(BancoClientes.CarregaCliente(c));
            }

            return lst.ToArray();
        }
    }
}
