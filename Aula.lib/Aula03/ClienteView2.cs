using Aula.Lib.Aula02.Models_DB;
using System;
using System.Collections.Generic;

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
        public static void RemoverCliente(int v)
        {
            if (!BancoClientes.RemoveCliente(v))
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Editar Clientes
        /// </summary>
        /// <param name="v">Código do Cliente</param>
        public static void EditarCliente(int v, string Nome)
        {
            BancoClientes.EditaCliente(v, Nome);
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
    }
}
