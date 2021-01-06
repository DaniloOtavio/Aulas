using Aula.Lib.Aula06.E0;
using Simple.Sqlite;
using System;
using System.IO;
using System.Linq;

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
        public static void NovaAtualizacao(TicketHist tickethist)
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
        /// Retorna todos os tickets
        /// </summary>
        /// <returns></returns>
        public static Ticket[] CarregarTodosOsTickets()
        {
            var tickets = DB.GetAll<Ticket>();
            return tickets.ToArray();
        }
        /// <summary>
        /// Consultar os históricos dos tickets
        /// </summary>
        /// <param name="ID">ID do Ticket</param>
        /// <returns>Retorna todos os históricos dos tickets tickets</returns>
        public static TicketHist[] CarregarHistorico(string ID)
        {
            var historico = DB.ExecuteQuery<TicketHist>("SELECT * FROM TicketHist WHERE ID_Ticket = @ID", new { ID });
            return historico.ToArray();
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
        /// <summary>
        /// Realiza uma cópia do banco de dados
        /// </summary>
        public static void BackupDB()
        {
            string localDB;
            string destinoDB;
            string nomeArquivo;

            //Definindo locais das pastas e arquivos
            localDB = DB.DatabaseFileName;
            destinoDB = @$"C:\Users\LoginSoft\Documents\GitHub\Aulas\Aula.Bedelho\bin\Debug\netcoreapp3.1\Backup\";
            nomeArquivo=$"Database_{DateTime.Now.ToString().Replace("/","-").Replace(":",".")}.db";

            //Se não existe a pasta do banco de dados, cria
            if (Directory.Exists(destinoDB) == false) Directory.CreateDirectory(destinoDB);

            //Criando uma cópia do arquivo
            File.Copy(localDB, destinoDB + nomeArquivo);
        }
    }
}
