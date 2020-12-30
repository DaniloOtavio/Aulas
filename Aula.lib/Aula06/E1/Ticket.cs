using Simple.Sqlite.Attributes;

namespace Aula.Lib.Aula06.E1
{
    public class Ticket
    {
        [PrimaryKey]
        public long ID { get; set; }
        public string Assunto { get; set; }
        public string DataAbertura { get; set; }
        public string Tipo { get; set; }
        public string Responsavel { get; set; }
        public string VersaoAfetada { get; set; }
        public bool Finalizado { get; set; }

    }
}
