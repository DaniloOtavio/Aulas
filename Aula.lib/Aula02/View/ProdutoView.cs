using Aula.Lib.Aula01;

namespace Aula.Lib.Aula02.View
{
    public class ProdutoView : Models_DB.ProdutoDB
    {
        /* Não é usado, pois ProdutoDB já tem
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Custo { get; set; }
        public decimal Venda { get; set; }
        */

        //TODO Fix this shit
        /// <summary>
        /// Retorna a Margem de Lucro Calculado com Base no Preço de Custo e Preço de Venda
        /// </summary>
        public decimal MargemDeLucro
        {
            get
            {
                return Exemplo01.CalcularMargemDeLucro(Custo, Venda);
            }
            set
            {
                Margem = Exemplo01.CalcularMargemDeLucro(Custo, value);
            }
        }
        /// <summary>
        /// Retorna o Markup Calculado com Base no Preço de Custo e Preço de Venda
        /// </summary>
        public decimal MarkUp
        {
            get
            {
                return Exemplo01.CalcularMarkup(Custo, Venda);
            }
            set
            {
                Venda = Exemplo01.CalcularPV_Markup(Custo, value);
            }
        }


    }
}
