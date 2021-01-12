using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Classe que armazena as características que devem ser preenchidas ao lançar no estoque
    /// </summary>
    public class ProdutoEstoque
    {
        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Identificador do produto
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// Local de armazenagem do produto
        /// </summary>
        public string LocalArmazenagem { get; set; }
        /// <summary>
        /// Quantidade do produto
        /// </summary>
        public decimal QuantidadeLocal { get; set; }
    }
}
