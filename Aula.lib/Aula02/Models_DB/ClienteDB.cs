using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula02.Models_DB
{
    /// <summary>
    /// Classe que representa o cliente no banco de dados
    /// </summary>
    public class ClienteDB
    {
        /// <summary>
        /// Código do Cliente
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF do cliente
        /// </summary>
        public string CPF { get; set; }
    }
}
