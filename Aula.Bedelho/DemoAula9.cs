using System;
using System.IO;
using System.Text;
using Aula.Lib.Aula08;

namespace Aula.Bedelho
{
    internal class DemoAula9
    {
        internal static void ExemploSerializacao()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new ProdutoCadastro()
            {
                GUID = Guid.NewGuid(),
                Nome = "Sblevers"
            });

            //json = json;

            var produto = Newtonsoft.Json.JsonConvert.DeserializeObject<ProdutoCadastro>(json);
            //produto = produto;

            using var ms = new MemoryStream();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ProdutoCadastro));
            serializer.Serialize(ms, produto);
            var xml = Encoding.UTF8.GetString(ms.ToArray());

            var strReader = new StringReader(xml);
            var prod2 = (ProdutoCadastro)serializer.Deserialize(strReader);

        }

        internal static void ExemploUI1()
        {
            string[] nomes = { "João", "Maria", "Sblevers", "Sei lá" };

            Console.WriteLine("Escolha o item:");
            for (int i = 0; i < nomes.Length; i++)
            {
                Console.WriteLine($"{i+1} - {nomes[i]}");
            }

            var opcao = Console.ReadLine();
            var codigo = int.Parse(opcao) - 1;
            Console.WriteLine($"Você escolheu: {nomes[codigo]}");

        }
        internal static void ExemploUI2()
        {
            int selecionado = 0;
            string[] nomes = { "João", "Maria", "Sblevers", "Sei lá" };

            bool executando = true;
            while (executando)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                for (int i = 0; i < nomes.Length; i++)
                {
                    if (selecionado == i) Console.BackgroundColor = ConsoleColor.Blue;
                    else Console.BackgroundColor = ConsoleColor.Black;

                    Console.WriteLine(nomes[i]);
                }

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selecionado > 0) selecionado--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selecionado < nomes.Length - 1) selecionado++;
                        break;

                    case ConsoleKey.Enter:
                        executando = false;
                        break;
                    case ConsoleKey.Escape:
                        return;

                    default:
                        continue;
                }
            }
            Console.Clear();
            Console.WriteLine($"Você escolheu: {nomes[selecionado]}");

        }
    }
}