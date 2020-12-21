using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Bedelho
{
    static class DemoAula1
    {
        static void parte1()
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Array");
            int[] array = { 1, 3, 5, 73, 9 };
            mostraAGalera(array);

            Console.WriteLine("Lista");
            List<int> lst = new List<int>() { 1, 3, 5, 73, 9 };
            mostraAGalera(lst);


            void mostraAGalera(IEnumerable<int> galera)
            {
                foreach (var g in galera)
                {
                    Console.WriteLine($"Maluco: {g}");
                }
            }

        }

        static void parte2()
        {
            Console.WriteLine("Hello World!");

            var numeros = RetornaTodosOsNumerosParesEntre(13, 17);

            //14, 16

            foreach (var n in numeros)
            {
                Console.WriteLine(n);
            }
            static List<int> RetornaTodosOsNumerosParesEntre(int inicio, int fim)
            {
                List<int> pares = new List<int>();

                for (int i = inicio; i <= fim; i++)
                {
                    if (i % 2 == 0)
                    {
                        pares.Add(i);
                    }
                }
                return pares;
            }
        }
    }
}
