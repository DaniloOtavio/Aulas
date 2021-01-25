using Aula.Lib.Aula08;
using Aula.Lib.Aula11;

namespace Aula.Bedelho
{
    class Program
    {
        static void Main(string[] args)
        {
            //string bagaca = Console.ReadLine();

            //if (int.TryParse(bagaca,out int valor))
            //{
            //    Console.WriteLine($"Foi digitado o número '{valor}'");
            //}
            //else
            //{
            //    Console.WriteLine($"O texto '{bagaca}' não é um número.");
            //}

            //Aula.Lib.Aula06.E1.UI.Inicializar();

            //DemoAula9.ExemploUI2();
            DemoAula13.fuck();

            //string[] itens = { "Maçã", "Banana", "Laranja", "Abacaxi" };
            //int opcao = Lib.Tools.UI_CSNHelper.ExibirMenu(itens);
            //if (opcao == -1)
            //{
            //    Console.WriteLine("Menu cancelado");
            //}
            //else
            //{
            //    Console.WriteLine(itens[opcao]);
            //}

            //Lib.Aula08.UI.Run();


            var pv = new Lib.Aula08.ProdutoView_SQLite();

            var favoritos = pv.ListarTodosOsProdutos().Filtro(p => p.LocalArmazenagem == "C");



        }


    }
}
