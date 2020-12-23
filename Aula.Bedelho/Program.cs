using System;

namespace Aula.Bedelho
{
    class Program
    {
        static void Main(string[] args)
        {
            var FibonacciCalculado = Fibonacci(0);

            foreach (var n in FibonacciCalculado)
            {
                Console.WriteLine(n);
            }

        }
        
        static int x = 0;
        static int y = 1;
        static int z = 0;
        
        static long[] Fibonacci(int Quantidade)
        {
            long[] soma = new long[Quantidade];

            for (int i = 0; i < Quantidade; i++)
            {
                z = x + y;

                soma[i] = z;

                x = y;
                y = z;
            }

            return soma;

        }





    }
}
