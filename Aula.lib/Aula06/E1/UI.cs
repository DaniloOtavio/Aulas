using Simple.Sqlite;
using System;
using System.Linq;

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
            Ticket_View.BackupDB();
            Console.WriteLine("Backup realizado...");
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
                Console.WriteLine("Saindo... Pressione alguma tecla para prosseguir.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Comando não reconhecido! Pressione alguma tecla para prosseguir.");
                Console.ReadKey();
                MenuPrincipal();
            }
        }
        static void MenuNovoTicket()
        {
            //Cria cabeçalho
            //..................................................................................................................................................................................
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Digitando nova ocorrência... (Pressione ESC para sair.)");
            Console.ResetColor();

            Console.Write("Assunto: (Máx. 50 caracteres.) - (Caracteres destacados em vermelho serão desprezados na gravação.)");
            Console.SetCursorPosition(0, 3);
            Console.Write("Informe o tipo da ocorrência (1 - BUG /2 - SUGESTÃO):");
            Console.SetCursorPosition(0, 5);
            Console.Write("Responsável pelo atendimento:");
            Console.SetCursorPosition(0, 7);
            Console.Write("Informe a versão do software:");
            Console.SetCursorPosition(0, 9);
            Console.Write("Informe a ocorrência:");

            Console.SetCursorPosition(0, 15);
            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Pressione [F2] para liberar a digitação e [ENTER] para confirmar!");
            Console.WriteLine("Pressione [F5] para salvar!");
            Console.WriteLine(@"Use as setas para cima ↑ e para baixo ↓ para navegar entre os campos!");
            Console.ResetColor();

            Console.SetCursorPosition(0, 2);
            //..................................................................................................................................................................................

            long id; //ID do ticket gravado
            string assunto = ""; //Assunto do ticket a ser gravado
            var data = DateTime.Now; //Data do ticket a ser gravado
            Tipo_Ticket tipo = Tipo_Ticket.VAZIO; //Tipo do ticket a ser gravado
            string responsavel = ""; //Responsável do ticket a ser gravado
            string versao = ""; //Versão afetada do ticket a ser gravado
            string ocorrencia = ""; //Ocorrência

            int posicao = 1;
            while (true)
            {
                //Muda a posição de acordo com as setas pressionadas
                //..................................................................................................................................................................................
                if (posicao == 1) Console.SetCursorPosition(0, 2);
                if (posicao == 2) Console.SetCursorPosition(0, 4);
                if (posicao == 3) Console.SetCursorPosition(0, 6);
                if (posicao == 4) Console.SetCursorPosition(0, 8);
                if (posicao == 5) Console.SetCursorPosition(0, 10);
                //..................................................................................................................................................................................

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow && posicao > 1) posicao--;
                if (key.Key == ConsoleKey.DownArrow && posicao < 5) posicao++;
                if (key.Key == ConsoleKey.Escape)
                {
                    MenuPrincipal();
                    return;
                }

                //[F2] Libera a digitação
                if (key.Key == ConsoleKey.F2)
                {
                    if (posicao == 1)
                    {
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 2);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        assunto = Console.ReadLine();
                        Console.ResetColor();

                        int tam_excesso = 0;

                        if (assunto.Length > 50)
                        {
                            for (int i = 0; i < assunto.Length; i++)
                            {
                                if (i >= 50)
                                {
                                    tam_excesso++;
                                }
                            }
                            Console.SetCursorPosition(0, 2);
                            //..................................................................

                            //Retorna cor padrão
                            Console.SetCursorPosition(0, 2);
                            Console.ResetColor();
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, 2);
                            Console.Write(assunto.Substring(0, 50));

                            //Printando excedente do assunto em vermelho
                            Console.SetCursorPosition(50, 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(assunto.Substring(50,tam_excesso));
                            Console.ResetColor();

                            //campo assunto deve ir no máximo 50 para o BD
                            assunto = assunto.Substring(0, 50);
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.ResetColor();
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, 2);
                            Console.Write(assunto);
                        }
                        posicao++; //AVANÇA PARA O PRÓXIMO CAMPO
                        
                    }
                    else if (posicao == 2)
                    {
                        Console.Write(new string(' ', 61));
                        Console.SetCursorPosition(0, 4);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        string temp = Console.ReadLine();

                        if (temp == "1")
                        {
                            tipo = Tipo_Ticket.BUG;

                            //Retorna cor padrão
                            Console.SetCursorPosition(0, 4);
                            Console.ResetColor();
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, 4);
                            Console.Write(temp);

                            posicao++; //AVANÇA PARA O PRÓXIMO CAMPO
                        }
                        else if (temp == "2")
                        {
                            tipo = Tipo_Ticket.SUGESTAO;

                            //Retorna cor padrão
                            Console.SetCursorPosition(0, 4);
                            Console.ResetColor();
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, 4);
                            Console.Write(temp);

                            posicao++; //AVANÇA PARA O PRÓXIMO CAMPO
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tipo chamado inválido! Siga as orientações da linha anterior.");
                            Console.ResetColor();
                        }
                        Console.SetCursorPosition(0, 6);
                    }
                    else if (posicao == 3)
                    {
                        Console.Write(new string(' ', responsavel.Length));
                        Console.SetCursorPosition(0, 6);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        responsavel = Console.ReadLine();
                        Console.ResetColor();

                        //Retorna cor padrão
                        Console.SetCursorPosition(0, 6);
                        Console.ResetColor();
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 6);
                        Console.Write(responsavel);

                        posicao++; //AVANÇA PARA O PRÓXIMO CAMPO
                    }
                    else if (posicao == 4)
                    {
                        Console.Write(new string(' ', versao.Length));
                        Console.SetCursorPosition(0, 8);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        versao = Console.ReadLine();
                        Console.ResetColor();

                        //Retorna cor padrão
                        Console.SetCursorPosition(0, 8);
                        Console.ResetColor();
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 8);
                        Console.Write(versao);

                        posicao++; //AVANÇA PARA O PRÓXIMO CAMPO
                    }
                    else if (posicao == 5)
                    {
                        Console.Write(new string(' ', ocorrencia.Length));
                        Console.SetCursorPosition(0, 10);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        ocorrencia = Console.ReadLine();
                        Console.ResetColor();

                        //Retorna cor padrão
                        Console.SetCursorPosition(0, 10);
                        Console.ResetColor();
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 10);
                        Console.Write(ocorrencia);
                    }
                }

                //[F5] Grava o ticket
                if (key.Key == ConsoleKey.F5)
                {
                    if (CamposPreenchidos(assunto, tipo, responsavel, versao, ocorrencia) == false)
                    {
                        Console.SetCursorPosition(0, 2);
                    }
                    else
                    {
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

                        Console.SetCursorPosition(0, 14);
                        Console.WriteLine($"Registro incluído com sucesso! ID do ticket: {ticket.ID}. Pressione alguma tecla para prosseguir.");
                        Console.ReadKey();
                        MenuPrincipal();
                        return;
                    }
                }
            }
            //Função para validar os campos vazios
            static bool CamposPreenchidos(string assunto, Tipo_Ticket tipo, string responsavel, string versao, string ocorrencia)
            {
                string campos = "";
                if (assunto == "") campos = "[ASSUNTO]";

                if (tipo != Tipo_Ticket.BUG && tipo != Tipo_Ticket.SUGESTAO)
                {
                    if (campos == "")
                    {
                        campos = "[TIPO CHAMADO]";
                    }
                    else
                    {
                        campos += " [TIPO CHAMADO]";
                    }
                }

                if (responsavel == "")
                {
                    if (campos == "")
                    {
                        campos = "[RESPONSÁVEL]";
                    }
                    else
                    {
                        campos += " [RESPONSÁVEL]";
                    }
                }
                if (versao == "")
                {
                    if (campos == "")
                    {
                        campos = "[VERSÃO SOFTWARE]";
                    }
                    else
                    {
                        campos += " [VERSÃO SOFTWARE]";
                    }
                }
                if (ocorrencia == "")
                {
                    if (campos == "")
                    {
                        campos = "[OCORRÊNCIA]";
                    }
                    else
                    {
                        campos += " [OCORRÊNCIA]";
                    }
                }

                if (campos != "")
                {
                    Console.SetCursorPosition(0, 20);
                    Console.Write(new string(' ', 75));
                    Console.SetCursorPosition(0, 20);
                    Console.BackgroundColor = ConsoleColor.Red; Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Campos faltantes: ");
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
            Console.WriteLine("Digite o ID do chamado para consultá-lo, digite * (asterisco) para exibir todos ou deixe vazio para voltar ao menu principal");
            Console.ResetColor();

            string ID = Console.ReadLine();

            if (ID == "")
            {
                MenuPrincipal();
                return;
            }

            if (ID == "*")
            {
                var tickets = Ticket_View.CarregarTodosOsTickets();

                Console.Clear();

                foreach (var item in tickets)
                {
                    Console.WriteLine($"ID: {item.ID} - Assunto: {item.Assunto} - Data de Abertura: {item.DataAbertura}");
                }

                Console.WriteLine("========================================================");
                Console.WriteLine("Selecione uma opção: ");
                Console.WriteLine("1 - Visualizar ticket");
                Console.WriteLine("2 - Voltar ao menu principal");
                string resposta = Console.ReadLine();
                if (resposta == "1") MenuVisualizarTicket();
                else if (resposta == "2") MenuPrincipal();
                else
                {
                    Console.WriteLine("Opção inválida. Retornando ao menu principal... Pressione alguma tecla para prosseguir.");
                    Console.ReadKey();
                    MenuPrincipal();
                }
            }
            else
            {
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

                    var historico = Ticket_View.CarregarHistorico(ID);

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
                        Console.WriteLine("2 - Editar chamado");
                        Console.WriteLine("3 - Encerrar chamado");
                        Console.WriteLine("4 - Voltar ao menu principal");

                        resposta = Console.ReadLine();

                        if (resposta == "1")
                        {
                            Console.WriteLine("---------------------------------------------------------");
                            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Digitando nova ocorrência...");
                            Console.ResetColor();

                            Console.BackgroundColor = ConsoleColor.Blue;
                            string texto = Console.ReadLine();

                            //Retorna cor padrão
                            Console.ResetColor();
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.Write(texto);

                            var ticket_hist = new TicketHist()
                            {
                                ID_Ticket = Convert.ToInt32(ID),
                                DataHoraAlteracao = Convert.ToString(DateTime.Now),
                                Texto = texto,
                            };

                            Ticket_View.NovaAtualizacao(ticket_hist);
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("Registro incluído com sucesso! Pressione alguma tecla para prosseguir.");
                            Console.ReadKey();
                            MenuPrincipal();
                        }
                        else if (resposta == "2")
                        {
                            string old_assunto = ticket.Assunto;
                            Tipo_Ticket old_tipo = ticket.Tipo;

                            Console.Clear();
                            Console.WriteLine($"Editando dados do chamado: {ticket.ID}");
                            Console.WriteLine("---------------------------------------------------------");

                            Console.SetCursorPosition(0, 3);
                            Console.Write("Assunto: (Máx. 50 caracteres.) - (Caracteres destacados em vermelho serão desprezados na gravação.)");
                            Console.SetCursorPosition(0, 5);
                            Console.Write("Informe o tipo da ocorrência (0 - BUG /1 - SUGESTÃO):");

                            Console.SetCursorPosition(0, 15);
                            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Pressione [F2] para liberar a digitação e [ENTER] para confirmar!");
                            Console.WriteLine("Pressione [F5] para salvar!");
                            Console.WriteLine(@"Use as setas para cima ↑ e para baixo ↓ para navegar entre os campos!");
                            Console.ResetColor();

                            Console.SetCursorPosition(0, 4);

                            string novo_assunto = "";
                            Tipo_Ticket novo_tipo = Tipo_Ticket.VAZIO;
                            int posicao = 1;
                            while (true)
                            {
                                if (posicao == 1) Console.SetCursorPosition(0, 4);
                                if (posicao == 2) Console.SetCursorPosition(0, 6);

                                var key = Console.ReadKey(true);

                                if (key.Key == ConsoleKey.UpArrow && posicao > 1) posicao--;
                                if (key.Key == ConsoleKey.DownArrow && posicao < 2) posicao++;
                                if (key.Key == ConsoleKey.Escape)
                                {
                                    MenuPrincipal();
                                    return;
                                }

                                if (key.Key == ConsoleKey.F2)
                                {
                                    if (posicao == 1)
                                    {
                                        Console.Write(new string(' ', Console.WindowWidth));
                                        Console.SetCursorPosition(0, 4);
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                        novo_assunto = Console.ReadLine();
                                        Console.ResetColor();

                                        int tam_excesso = 0;

                                        if (novo_assunto.Length > 50)
                                        {
                                            for (int i = 0; i < novo_assunto.Length; i++)
                                            {
                                                if (i >= 50)
                                                {
                                                    tam_excesso++;
                                                }
                                            }
                                            Console.SetCursorPosition(0, 4);
                                            //..................................................................

                                            //Retorna cor padrão
                                            Console.SetCursorPosition(0, 4);
                                            Console.ResetColor();
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.SetCursorPosition(0, 4);
                                            Console.Write(novo_assunto.Substring(0, 50));

                                            //Printando excedente do assunto em vermelho
                                            Console.SetCursorPosition(50, 4);
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write(novo_assunto.Substring(50, tam_excesso));
                                            Console.ResetColor();

                                            //campo assunto deve ir no máximo 50 para o BD
                                            novo_assunto = novo_assunto.Substring(0, 50);
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(0, 4);
                                            Console.ResetColor();
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.SetCursorPosition(0, 4);
                                            Console.Write(novo_assunto);
                                        }
                                        posicao++; //AVANÇA PARA O PRÓXIMO CAMPO

                                    }
                                    else if (posicao == 2)
                                    {
                                        Console.Write(new string(' ', 61));
                                        Console.SetCursorPosition(0, 6);
                                        Console.BackgroundColor = ConsoleColor.Blue;
                                        string temp = Console.ReadLine();

                                        if (temp == "1")
                                        {
                                            novo_tipo = Tipo_Ticket.BUG;

                                            //Retorna cor padrão
                                            Console.SetCursorPosition(0, 6);
                                            Console.ResetColor();
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.SetCursorPosition(0, 6);
                                            Console.Write(temp);

                                            //posicao++; //AVANÇA PARA O PRÓXIMO CAMPO
                                        }
                                        else if (temp == "2")
                                        {
                                            novo_tipo = Tipo_Ticket.SUGESTAO;

                                            //Retorna cor padrão
                                            Console.SetCursorPosition(0, 6);
                                            Console.ResetColor();
                                            Console.Write(new string(' ', Console.WindowWidth));
                                            Console.SetCursorPosition(0, 6);
                                            Console.Write(temp);

                                            //posicao++; //AVANÇA PARA O PRÓXIMO CAMPO
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(0, 6);
                                            Console.BackgroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Tipo chamado inválido! Siga as orientações da linha anterior.");
                                            Console.ResetColor();
                                        }
                                    }
                                }
                                else if (key.Key == ConsoleKey.F5)
                                {
                                    string camposAlterados = "";
                                    DB = new SqliteDB("Database.db");
                                    if (novo_assunto != "")
                                    {
                                        if (novo_assunto != old_assunto)
                                        {
                                            DB.ExecuteNonQuery("UPDATE Ticket SET Assunto = @ASSUNTO WHERE ID = @ID", new { ASSUNTO = novo_assunto, ID });
                                            camposAlterados = "[ASSUNTO]";
                                        }
                                    }
                                    if (novo_tipo != Tipo_Ticket.VAZIO)
                                    {
                                        if (novo_tipo != old_tipo)
                                        {
                                            DB.ExecuteNonQuery("UPDATE Ticket SET Tipo = @TIPO WHERE ID = @ID", new { TIPO = novo_tipo, ID });
                                            if (camposAlterados == "") _ = "[TIPO]";
                                            else camposAlterados += " [TIPO]";
                                        }
                                    }
                                    if (camposAlterados != "")
                                    {
                                        var ticket_hist = new TicketHist()
                                        {
                                            ID_Ticket = Convert.ToInt32(ID),
                                            DataHoraAlteracao = Convert.ToString(DateTime.Now),
                                            Texto = $"Alteração de campos realizada. Campos afetados: {camposAlterados}"
                                        };
                                        Ticket_View.NovaAtualizacao(ticket_hist);

                                        Console.SetCursorPosition(0, 14);
                                        Console.WriteLine("Dados alterados com sucesso! Pressione alguma tecla para prosseguir.");
                                        Console.ReadKey();
                                        MenuVisualizarTicket();
                                        return;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(0, 14);
                                        Console.WriteLine("Nenhum campo foi alterado. Voltando ao menu de pesquisa de tickets... Pressione alguma tecla para prosseguir.");
                                        Console.ReadKey();
                                        MenuVisualizarTicket();
                                        return;
                                    }
                                }
                            }
                        }
                        else if (resposta == "3")
                        {
                            DB = new SqliteDB("Database.db");

                            DB.ExecuteNonQuery("UPDATE Ticket SET Finalizado = @Tipo WHERE ID = @ID", new { ID, Tipo = true });

                            var ticket_hist = new TicketHist()
                            {
                                ID_Ticket = Convert.ToInt32(ID),
                                DataHoraAlteracao = Convert.ToString(DateTime.Now),
                                Texto = "Chamado encerrado!"
                            };
                            Ticket_View.NovaAtualizacao(ticket_hist);

                            Console.WriteLine("Chamado encerrado com sucesso! Pressione alguma tecla para prosseguir.");
                            Console.ReadKey();
                            MenuPrincipal();
                        }
                        else if (resposta == "4") MenuPrincipal();

                        else
                        {
                            Console.WriteLine("Opção inválida. Retornando ao menu principal... Pressione alguma tecla para prosseguir.");
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
                    Console.WriteLine("Não encontrado nenhum registro com esse ID! Pressione alguma tecla para prosseguir.");
                    Console.ResetColor();
                    Console.ReadKey();
                    MenuVisualizarTicket();
                }
            }
        }
    }
}
