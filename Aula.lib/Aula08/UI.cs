using Isaac.FileStorage;
using System;
using System.IO;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Interface do Usuário
    /// </summary>
    public class UI
    {
        static readonly string prosseguir = "Pressione qualquer tecla para prosseguir.";
        private static ProdutoView produtoView;

        //public static Core BD { get; private set; }

        /// <summary>
        /// Inicializa o sistema
        /// </summary>
        public static void Run()
        {
            produtoView = new ProdutoView();
            produtoView.Setup();
            Console.WriteLine("Inicializando...");

            MenuPrincipal();

        }
        private static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Cadastrar novo produto");
            Console.WriteLine("2 - Buscar Produtos");
            Console.WriteLine("3 - Sair do sistema");

            string resultado = Console.ReadLine();

            if (resultado == "1")
            {
                MenuCadastrarProduto();
            }
            else if (resultado == "2")
            {
                MenuBuscarProdutos();
            }
            else if (resultado == "3")
            {
                Console.WriteLine($"Saindo... {prosseguir}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Comando não reconhecido! {prosseguir}");
                Console.ReadKey();
                MenuPrincipal();
            }
        }
        private static void MenuBuscarProdutos()
        {
            Console.Clear();
            Console.WriteLine("Digite nome do produto para consultá-lo, digite * (asterisco) para exibir todos ou deixe vazio para voltar ao menu principal");
            string descricao = Console.ReadLine();

            if (descricao == "")
            {
                MenuPrincipal();
                return;
            }
            else if (descricao == "*")
            {
                var produtos = produtoView.ListarTodasKeys();

                foreach (var key in produtos)
                {
                    Console.WriteLine(key);
                }
                Console.Write($"\n{prosseguir}");
                
                Console.ReadKey();
                MenuBuscarProdutos();
                return;
            }
            else
            {
                var produto = produtoView.BuscarProduto(descricao);

                if (produto == null)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Produto não encontrado com essa descrição! {prosseguir}");
                    Console.ResetColor();
                    Console.ReadKey();
                    MenuBuscarProdutos();
                    return;
                }

                Console.Clear();

                Console.WriteLine($"Dados do produto {produto.Nome}");
                Console.WriteLine(new string('-',50));
                Console.WriteLine("\nID do produto:");
                Console.WriteLine(produto.GUID);
                Console.WriteLine("\nLocal de armazenagem:");
                Console.WriteLine(produto.LocalArmazenagem);
                Console.WriteLine("\nQuantidade atual:");
                Console.WriteLine(produto.Quantidade);

                Console.SetCursorPosition(0, 15);
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Alterar nome do produto");
                Console.WriteLine("2 - Alterar quantidade do produto");
                Console.WriteLine("3 - Retornar ao menu principal");

                while (true)
                {
                    string resultado = Console.ReadLine();

                    if (resultado == "1")
                    {
                        throw new NotImplementedException();

                        //BD = new Core("SistemaEstoque");
                        //Console.Clear();
                        //Console.WriteLine("Digite o novo nome do produto...");
                        //string novoNome = Console.ReadLine();
                        //string oldArquivo = $"{BD.DirectoryPath}\\{produto.Nome}.j2k";
                        //
                        //produto.Nome = novoNome;
                        //
                        //BD.Insert<ProdutoCadastro>(produto.Nome, produto);
                        //
                        //Console.WriteLine($"Alteração realizada com sucesso! {prosseguir}");
                        //
                        //File.Delete(oldArquivo);

                        Console.ReadKey();
                        MenuPrincipal();
                        return;
                    }
                    else if (resultado == "2")
                    {
                        throw new NotImplementedException();

                        //Console.Clear();
                        //Console.WriteLine("Digite a nova quantidade do produto...");
                        //string novaQuantidade = Console.ReadLine();
                        //
                        //produto.Quantidade = Convert.ToDecimal(novaQuantidade);
                        //
                        //BD = new Core("SistemaEstoque");
                        //
                        //BD.Insert<ProdutoCadastro>(produto.Nome, produto);
                        //
                        //Console.WriteLine($"Alteração realizada com sucesso! {prosseguir}");
                        //Console.ReadKey();
                        //MenuPrincipal();
                        //return;
                    }
                    else if (resultado == "3")
                    {
                        MenuPrincipal();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Opção inválida! {prosseguir}");
                        Console.ReadKey();
                        Console.SetCursorPosition(0, 19);
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 19);
                    }
                }
            }
        }

        private static void MenuCadastrarProduto()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Cadastrando novo produto... (Pressione ESC para sair.)");
            Console.ResetColor();

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Nome do produto:");

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("ID do produto (Será atribuído automaticamente pelo sistema): ");

            Console.SetCursorPosition(0, 6);
            Console.WriteLine("Local de armazenagem: ");

            Console.SetCursorPosition(0, 8);
            Console.WriteLine("Quantidade: ");

            Console.SetCursorPosition(0, 15);
            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Pressione [F2] para liberar a digitação e [ENTER] para confirmar!");
            Console.WriteLine("Pressione [F5] para salvar!");
            Console.WriteLine("Use as setas para cima ↑ e para baixo ↓ para navegar entre os campos!");
            Console.ResetColor();

            Console.SetCursorPosition(0, 3);

            string nomeProduto = "";
            string localArmazenagem = "";
            string qtdeEstoque = "";
            
            int pos = 1;
            while (true)
            {

                if (pos == 1) Console.SetCursorPosition(0, 3);
                if (pos == 2) Console.SetCursorPosition(0, 5);
                if (pos == 3) Console.SetCursorPosition(0, 7);
                if (pos == 4) Console.SetCursorPosition(0, 9);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && pos > 1) pos--;
                if (key.Key == ConsoleKey.DownArrow && pos < 4) pos++;

                if (key.Key == ConsoleKey.Escape)
                {
                    MenuPrincipal();
                    return;
                }

                if (key.Key == ConsoleKey.F2)
                {
                    if (pos == 1)
                    {
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 3);
                        nomeProduto = Console.ReadLine();
                        pos++;
                    }
                    else if (pos == 3)
                    {
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 7);
                        localArmazenagem = Console.ReadLine();
                        pos++;
                    }
                    else if (pos == 4)
                    {
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 9);
                        qtdeEstoque = Console.ReadLine();
                        if (!decimal.TryParse(qtdeEstoque, out _))
                        {
                            Console.SetCursorPosition(0, 9);
                            Console.Write("Valor digitado não é número!");
                            qtdeEstoque = "";
                            Console.SetCursorPosition(0, 9);
                        }
                    }
                }

                if (key.Key == ConsoleKey.F5)
                {
                    if (nomeProduto == "")
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Campo obrigatório!");
                        Console.ResetColor();
                    }
                    if (localArmazenagem == "")
                    {
                        Console.SetCursorPosition(0, 7);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Campo obrigatório!");
                        Console.ResetColor();
                    }
                    if (qtdeEstoque == "")
                    {
                        Console.SetCursorPosition(0, 9);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(0, 9);
                        Console.Write("Campo obrigatório!");
                        Console.ResetColor();
                    }
                    if (nomeProduto != "" && localArmazenagem != "" && qtdeEstoque != "")
                    {
                        var produto = new ProdutoCadastro()
                        {
                            Nome = nomeProduto.ToUpper(),
                            GUID = Guid.NewGuid(),
                            LocalArmazenagem=localArmazenagem.ToUpper(),
                            Quantidade=Convert.ToDecimal(qtdeEstoque),
                        };
                        produtoView.CadastrarProduto(produto.Nome, produto);
                        Console.SetCursorPosition(0, 5);
                        Console.Write(produto.GUID);

                        Console.SetCursorPosition(0, 14);
                        Console.WriteLine($"Produto cadastrado com sucesso! {prosseguir}");
                        
                        Console.ReadKey();
                        MenuPrincipal();
                        return;
                    }
                }
            }
        }

        #region EXEMPLO - CONSULTAR APENAS

        //private static void VisualizarVendas()
        //{
        //    foreach (var key in BD.GetAllKeys())
        //    {
        //        Console.WriteLine(key);
        //    }

        //}

        //private static void ConsultaVenda()
        //{
        //    var vd = BD.Get<Venda>("VD01");

        //    vd = vd;
        //}

        //private static void InserirVenda()
        //{
        //    var venda = new Venda()
        //    {
        //        ID = Guid.NewGuid(),
        //        Total = 12.7M,
        //        Cliente = new Cliente()
        //        {
        //            Nome = "Euzébrio",
        //            CEP = "44.458.995",
        //            Cidade = "Churumelas",
        //            Endereco = "Rua dos Campeões,{](;'\"",
        //        },

        //        Produtos = new Produto[]
        //        {
        //            new Produto()
        //            {
        //                Nome="Celular",
        //                Preco=10.5M
        //            },
        //            new Produto()
        //            {
        //                Nome="Capa",
        //                Preco=2.2M,
        //            }
        //        }
        //    };
        //    BD.Insert($"VD.{venda.ID}", venda);
        //}

        //public class Venda
        //{
        //    public Guid ID { get; set; }
        //    public decimal Total { get; set; }
        //    public Cliente Cliente { get; set; }
        //    public Produto[] Produtos { get; set; }

        //}

        //public class Produto
        //{
        //    public string Nome { get; set; }
        //    public decimal Preco { get; set; }
        //}

        //public class Cliente
        //{
        //    public string Nome { get; set; }
        //    public string Endereco { get; set; }
        //    public string Cidade { get; set; }
        //    public string CEP { get; set; }
        //}

        #endregion
    }
}
