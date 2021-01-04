using Simple.Sqlite.Attributes;

namespace Aula.Lib.Aula06.E1
{
    /// <summary>
    /// Model do ticket
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// ID interno do ticket
        /// </summary>
        [PrimaryKey]
        public long ID { get; set; }
        /// <summary>
        /// Assunto do ticket
        /// </summary>
        public string Assunto { get; set; }
        /// <summary>
        /// Data de Abertura do ticket
        /// </summary>
        public string DataAbertura { get; set; }
        /// <summary>
        /// Tipo (Bug ou Sugestão)
        /// </summary>
        public Tipo_Ticket Tipo { get; set; }
        /// <summary>
        /// Responsável pela abertura do chamado
        /// </summary>
        public string Responsavel { get; set; }
        /// <summary>
        /// Versão do software afetada
        /// </summary>
        public string VersaoAfetada { get; set; }
        /// <summary>
        /// Finalizado ou não
        /// </summary>
        public bool Finalizado { get; set; }

    }
}
