﻿using Aula.Lib.Aula06.E0;
using Simple.Sqlite;

namespace Aula.Lib.Aula06.E1
{
    public class Ticket_View
    {
        public static SqliteDB DB { get; private set; }

        public static void NovoTicket(Ticket ticket)
        {
            ticket.ID =  DB.Insert(ticket);
        }
        public static void NovaAtualizacao (TicketHist tickethist)
        {
            DB.Insert(tickethist);
        }
        public static Ticket ConsultaTicket(string ID)
        {
            return DB.Get<Ticket>("ID", ID);
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
