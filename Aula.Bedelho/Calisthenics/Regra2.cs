using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Bedelho.Calisthenics
{
    public class Regra2
    {
        // DO NOT use the ELSE keyword
        public static void run_old()
        {
            while (true)
            {
                Console.WriteLine("Escolha a bebida (café, coca, vinho)");
                var bebida = Console.ReadLine();

                if (bebida == "café")
                {
                    Console.WriteLine("Aqui está, Sr.");
                }
                else if (bebida == "coca")
                {
                    Console.WriteLine("QUe merda, hein ? .... vai lá, toma sua coca");
                }
                else if (bebida == "vinho")
                {
                    Console.WriteLine("Tens 18 maluco ? Qual é sua idade");

                    if (int.TryParse(Console.ReadLine(), out int idade))
                    {
                        if (idade < 18)
                        {
                            Console.WriteLine("Xispa vagabundo");
                        }
                        else
                        {
                            Console.WriteLine("Um homem de classe ....");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Idade inválida");
                    }
                }
                else
                {
                    Console.WriteLine("We don't do that here");
                }
            }
        }
        public static void run_new()
        {
            var itens = new Cardapio();
            var garcom = new Garcom();

            var disponiveis = string.Join(", ", itens.Receitas.Keys);

            while (true)
            {

                Console.WriteLine($"Escolha a bebida ({disponiveis})");
                var bebida = Console.ReadLine();

                garcom.Servir(bebida, itens);
            }
        }

        public class Garcom
        {
            public void Servir(string nomeReceita, Cardapio cardapio)
            {
                if (cardapio.Receitas.ContainsKey(nomeReceita))
                {
                    var action = cardapio.Receitas[nomeReceita];
                    action();
                }
                else
                {
                    Console.WriteLine("We don't do that here");
                }
            }
        }

        public class Cardapio
        {
            public Dictionary<string, Action> Receitas { get; init; }


            public Cardapio()
            {
                Receitas = new Dictionary<string, Action>();

                Receitas.Add("café", servirCafe);
                Receitas.Add("coca", servirCoca);
                Receitas.Add("vinho", servirVinho);
            }

            private void servirVinho()
            {
                Console.WriteLine("Qual a sua idade?");
                string idade = Console.ReadLine();

                if (!MaiorDeIdade(idade))
                {
                    Console.WriteLine("Xispa, vagabundo");
                    return;
                }

                Console.WriteLine("Bela pedida");
            }

            private void servirCoca()
            {
                Console.WriteLine("cê vai morê !1!11");
            }

            private void servirCafe()
            {
                Console.WriteLine("Aqui está, Sr.");
            }

            bool MaiorDeIdade(string idade)
            {
                return Convert.ToInt32(idade) >= 18;
            }
            
        }


    }
}
