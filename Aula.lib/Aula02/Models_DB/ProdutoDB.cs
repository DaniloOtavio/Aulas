namespace Aula.Lib.Aula02.Models_DB
{
    /// <summary>
    /// Model para representar o produto no banco de dados
    /// </summary>
    public class ProdutoDB
    {
        /// <summary>
        /// Código do Produto
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Descrição do Produto
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Preço de Custo do Produto
        /// </summary>
        public decimal Custo { get; set; }

        /// <summary>
        /// Preço de Venda do Produto
        /// </summary>
        public decimal Venda { get; set; }
    }
}
