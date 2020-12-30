using Simple.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Lib.Aula06.E1
{
    public class TicketHist_View
    {
        public static SqliteDB DB { get; private set; }
        public static void NovaAtualizacao(TicketHist tickethist)
        {
            DB.Insert(tickethist);
        }
        public static TicketHist BuscarHistorico(string ID)
        {
            return DB.Get<TicketHist>("ID", ID);
        }

        public static void Setup()
        {
            DB = new SqliteDB("Database.db");

            DB.CreateTables()
              .Add<Ticket>()
              .Commit();

            DB.CreateTables()
               .Add<TicketHist>()
               .Commit();
        }
    }
}
