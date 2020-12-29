
namespace Aula.Lib.Aula06.E1
{
    public class Ticket_View
    {
        public static void NovoTicket()
        {

        }
        public static Ticket ConsultaTicket(int ID)
        {
            return null;
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
