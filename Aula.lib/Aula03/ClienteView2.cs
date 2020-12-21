using Aula.Lib.Aula02.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula03
{
    /// <summary>
    /// View para Clientes
    /// </summary>
    public class ClienteView2 : Aula02.View.ClienteView
    {
        /// <summary>
        /// Criação de um banco de clientes
        /// </summary>
        public static Interfaces.ICliente BancoClientes;

        /// <summary>
        /// Carrega cliente de acordo com o código do cliente
        /// </summary>
        /// <param name="CodigoCliente">Código do Cliente</param>
        /// <returns>Retorna o cliente</returns>
        public static ClienteDB TrazerCliente(int CodigoCliente)
        {
            var c = BancoClientes.CarregaCliente(CodigoCliente);
            if (c == null) throw new InvalidOperationException();
            return c;
        }

        /// <summary>
        /// Remove Clientes
        /// </summary>
        /// <param name="v">Código do Cliente</param>
        public static ClienteDB RemoverCliente(int v)
        {
            var c = BancoClientes.RemoveCliente(v);
            if (c == null) throw new InvalidOperationException();
            return c;
        }

        /// <summary>
        /// Editar Clientes
        /// </summary>
        /// <param name="v">Código do Cliente</param>
        /// <returns></returns>
        public static ClienteDB EditarCliente(int v, string Nome)
        {
            var c = BancoClientes.EditaCliente(v);
            if (c == null) throw new InvalidOperationException();

            c.Nome = Nome;

            return c;
        }

        /// <summary>
        /// Array para listar os clientes
        /// </summary>
        /// <param name="CodigoCliente">Código do Cliente</param>
        /// <returns>Retorna a listagem dos clientes</returns>
        public static ClienteDB[] TrazerClientes(int[] CodigoCliente)
        {
            List<ClienteDB> lst = new List<ClienteDB>();

            foreach(var c in CodigoCliente)
            {
                lst.Add(BancoClientes.CarregaCliente(c));
            }

            return lst.ToArray();
        }

        /// <summary>
        /// Remover Cliente
        /// </summary>
        /// <param name="CodigoCliente">Código do Cliente</param>
        public static ClienteDB[] RemoverCliente(int[] CodigoCliente)
        {
            List<ClienteDB> lst = new List<ClienteDB>();

            foreach (var c in CodigoCliente)
            {
                lst.Remove(BancoClientes.RemoveCliente(c));
            }

            return lst.ToArray();
        }

        /// <summary>
        /// Editar Cliente
        /// </summary>
        /// <param name="CodigoCliente">Código do Cliente</param>
        /// <returns>Retorna o cliente editado</returns>
        public static ClienteDB[] EditarCliente(int[] CodigoCliente)
        {
            List<ClienteDB> lst = new List<ClienteDB>();

            foreach (var c in CodigoCliente)
            {
                lst.Remove(BancoClientes.EditaCliente(c));
            }

            return lst.ToArray();
        }

    }
}
