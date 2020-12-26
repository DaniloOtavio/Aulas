using Simple.Sqlite;
using System.Linq;

namespace Aula.Lib.Aula06.E0
{
    public class Item_View
    {
        public static SqliteDB DB { get; private set; }

        public static void Inserir(Item item)
        {
            DB.Insert(item);
        }

        public static Item BuscaPatrimonio(string Patrimonio)
        {
           return DB.Get<Item>("Patrimonio", Patrimonio);
        }

        public static Item[] TrazACambada()
        {
            return DB.GetAll<Item>().ToArray() ;
        }

        public static void Setup()
        {
            DB = new SqliteDB("MyShit.db");

            DB.CreateTables()
              .Add<Item>()
              .Commit();
        }
    }
}
