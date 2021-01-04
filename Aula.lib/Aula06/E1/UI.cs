using Simple.Sqlite;
using System;
namespace Aula.Lib.Aula06.E1
{
    /// <summary>
    /// Interface do Usuário
    /// </summary>
    public class UI
    {
        /// <summary>
        /// Variável do SQLite
        /// </summary>
        public static SqliteDB DB { get; private set; }
        /// <summary>
        /// Inicializar sistema
        /// </summary>
        public static void Inicializar()
        {

            Ticket_View.Setup();
            Console.WriteLine("Inicializando...");
            MenuPrincipal();
        }
        static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Selecione uma opção: ");
            Console.WriteLine("1 - Cadastrar novo ticket");
            Console.WriteLine("2 - Visualizar ticket");
            Console.WriteLine("3 - Cancelar");

            string resposta = Console.ReadLine();

            if (resposta == "1") MenuNovoTicket();
            else if (resposta == "2") MenuVisualizarTicket();
            else if (resposta == "3")
            {
                Console.WriteLine("Saindo...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Comando não reconhecido!");
                Console.ReadKey();
                MenuPrincipal();
            }
        }
        static void MenuNovoTicket()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Digitando nova ocorrência... (Pressione ESC para sair.)");
            Console.ResetColor();

            Console.Write("Assunto: (Máx. 50 caracteres.)");
            Console.SetCursorPosition(0, 3);
            Console.Write("Informe o tipo da ocorrência (BUG / SUGESTÃO):");
            Console.SetCursorPosition(0, 5);
            Console.Write("Responsável pelo atendimento:");
            Console.SetCursorPosition(0, 7);
            Console.Write("Informe a versão do software:");
            Console.SetCursorPosition(0, 9);
            Console.Write("Informe a ocorrência:");

            Console.SetCursorPosition(0, 15);
            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Pressione [F2] para inserir para liberar a digitação e [ENTER] para confirmar!");
            Console.WriteLine("Pressione [F5] para salvar!");
            Console.ResetColor();

            Console.SetCursorPosition(0, 2);

            long id; 
            string assunto = ""; 
            var data = DateTime.Now;
            Tipo_Ticket tipo = Tipo_Ticket.BUG;
            string responsavel = ""; 
            string versao = ""; 
            string ocorrencia = "";

            int posicao = 1;
            while (true)
            {
                if (posicao == 1) Console.SetCursorPosition(0, 2);
                if (posicao == 2) Console.SetCursorPosition(0, 4);
                if (posicao == 3) Console.SetCursorPosition(0, 6);
                if (posicao == 4) Console.SetCursorPosition(0, 8);
                if (posicao == 5) Console.SetCursorPosition(0, 10);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && posicao > 1) posicao--;
                if (key.Key == ConsoleKey.DownArrow && posicao < 5) posicao++;
                if (key.Key == ConsoleKey.Escape)
                {
                    MenuPrincipal();
                    break;
                }

                if (key.Key == ConsoleKey.F2)
                {
                    if (posicao == 1)
                    {
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 2);
                        assunto = Console.ReadLine();
                    }
                    else if (posicao == 2)
                    {
                        Console.Write(new string(' ', 30));
                        Console.SetCursorPosition(0, 4);
                        string temp = Console.ReadLine();

                        if (temp == "BUG")
                        {
                            tipo = Tipo_Ticket.BUG;
                        }
                        else if (temp == "SUGESTÃO")
                        {
                            tipo = Tipo_Ticket.SUGESTAO;
                        }
                        else
                        {
                            Console.WriteLine("Tipo chamado inválido!");
                        }
                    }
                    else if (posicao == 3)
                    {
                        Console.Write(new string(' ', responsavel.Length));
                        Console.SetCursorPosition(0, 6);
                        responsavel = Console.ReadLine();
                    }
                    else if (posicao == 4)
                    {
                        Console.Write(new string(' ', versao.Length));
                        Console.SetCursorPosition(0, 8);
                        versao = Console.ReadLine();
                    }
                    else if (posicao == 5)
                    {
                        Console.Write(new string(' ', ocorrencia.Length));
                        Console.SetCursorPosition(0, 10);
                        ocorrencia = Console.ReadLine();
                    }
                }

                if (key.Key == ConsoleKey.F5)
                {
                    if (CamposPreenchidos(assunto, responsavel, versao, ocorrencia) == false)
                    {
                        Console.SetCursorPosition(0, 2);
                        break;
                    }

                    var ticket = new Ticket()
                    {
                        Assunto = assunto,
                        DataAbertura = Convert.ToString(data),
                        Tipo = tipo,
                        Responsavel = responsavel,
                        VersaoAfetada = versao,
                        Finalizado = false
                    };

                    Ticket_View.NovoTicket(ticket);

                    id = ticket.ID;

                    var ticket_hist = new TicketHist()
                    {
                        ID_Ticket = id,
                        DataHoraAlteracao = Convert.ToString(DateTime.Now),
                        Texto = ocorrencia
                    };
                    Ticket_View.NovaAtualizacao(ticket_hist);

                    Console.WriteLine($"Registro incluído com sucesso! ID do ticket: {ticket.ID}");
                    Console.ReadKey();
                    MenuPrincipal();
                    return;
                }
            }

            static bool CamposPreenchidos(string assunto, string responsavel, string versao, string ocorrencia)
            {
                //ORGANIZAR TUDO ISSO AQUI

                string campos = "";
                if (assunto == "") campos = "[ASSUNTO]";
                if (responsavel == "") if (campos == "") campos = "[RESPONSÁVEL]"; else campos += " [RESPONSÁVEL]";
                if (versao == "") if (campos == "") campos = "[VERSÃO SOFTWARE]"; else campos += " [VERSÃO SOFTWARE]";
                if (ocorrencia == "") if (campos == "") campos = "[OCORRÊNCIA]"; else campos += " [OCORRÊNCIA]";

                if (campos != "")
                {
                    Console.SetCursorPosition(0, 20);
                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Campos faltantes:");
                    Console.Write(campos);
                    Console.ResetColor();
                    return false;
                }
                else return true;
            }
        }
        static void MenuVisualizarTicket()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Digite o ID do chamado:");
            Console.ResetColor();

            string ID = Console.ReadLine();

            var ticket = Ticket_View.BuscarTicket(ID);
            Console.Clear();

            if (ticket != null)
            {
                string status;
                if (ticket.Finalizado == true) status = "Finalizado";
                else status = "Aberto";

                Console.WriteLine($"Ticket nº: {ticket.ID } - Tipo: {ticket.Tipo} - Aberto em: {ticket.DataAbertura} - Por: {ticket.Responsavel} - Status: {status}");
                Console.WriteLine("");
                Console.WriteLine("Atualizações:");
                Console.WriteLine("");

                DB = new SqliteDB("Database.db");

                var historico = DB.ExecuteQuery<TicketHist>("SELECT * FROM TicketHist WHERE ID_Ticket = @ID", new { ID });

                foreach (var item in historico)
                {
                    Console.WriteLine(item.DataHoraAlteracao);
                    Console.WriteLine(item.Texto);
                    Console.WriteLine("---------------------------------------------------------");
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Selecione uma opção: ");

                string resposta;
                if (status == "Aberto")
                {
                    Console.WriteLine("1 - Inserir nova atualização");
                    Console.WriteLine("2 - Encerrar chamado");
                    Console.WriteLine("3 - Voltar ao menu principal");

                    resposta = Console.ReadLine();

                    if (resposta == "1")
                    {
                        Console.WriteLine("---------------------------------------------------------");
                        Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Digitando nova ocorrência...");
                        Console.ResetColor();

                        string texto = Console.ReadLine();

                        var ticket_hist = new TicketHist()
                        {
                            ID_Ticket = Convert.ToInt32(ID),
                            DataHoraAlteracao = Convert.ToString(DateTime.Now),
                            Texto = texto,
                        };

                        Ticket_View.NovaAtualizacao(ticket_hist);
                        Console.WriteLine("Registro incluído com sucesso!");
                        Console.ReadKey();
                        MenuPrincipal();
                    }
                    else if (resposta == "2")
                    {
                        DB = new SqliteDB("Database.db");

                        DB.ExecuteNonQuery("UPDATE Ticket SET Finalizado = TRUE WHERE ID = @ID", new { ID });

                        Console.WriteLine("Chamado encerrado com sucesso!");
                        Console.ReadKey();
                        MenuPrincipal();
                    }
                    else if (resposta == "3") MenuPrincipal();

                    else
                    {
                        Console.WriteLine("Opção inválida. Retornando ao menu principal...");
                        Console.ReadKey();
                        MenuPrincipal();
                    }
                }
                else
                {
                    Console.WriteLine("1 - Voltar ao menu principal");
                    resposta = Console.ReadLine();
                    if (resposta == "1") MenuPrincipal();
                    else
                    {
                        Console.WriteLine("Opção inválida. Retornando ao menu principal...");
                        Console.ReadKey();
                        MenuPrincipal();
                    }
                }
            }
            else //TICKET == NULL - NÃO ENCONTRADO
            {
                Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Não encontrado nenhum registro com esse ID!");
                Console.ResetColor();
                Console.ReadKey();
                MenuVisualizarTicket();
            }
        }
    }


}
