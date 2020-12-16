using Aula.Lib.Aula02.Models_DB;

namespace Aula.Lib.Aula02.View
{
    /// <summary>
    /// Classe que representa o produto na venda, herdando dados da Model.
    /// </summary>
    public class ProdutoVendaView : ProdutoDB
    {
        //public int Codigo { get; set; }
        //public string Nome { get; set; }

        /// <summary>
        /// Classificação fiscal do produto
        /// </summary>
        public string NCM { get; set; }

        /// <summary>
        /// Quantidade do item a ser vendida
        /// </summary>
        public decimal Qtde { get; set; }
        //public decimal Venda { get; set; }
        /// <summary>
        /// Desconto na venda do produto
        /// </summary>
        public decimal Desconto { get; set; }

        /// <summary>
        /// Retorna o subtotal
        /// </summary>
        public decimal SubTotal
        {
            get 
            {
                return (Venda * Qtde) - Desconto;
            }
        }

    }
}
