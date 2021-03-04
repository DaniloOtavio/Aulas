using System;
using ValueOf;

namespace Aula.Bedelho.Calisthenics
{
    public class Regra3
    {
        // Wrap All Primitives (+string)
        public static void Run()
        {
            Console.WriteLine("Infome o peso em KG");
            var pesoKg = Peso.From(int.Parse(Console.ReadLine()));
            var pesoPnds = convertePeso(pesoKg);

            Console.WriteLine($"Seu peso é: {pesoPnds} pounds");
        }


        static Peso convertePeso(Peso pesoKg)
        {
            // 2,20462
            return Peso.From((int)(pesoKg * 2.2));
        }

        public class Peso : ValueOf<int, Peso>
        {
            protected override void Validate()
            {
                if (Value < 0) throw new InvalidOperationException("Na moral?Negativo ...");

                if (Value > 410) throw new InvalidOperationException("Caráio véi ....");
            }
        }

    }
}
