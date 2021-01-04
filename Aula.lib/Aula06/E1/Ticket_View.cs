using Aula.Lib.Aula06.E0;
using Simple.Sqlite;

namespace Aula.Lib.Aula06.E1
{
    /// <summary>
    /// View do ticket
    /// </summary>
    public class Ticket_View
    {
        /// <summary>
        /// Variável SQLite
        /// </summary>
        public static SqliteDB DB { get; private set; }

        /// <summary>
        /// Gravação do cabeçalho do ticket
        /// </summary>
        /// <param name="ticket">Informações do cabeçalho do ticket</param>
        public static void NovoTicket(Ticket ticket)
        {
            ticket.ID =  DB.Insert(ticket);
        }
        /// <summary>
        /// Inserçaõ do histórico do ticket
        /// </summary>
        /// <param name="tickethist">Informações do histórico do ticket</param>
        public static void NovaAtualizacao (TicketHist tickethist)
        {
            DB.Insert(tickethist);
        }
        /// <summary>
        /// Consultar ticket
        /// </summary>
        /// <param name="ID">ID do ticket</param>
        /// <returns>Retorna o ticket cadastrado</returns>
        public static Ticket BuscarTicket(string ID)
        {
            return DB.Get<Ticket>("ID", ID);
        }
        /// <summary>
        /// Configuração do Banco de Dados
        /// </summary>
        public static void Setup()
        {
            DB = new SqliteDB("Database.db");

            DB.CreateTables()
              .Add<Ticket>()
              .Add<TicketHist>()
              .Commit();
        }
    }
}
