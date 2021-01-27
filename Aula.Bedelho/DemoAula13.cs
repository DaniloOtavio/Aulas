using System;
using System.Linq;
using Aula.Lib.Aula08;
using Aula.Lib.Aula11;
using Aula.Lib.Aula13;

namespace Aula.Bedelho
{
    public class DemoAula13
    {
        delegate string dOqueEnfiaNoMeioDaString(string TextoBase);

        public static void fuck()
        {
            string[] text = 
            { 
                "I have no more fucks to give",
                "My fucks are running dry",
                "My fucks have gone away ",
                "This shit is a fuck",
                "Fuck is fuck",
                "Fuck not fuck",
                "Should stop saying fuck",
                "Not stop saying fuck",
                "Fuck!",
                "Don't care this fuck"
            };
            ProdutoCadastro[] itens = new ProdutoCadastro[0];
            var ordenado = itens.OrderBy(p => p.Nome);



            text.OrderBy(o => o);

            // Ordena e exibe na tela
            //ExibeMaiusculo(text);

            //ExibeTextoDelega(text, str => str.ToUpper());

            //FILTRO GENÉRICO
            Console.WriteLine("FILTRANDO PELO CONTEÚDO 'IS'");
            var resultado1 = Extensions.Filtrar<string>(text, parte => parte.Contains("is"));

            foreach (var r in resultado1)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("RETORNANDO OS 5 PRIMEIROS ITENS");
            //RETORNAR OS X PRIMEIROS
            var resultado2 = Extensions.PrimeirosX<string>(text, 5);

            foreach (var r in resultado2)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("RETORNANDO OS 5 ÚLTIMOS ITENS");
            //PULA OS X PRIMEIROS
            var resultado3 = Extensions.PulaOsPrimeirosX<string>(text, 5);

            foreach (var r in resultado3)
            {
                Console.WriteLine(r);
            }
            Console.ReadKey();

        }

        static void ExibeTextoDelega(string[] textos, dOqueEnfiaNoMeioDaString regra)
        {
            foreach (var t in textos)
            {
                var novo = regra(t);
                Console.WriteLine(novo);
            }
        }

        static void ExibeMaiusculo(string[] textos)
        {
            foreach (var t in textos)
            {
                Console.WriteLine(t.ToUpper());
            }
        }
        static void ExibeMinusculo(string[] textos)
        {
            foreach (var t in textos)
            {
                Console.WriteLine(t.ToLower());
            }
        }
        private static void ExibeInvertido(string[] textos)
        {
            foreach (var t in textos)
            {
                Console.WriteLine(t.Reverse().ToArray());
            }
        }


        static string ToUpper(string t) => t.ToUpper();
        static string ToLower(string t) => t.ToLower();
        static string ToReverse(string t) => new string(t.Reverse().ToArray());

    }
}
