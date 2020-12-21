using Aula.Lib.Aula01;

namespace Aula.Lib.Aula02.View
{
    /// <summary>
    /// View para produtos, herdando características da Model
    /// </summary>
    public class ProdutoView : Models_DB.ProdutoDB
    {
        /* Não é usado, pois ProdutoDB já tem
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Custo { get; set; }
        public decimal Venda { get; set; }
        */
        /// <summary>
        /// Representa a margem de lucro para o usuário com base no preço de custo e venda
        /// </summary>
        public decimal Margem { get; set; }

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
