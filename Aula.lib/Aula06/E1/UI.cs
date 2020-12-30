using System;
namespace Aula.Lib.Aula06.E1
{
    public class UI
    {
        public static void Inicializar()
        {
            Ticket_View.Setup();
            Console.WriteLine("Inicializando...");
            MenuPrincipal();

            string resposta = Console.ReadLine();

            if (resposta == "1") MenuNovoTicket();
            else if (resposta == "2") MenuVisualizarTicket();
            else if (resposta == "3") Console.WriteLine("Saindo...");
            else
            {
                Console.WriteLine("Comando não reconhecido!"); 
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
                else if (resposta == "3") MenuPrincipal();
                else Console.WriteLine("Comando não reconhecido!");
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

                long id; string assunto=""; var data = DateTime.Today; string tipo=""; string responsavel=""; string versao=""; string ocorrencia = "";
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
                    if (key.Key == ConsoleKey.Escape) MenuPrincipal();

                    if (key.Key == ConsoleKey.F2)
                    {
                        string espaco = "";
                        if (posicao == 1)
                        {
                            for (int i = 0; i < assunto.Length; i++) espaco += " ";
                            
                            Console.Write(espaco);
                            Console.SetCursorPosition(0, 2);
                            assunto = Console.ReadLine();
                        }
                        else if (posicao == 2)
                        {
                            for (int i = 0; i < tipo.Length; i++) espaco += " ";

                            Console.Write(espaco);
                            Console.SetCursorPosition(0, 4);
                            tipo = Console.ReadLine();
                        }
                        else if (posicao == 3)
                        {
                            for (int i = 0; i < responsavel.Length; i++) espaco += " ";

                            Console.Write(espaco);
                            Console.SetCursorPosition(0, 6);
                            responsavel = Console.ReadLine();
                        }
                        else if (posicao == 4)
                        {
                            for (int i = 0; i < versao.Length; i++) espaco += " ";

                            Console.Write(espaco);
                            Console.SetCursorPosition(0, 8);
                            versao = Console.ReadLine();
                        }
                        else if (posicao == 5)
                        {
                            for (int i = 0; i < ocorrencia.Length; i++) espaco += " ";

                            Console.Write(espaco);
                            Console.SetCursorPosition(0, 10);
                            ocorrencia = Console.ReadLine();
                        }
                    }

                    if (key.Key == ConsoleKey.F5)
                    {
                        if (CamposPreenchidos(assunto, tipo, responsavel, versao, ocorrencia) == false)
                        {
                            Console.SetCursorPosition(0, 2);
                            posicao = 1;
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

                        Console.WriteLine("Registro incluído com sucesso!");
                        MenuPrincipal();
                    }
                }

                static bool CamposPreenchidos(string assunto,string tipo,string responsavel,string versao,string ocorrencia)
                {
                    string campos = "";
                    if (assunto == "") campos = "[ASSUNTO]";
                    if (tipo == "") if (campos == "") campos = "[TIPO]"; else campos += " [TIPO]";
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

                var ticket = Ticket_View.ConsultaTicket(ID);
                var tickethist = Ticket_View.BuscarHistorico(ID);
                Console.Clear();

                Console.WriteLine($"Ticket nº: {ticket.ID } - Aberto em: {ticket.DataAbertura} - Por: {ticket.Responsavel}");
                Console.WriteLine("");
                Console.WriteLine("Atualizações:");

                foreach (var item in tickethist)
                {

                }
            }
        }
    }
}
