using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Classe que armazena os dados do produto ao cadastrar
    /// </summary>
    public class ProdutoCadastro
    {
        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Identificador único do produto
        /// </summary>
        public Guid GUID { get; set; }
        /// <summary>
        /// Local onde o produto está armazenado
        /// </summary>
        public string LocalArmazenagem { get; set; }
        /// <summary>
        /// Quantidade armazenada
        /// </summary>
        public decimal Quantidade { get; set; }
    }
}
