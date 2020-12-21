using Aula.Lib.Aula02.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula03.Interfaces
{
    /// <summary>
    /// Interface para clientes
    /// </summary>
    public interface ICliente
    {
        /// <summary>
        /// Carrega clientes
        /// </summary>
        /// <param name="CodigoCliente">Código do Cliente</param>
        /// <returns>Cliente</returns>
        ClienteDB CarregaCliente(int CodigoCliente);
        
        /// <summary>
        ///Remove cliente 
        /// </summary>
        /// <param name="CodigoCliente">Código do Cliente</param>
        /// <returns>Remove o cliente da lista</returns>
        bool RemoveCliente(int CodigoCliente);

        /// <summary>
        /// Edita Cliente
        /// </summary>
        /// <param name="CodigoCliente">Código do Cliente</param>
        /// <returns>Edita o cliente da lista</returns>
        void EditaCliente(int CodigoCliente, string Nome);
    }
}
