using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Lib.Tools
{
    /// <summary>
    /// Helper para as aulas
    /// </summary>
    public class UI_CSNHelper
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
                Console.Clear();
                for (int i = 0; i < Opcoes.Length; i++)
                {
                    if (selecionado == i) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(Opcoes[i]);
                }

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selecionado > 0) selecionado--;
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
    }
}
