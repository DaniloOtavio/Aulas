using Simple.Sqlite.Attributes;

namespace Aula.Lib.Aula06.E0
{
    /// <summary>
    /// Classe Item
    /// </summary>
    public class Item
    {
        // Este é o model
        
        /// <summary>
        /// ID interno
        /// </summary>
        [PrimaryKey]
        public int ID { get; set; }
        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Local armazenagem
        /// </summary>
        public string Local { get; set; }
        /// <summary>
        /// Número Patrimônio
        /// </summary>
        public string Patrimonio { get; set; }
    }
}
