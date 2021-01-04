using Simple.Sqlite.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Lib.Aula06.E1
{
    /// <summary>
    /// Model dos históricos do ticket
    /// </summary>
    public class TicketHist
    {
        /// <summary>
        /// ID interno do histórico
        /// </summary>
        [PrimaryKey]
        public int ID { get; set; }
        /// <summary>
        /// ID do ticket
        /// </summary>
        public long ID_Ticket { get; set; }
        /// <summary>
        /// Ocorrência registrada
        /// </summary>
        public string Texto { get; set; }
        /// <summary>
        /// Data e hora da inserção da alteração
        /// </summary>
        public string DataHoraAlteracao { get; set; }

    }
}
