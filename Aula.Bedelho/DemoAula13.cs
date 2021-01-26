using System;
using System.Linq;
using Aula.Lib.Aula08;

namespace Aula.Bedelho
{
    public class DemoAula13
    {
        delegate string dOqueEnfiaNoMeioDaString(string TextoBase);

        public static void fuck()
        {
            string[] text = { 
                "I have no more fucks to give",
                "My fucks are running dry",
                "My fucks have gone away "
            };


            ProdutoCadastro[] itens = new ProdutoCadastro[0];
            var ordenado = itens.OrderBy(p => p.Nome);



            text.OrderBy(o => o);

            // Ordena e exibe na tela
            //ExibeMaiusculo(text);

            ExibeTextoDelega(text, str => str.ToUpper());
        }

        static void ExibeTextoDelega(string[] textos, dOqueEnfiaNoMeioDaString regra)
        {
            foreach (var t in textos)
            {
                var novo = regra(t);
                //Console.WriteLine(novo);
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
