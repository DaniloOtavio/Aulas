using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula06.E0
{
    /// <summary>
    /// Interface do usuário
    /// </summary>
    public class UI
    {
        /// <summary>
        /// Start do sistema
        /// </summary>
        public static void RUN()
        {
            Console.WriteLine("My awesome piece of shit");

            //Inserir o item
            //Buscar por patrimônio
            //Buscar Todos
            Console.WriteLine("Inicializando...");

            Item_View.Setup();

            Console.WriteLine("Selecione uma opção: ");

            Console.WriteLine("1 - Inserir o item");
            Console.WriteLine("2 - Buscar por Patrimônio");
            Console.WriteLine("3 - Listar todos");

            string resultado = Console.ReadLine();

            if (resultado == "1")
            {
                CadastrarNovo();
            }
            else if (resultado == "2")
            {
                BuscarPatrimonio();
            }
            else if (resultado == "3")
            {
                ListarTodos();
            }
            else
            {
                Console.WriteLine("Você é um imbecil, to vazando!");
            }
        }

        private static void ListarTodos()
        {
            var todos = Item_View.TrazACambada();

            foreach (var item in todos)
            {
                Console.WriteLine($"ID: {item.ID} Nome: {item.Nome}");
            }
        }

        private static void BuscarPatrimonio()
        {
            Console.WriteLine("Digite o número do patrimônio a ser localizado:");

            string patrimonio = Console.ReadLine();

            var item = Item_View.BuscaPatrimonio(patrimonio);

            if (item == null) Console.WriteLine("Item não localizado");
            else
            {
                Console.WriteLine("Localizado: ");
                Console.WriteLine($"ID: {item.ID} Nome: {item.Nome}");
            }
        }

        private static void CadastrarNovo()
        {
            Console.WriteLine("Digite o nome do item");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o local do item");
            string local = Console.ReadLine();
            Console.WriteLine("Digite o patrimônio do item");
            string patrimonio = Console.ReadLine();

            var item = new Item()
            {
                Nome = nome,
                Local = local,
                Patrimonio = patrimonio
            };

            Item_View.Inserir(item);
        }
    }
}
