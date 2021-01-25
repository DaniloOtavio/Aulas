using Aula.Lib.Aula08;
using System;
using System.Collections.Generic;
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
        /// <returns>Retorna um menu estruturado</returns>
        public static int ExibirMenu(string[] Opcoes)
        {
            int selecionado = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

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

                    if (Opcoes.Length <= 9) Console.Write($"{i+1}-{Opcoes[i]} {new string(' ', 60 - Opcoes[i].Length - 3)}");
                    else Console.Write($"{Opcoes[i]} {new string(' ', 60 - Opcoes[i].Length - 1)}");

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

                    default:
                        continue;
                }
            }
        }

        /// <summary>
        /// Cria um menu
        /// </summary>
        /// <param name="Opcoes">Opções para criar o menu</param>
        /// <returns>Retorna o menu criado</returns>
        public static int CriarMenu(string [] Opcoes)
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Opcoes.Length; i++)
            {
                sb.AppendLine($"{new string(' ', 30)} {Opcoes[i]}");

                //Console.SetCursorPosition(30, Console.CursorTop);
                //Console.WriteLine(Opcoes[i].ToString());



            }
            Console.Write(sb.ToString());

            var escolha = Console.ReadLine();

            if (!int.TryParse(escolha, out int value))
            {
                Console.WriteLine("Apenas números são permitidos na seleção do menu! Pressione qualquer tecla para prosseguir.");
                Console.ReadKey();
                CriarMenu(Opcoes);
            }
            return value; 
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
            Console.SetCursorPosition(0, Console.CursorTop);

            conteudo = Console.ReadLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(conteudo);

            return conteudo.ToUpper();
        }
    }
}
