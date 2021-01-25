using System;
using System.Text;

namespace Aula.Lib.Tools
{
    /// <summary>
    /// Helper para as aulas
    /// </summary>
    public static class UI_CSNHelper
    {
        /// <summary>
        /// Monta um menu
        /// </summary>
        /// <param name="Opcoes">Array com as opções desejadas</param>
        /// <param name="TopCursor">Posição do cursor no topo</param>
        /// <param name="Limpar">Limpar ou não o console</param>
        /// <returns>Retorna um menu estruturado</returns>
        public static int ExibirMenu(string[] Opcoes, int TopCursor, bool Limpar)
        {
            int selecionado = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                if (Limpar == true) Console.Clear();
                else
                {
                    Console.SetCursorPosition(0, TopCursor);
                    for (int i = 0; i < Opcoes.Length; i++)
                    {
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                    }
                    Console.SetCursorPosition(0, TopCursor);
                }
                
                Console.SetCursorPosition(30, Console.CursorTop);
                Console.Write("┌");
                Console.Write(new string('─',60));
                Console.WriteLine("┐");
                Console.SetCursorPosition(30, Console.CursorTop);
                Console.WriteLine($"|Selecione uma opção abaixo:{new string(' ',33)}|");

                for (int i = 0; i < Opcoes.Length; i++)
                {
                    Console.SetCursorPosition(30, Console.CursorTop);
                    Console.Write("|");
                    if (selecionado == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }

                    Console.SetCursorPosition(31, Console.CursorTop);

                    if (Opcoes[i].Length > 30)
                    {
                        if (Opcoes.Length <= 9)
                        {
                            Console.Write($"{i + 1}-{Opcoes[i].Substring(0,30)}\n");
                            Console.SetCursorPosition(91, Console.CursorTop-1);
                            
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("|");
                            Console.SetCursorPosition(30, Console.CursorTop + 1);
                            Console.Write("|");

                            if (selecionado == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                            }
                            
                            Console.Write($"{Opcoes[i].Substring(30, Opcoes[i].Length - 30)}");
                            Console.SetCursorPosition(91, Console.CursorTop);


                            //Console.Write($"{i + 1}-{Opcoes[i].Substring(0, 30)}\n{new string(' ', 30)}{Opcoes[i].Substring(30, Opcoes[i].Length - 30)} {new string(' ', 60 - Opcoes[i].Length - 3)}");
                        }
                        else Console.Write($"{Opcoes[i]} {new string(' ', 60 - Opcoes[i].Length - 1)}");
                    }
                    else
                    {
                        if (Opcoes.Length <= 9) Console.Write($"{i + 1}-{Opcoes[i]} {new string(' ', 60 - Opcoes[i].Length - 3)}");
                        else Console.Write($"{Opcoes[i]} {new string(' ', 60 - Opcoes[i].Length - 1)}");

                    }

                    Console.ResetColor();
                    Console.WriteLine("|");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(30, Console.CursorTop);
                Console.Write("└");
                Console.Write(new string('─', 60));
                Console.WriteLine("┘");
                
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selecionado > 0) selecionado--;
                        else if (selecionado == 1) break;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selecionado < Opcoes.Length - 1) selecionado++;
                        break;

                    case ConsoleKey.Enter:
                        Console.ForegroundColor = ConsoleColor.White;
                        return selecionado;
                    case ConsoleKey.Escape:
                        Console.ForegroundColor = ConsoleColor.White;
                        return -1;
                    case ConsoleKey.D1:
                        selecionado = 0;
                        break;
                    case ConsoleKey.D2:
                        selecionado = 1;
                        break;
                    case ConsoleKey.D3:
                        selecionado = 2;
                        break;
                    case ConsoleKey.D4:
                        selecionado = 3;
                        break;
                    case ConsoleKey.D5:
                        selecionado = 4;
                        break;
                    case ConsoleKey.D6:
                        selecionado = 5;
                        break;
                    case ConsoleKey.D7:
                        selecionado = 6;
                        break;
                    case ConsoleKey.D8:
                        selecionado = 7;
                        break;
                    case ConsoleKey.D9:
                        selecionado = 8;
                        break;

                    case ConsoleKey.NumPad1:
                        selecionado = 0;
                        break;
                    case ConsoleKey.NumPad2:
                        selecionado = 1;
                        break;
                    case ConsoleKey.NumPad3:
                        selecionado = 2;
                        break;
                    case ConsoleKey.NumPad4:
                        selecionado = 3;
                        break;
                    case ConsoleKey.NumPad5:
                        selecionado = 4;
                        break;
                    case ConsoleKey.NumPad6:
                        selecionado = 5;
                        break;
                    case ConsoleKey.NumPad7:
                        selecionado = 6;
                        break;
                    case ConsoleKey.NumPad8:
                        selecionado = 7;
                        break;
                    case ConsoleKey.NumPad9:
                        selecionado = 8;
                        break;

                    default:
                        continue;
                }
            }
        }
        /// <summary>
        /// Muda a cor do fundo no modo de edição
        /// </summary>
        /// <returns>Retorna o texto</returns>
        public static string ModoEdicao()
        {
            string conteudo;

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            conteudo = Console.ReadLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(conteudo.ToUpper());

            return conteudo.ToUpper().Replace("%", "")
                                     .Replace("'", "")
                                     .Replace("\"", "")
                                     .Replace("=", "")
                                     .Replace("!", "");
        }


        /// <summary>
        /// Escreve um texto formatado com as cores padrão
        /// </summary>
        /// <param name="Escrita">Texto a ser formatado</param>
        /// <param name="Fore1">Cor do texto inicial</param>
        /// <param name="Back1">Cor do fundo inicial</param>
        /// <param name="Fore2">Cor do texto ao término</param>
        /// <param name="Back2">Cor do fundo ao término</param>
        public static void ExibirTexto(string Escrita, ConsoleColor Fore1, ConsoleColor Back1, ConsoleColor Fore2, ConsoleColor Back2)
        {
            Console.BackgroundColor = Back1;
            Console.ForegroundColor = Fore1;

            Console.WriteLine(Escrita);

            Console.BackgroundColor = Back2;
            Console.ForegroundColor = Fore2;
        }
    }
}
