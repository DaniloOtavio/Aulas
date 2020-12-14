using Aula.Lib.Aula02.Models_DB;

namespace Aula.Lib.Aula02.View
{
    public class ProdutoVendaView : ProdutoDB
    {
        //public int Codigo { get; set; }
        //public string Nome { get; set; }
        public string NCM { get; set; }
        public decimal Qtde { get; set; }
        //public decimal Venda { get; set; }
        public decimal Desconto { get; set; }

        public decimal SubTotal
        {
            get 
            {
                return (Venda * Qtde) - Desconto;
            }
        }

    }
}
