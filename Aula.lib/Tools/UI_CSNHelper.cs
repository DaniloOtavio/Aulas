using System;
using System.Collections.Generic;
using System.Text;

namespace Aula.Lib.Tools
{
    public class UI_CSNHelper
    {
        public static int ExibirMenu(string[] Opcoes)
        {
            int selecionado = 0;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                for (int i = 0; i < Opcoes.Length; i++)
                {
                    if (selecionado == i) Console.BackgroundColor = ConsoleColor.Blue;
                    else Console.BackgroundColor = ConsoleColor.Black;

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
                        return selecionado;
                    case ConsoleKey.Escape:
                        return -1;

                    default:
                        continue;
                }
            }
        }
    }
}
