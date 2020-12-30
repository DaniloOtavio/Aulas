using Simple.Sqlite.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Lib.Aula06.E1
{
    public class TicketHist
    {
        [PrimaryKey]
        public int ID { get; set; }
        public long ID_Ticket { get; set; }
        public string Texto { get; set; }
        public string DataHoraAlteracao { get; set; }

    }
}
