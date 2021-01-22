using Aula.Lib.Aula09;
using Aula.Lib.Tools;
using System;
using System.Linq;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Interface do Usuário
    /// </summary>
    public class UI
    {
        static readonly string prosseguir = "Pressione qualquer tecla para prosseguir.";
        private static IProdutoViewExpandido produtoView;
        
        //public static Core BD { get; private set; }

        /// <summary>
        /// Inicializa o sistema
        /// </summary>
        public static void Run()
        {
            MenuEscolheDB();

            Console.WriteLine("Inicializando...");
            produtoView.Setup();
            MenuPrincipal();
        }
        private static void MenuEscolheDB()
        {

            var opcoes = UI_CSNHelper.CriarMenu(new string[] {"Selecione uma opção abaixo:",
                                                              "1 - Arquivo JSON (NoSQL)",
                                                              "2 - Banco de dados SQLite",
                                                              "3 - M$ Access (Não Recomendável)",
                                                              "4 - Sair do Sistema"});

            if (opcoes == 1)
            {
                produtoView = new ProdutoView_Arquivo();
            }
            else if (opcoes == 2)
            {
                //Console.WriteLine($"Essa opção está temporariamente indisponível! {prosseguir}");
                //Console.ReadKey();
                //MenuEscolheDB();
                //return;
                produtoView = new ProdutoView_SQLite();
                //MenuPrincipal();
            }
            else if (opcoes == 3)
            {
                produtoView = new ProdutoView_Access();
            }
            else if (opcoes == 4)
            {
                Console.Write($"Saindo... {prosseguir}");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Opção inválida! {prosseguir}");
                Console.ReadKey();
                MenuEscolheDB();
            }
        }
        private static void MenuPrincipal()
        {
            var opcoes = UI_CSNHelper.CriarMenu(new string[] {"Selecione uma opção abaixo:",
                                                              "1 - Cadastrar novo produto",
                                                              "2 - Listar Produtos",
                                                              "3 - Buscar Produto",
                                                              "4 - Sair do sistema"});

            if (opcoes == 1)
            {
                MenuCadastrarProduto();
            }
            else if (opcoes == 2)
            {
                MenuListarProdutos();
            }
            else if (opcoes == 3)
            {
                MenuBuscarProduto();
            }
            else if (opcoes == 4)
            {
                Console.WriteLine($"Saindo... {prosseguir}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Opção inválida! {prosseguir}");
                Console.ReadKey();
                MenuPrincipal();
            }
        }
        private static void MenuBuscarProduto()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome (ou parte do nome) do produto a ser pesquisado e pressione [ENTER].\nPara retornar ao menu principal deixe o nome em branco e pressione [ENTER].");
            string nome = Console.ReadLine().ToUpper();

            if (nome != "")
            {
                var produtos = produtoView.BuscarProdutoParteNome(nome).ToArray();

                if (produtos.Length == 0)
                {
                    Console.WriteLine($"Nenhum produto encontrado com essa informação! {prosseguir}");
                    Console.ReadKey();
                    MenuBuscarProduto();
                    return;
                }
                else if (produtos.Length == 1)
                {
                    ProdutoCadastro prod = new ProdutoCadastro()
                    {
                        Nome = produtos[0].Nome,
                        GUID = produtos[0].GUID,
                        LocalArmazenagem = produtos[0].LocalArmazenagem,
                        Quantidade = produtos[0].Quantidade,
                    };
                    MenuCarregaProduto(prod);
                }
                else if (produtos.Length > 1)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Escolha uma opção abaixo e pressione [ENTER].");
                    Console.ResetColor();

                    Console.WriteLine($"Produtos encontrados: ({produtos.Length})\n");

                    for (int i = 0; i < produtos.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} - {produtos[i].Nome}");
                    }
                    var opcao = Console.ReadLine();
                    var key = int.Parse(opcao) - 1;

                    if (key + 1 > produtos.Length)
                    {
                        Console.WriteLine($"Opção inválida! Retornando ao menu anterior. {prosseguir}");
                        Console.ReadKey();
                        MenuBuscarProduto();
                        return;
                    }

                    var prod1 = produtoView.BuscarProdutoParteNome(produtos[key].Nome).ToArray();
                    ProdutoCadastro prod2 = new ProdutoCadastro()
                    {
                        GUID = prod1[0].GUID,
                        Nome = prod1[0].Nome,
                        LocalArmazenagem = prod1[0].LocalArmazenagem,
                        Quantidade = prod1[0].Quantidade,
                    };
                    MenuCarregaProduto(prod2);
                }
            }
            else
            {
                MenuPrincipal();
                return;
            }
        }
        private static void MenuListarProdutos()
        {
            Console.Clear();
            var produtos = produtoView.ListarTodosOsProdutos().ToArray();

            if (produtos.Length == 0)
            {
                Console.WriteLine($"Nenhum produto encontrado! {prosseguir}");
                Console.ReadKey();
                MenuPrincipal();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Escolha uma opção abaixo e pressione [ENTER].");
                Console.ResetColor();

                Console.WriteLine($"Produtos encontrados: ({produtos.Length})\n");

                for (int i = 0; i < produtos.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {produtos[i].Nome}");
                }
                var opcao = Console.ReadLine();

                if (!int.TryParse(opcao, out _))
                {
                    Console.WriteLine($"Valor digitado não é número!{prosseguir}");
                    Console.ReadKey();
                    MenuListarProdutos();
                    return;
                }

                var key = int.Parse(opcao) - 1;

                if (key + 1 > produtos.Length)
                {
                    Console.WriteLine($"Opção inválida! Selecione uma das opções disponíveis. {prosseguir}");
                    Console.ReadKey();
                    MenuListarProdutos();
                    return;
                }
                var produto = produtoView.BuscarProduto(produtos[key].Nome);
                MenuCarregaProduto(produto);
            }
        }
        private static void MenuCarregaProduto(ProdutoCadastro produto)
        {
            Console.Clear();
            Console.WriteLine("Nome do produto:");
            Console.WriteLine($"{produto.Nome}\n");
            Console.WriteLine("Identificador único:");
            Console.WriteLine($"{produto.GUID}\n");
            Console.WriteLine("Local de armazenagem:");
            Console.WriteLine($"{produto.LocalArmazenagem}\n");
            Console.WriteLine("Quantidade:");
            Console.WriteLine($"{produto.Quantidade}\n");
            Console.WriteLine($"{new string('-', 50)}\n");

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Alterar nome do produto");
            Console.WriteLine("2 - Alterar quantidade do produto");
            Console.WriteLine("3 - Sair");

            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Clear();
                Console.WriteLine("Digite o novo nome do produto:");
                string novoNome = Console.ReadLine();

                if (novoNome == "")
                {
                    Console.WriteLine($"Nome informado em branco! Operação anulada. {prosseguir}");
                    Console.ReadKey();
                    MenuCarregaProduto(produto);
                    return;
                }
                else
                {
                    produto.Nome = novoNome.ToUpper();

                    produtoView.CadastrarAlterarProduto(produto);

                    Console.WriteLine($"Nome alterado com sucesso! {prosseguir}");
                    Console.ReadKey();
                    MenuCarregaProduto(produto);
                }
            }
            else if (opcao == "2")
            {
                Console.Clear();
                Console.WriteLine("Digite a nova quantidade do produto:");
                string novaQuantidade = Console.ReadLine();

                if (novaQuantidade == "")
                {
                    Console.WriteLine($"Quantidade não informada! Operação anulada. {prosseguir}");
                    Console.ReadKey();
                    MenuCarregaProduto(produto);
                    return;
                }
                else
                {
                    produto.Quantidade = Convert.ToDecimal(novaQuantidade);

                    produtoView.CadastrarAlterarProduto(produto);

                    Console.WriteLine($"Quantidade alterada com sucesso! {prosseguir}");
                    Console.ReadKey();
                    MenuCarregaProduto(produto);
                }
            }
            else if (opcao == "3")
            {
                MenuPrincipal();
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
                            LocalArmazenagem = localArmazenagem.ToUpper(),
                            Quantidade = Convert.ToDecimal(qtdeEstoque),
                        };
                        produtoView.CadastrarAlterarProduto(produto);
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
