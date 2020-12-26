using Simple.Sqlite.Attributes;

namespace Aula.Lib.Aula06.E0
{
    public class Item
    {
        // Este é o model

        [PrimaryKey]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Local { get; set; }

        public string Patrimonio { get; set; }
    }
}
