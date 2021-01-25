using Aula.Lib.Aula09;
using Aula.Lib.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Interface do Usuário
    /// </summary>di
    public class UI
    {
        static string temp_Nome = "";
        static string temp_Local = "";
        static string temp_Qtde = "";

        static readonly string prosseguir = "Pressione qualquer tecla para prosseguir.";
        private static IProdutoViewExpandido produtoView;

        //public static Core BD { get; private set; }

        /// <summary>
        /// Inicializa o sistema
        /// </summary>
        public static void Run()
        {
        
            //Console.WindowWidth = 120;

            MenuEscolheDB();
            produtoView.Setup();
            MenuPrincipal();
        }
        private static void MenuEscolheDB()
        {

            var opcoes = UI_CSNHelper.ExibirMenu(new string[] {"Arquivo JSON (NoSQL)",
                                                               "Banco de dados SQLite",
                                                               "Microsoft Access",
                                                               "Sair do Sistema"}, 0,true);

            if (opcoes == 0)
            {
                produtoView = new ProdutoView_Arquivo();
            }
            else if (opcoes == 1)
            {
                //Console.WriteLine($"Essa opção está temporariamente indisponível! {prosseguir}");
                //Console.ReadKey();
                //MenuEscolheDB();
                //return;
                produtoView = new ProdutoView_SQLite();
                //MenuPrincipal();
            }
            else if (opcoes == 2)
            {
                produtoView = new ProdutoView_Access();
            }
            else if (opcoes == 3)
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
            var opcoes = UI_CSNHelper.ExibirMenu(new string[] {"Cadastrar novo produto",
                                                               "Listar Produtos",
                                                               "Buscar Produto",
                                                               "Sair do sistema"},0,true);

            if (opcoes == 0)
            {
                MenuCadastrarProduto();
            }
            else if (opcoes == 1)
            {
                MenuListarProdutos();
            }
            else if (opcoes == 2)
            {
                MenuBuscarProduto();
            }
            else if (opcoes == 3)
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
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Digite o nome (ou parte do nome) do produto a ser pesquisado e pressione [ENTER].\n" +
                              "Para retornar ao menu principal deixe o nome em branco e pressione [ENTER].");

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            string nome = UI_CSNHelper.ModoEdicao();

            if (nome != "")
            {
                var produtos = produtoView.BuscarProdutoParteNome(nome).ToArray();

                if (produtos.Length == 0)
                {
                    Console.WriteLine($"Nenhum produto encontrado com essa descrição! {prosseguir}");
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
                    List<string> opcoes = new List<string>();

                    foreach (var p in produtos) opcoes.Add(p.Nome);

                    var opcao = UI_CSNHelper.ExibirMenu(opcoes.ToArray(),0,true);

                    var key = opcao;

                    if (key < produtos.Length && key == -1)
                    {
                        MenuBuscarProduto();
                        return;
                    }

                    var produto = produtoView.BuscarProduto(produtos[key].Nome.ToString());
                    MenuCarregaProduto(produto);
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
            var opcao1 = UI_CSNHelper.ExibirMenu(new string[] { "Todos os produtos",
                                                                "Produtos Alternados"},0,true);

            ProdutoCadastro[] produtos = new ProdutoCadastro[] { };

            if (opcao1 == 0)
            {
                produtos = produtoView.ListarTodosOsProdutos().ToArray();
            }
            else if (opcao1 == 1)
            {
                produtos = produtoView.ProdutosAlternados().ToArray();
            }
            else
            {
                MenuPrincipal();
                return;
            }

            if (produtos.Length == 0)
            {
                Console.WriteLine($"Nenhum produto encontrado! {prosseguir}");
                Console.ReadKey();
                MenuPrincipal();
            }
            else
            {
                List<string> opcoes = new List<string>();

                foreach (var p in produtos) opcoes.Add(p.Nome);

                var opcao = UI_CSNHelper.ExibirMenu(opcoes.ToArray(),0,true);

                var key = opcao;

                if (key > produtos.Length)
                {
                    Console.WriteLine($"Opção inválida! Selecione uma das opções disponíveis. {prosseguir}");
                    Console.ReadKey();
                    MenuListarProdutos();
                    return;
                }

                if (key == -1) MenuListarProdutos();

                var produto = produtoView.BuscarProduto(produtos[key].Nome.ToString());
                MenuCarregaProduto(produto);
            }
        }
        private static void MenuCarregaProduto(ProdutoCadastro produto)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nome do produto:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{produto.Nome}");

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Identificador único:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{produto.GUID}");

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Local de armazenagem:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{produto.LocalArmazenagem}");

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Quantidade:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{produto.Quantidade}");

            var opcao = UI_CSNHelper.ExibirMenu(new string[] { "Alterar nome do produto",
                                                               "Alterar quantidade do produto",
                                                               "Sair"},Console.CursorTop,false);

            //string opcao = Console.ReadLine();

            if (opcao == 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Digite o novo nome do produto:");
                string novoNome = UI_CSNHelper.ModoEdicao();

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

                    MenuCarregaProduto(produto);
                }
            }
            else if (opcao == 1)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Digite a nova quantidade do produto:");
                string novaQuantidade = UI_CSNHelper.ModoEdicao();

                if (novaQuantidade == "")
                {
                    Console.WriteLine($"Quantidade não informada! Operação anulada. {prosseguir}");
                    Console.ReadKey();
                    MenuCarregaProduto(produto);
                    return;
                }
                else
                {
                    if (!decimal.TryParse(novaQuantidade, out _))
                    {
                        Console.SetCursorPosition(0, 1);
                        Console.Write($"Valor digitado não é número! {prosseguir}");
                        Console.ReadKey();
                        novaQuantidade = "";
                        MenuCarregaProduto(produto);
                    }
                    else
                    {
                        produto.Quantidade = Convert.ToDecimal(novaQuantidade);

                        produtoView.CadastrarAlterarProduto(produto);

                        MenuCarregaProduto(produto);
                    }
                }
            }
            else if (opcao == 2)
            {
                MenuPrincipal();
            }
            else
            {
                MenuCarregaProduto(produto);
            }
        }
        private static void MenuCadastrarProduto()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.DarkBlue; Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nome do produto:");

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("ID do produto (Será atribuído automaticamente pelo sistema): ");

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Local de armazenagem: ");

            Console.SetCursorPosition(0, 6);
            Console.WriteLine("Quantidade: ");

            Console.SetCursorPosition(0, 15);
            Console.BackgroundColor = ConsoleColor.Yellow; Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Pressione [F2] para liberar a digitação e [ENTER] para confirmar!");
            Console.WriteLine("Pressione [F5] para salvar!");
            Console.WriteLine("Pressione ESC para sair!");
            Console.WriteLine("Use as setas para cima e para baixo para navegar entre os campos!");
            Console.ResetColor();

            Console.SetCursorPosition(0, 1);

            string nomeProduto = "";
            string localArmazenagem = "";
            string qtdeEstoque = "";

            if (temp_Nome != "")
            {
                nomeProduto = temp_Nome;
                Console.SetCursorPosition(0, 1);
                Console.Write(nomeProduto);
                temp_Nome = "";
            }
            if (temp_Local != "")
            {
                localArmazenagem = temp_Local;
                Console.SetCursorPosition(0, 5);
                Console.Write(localArmazenagem);
                temp_Local = "";
            }
            if (temp_Qtde != "")
            {
                qtdeEstoque = temp_Qtde;
                Console.SetCursorPosition(0, 7);
                Console.Write(qtdeEstoque);
                temp_Qtde = "";
            }

            int pos = 1;
            while (true)
            {
                if (pos == 1) Console.SetCursorPosition(0, 1);
                if (pos == 2) Console.SetCursorPosition(0, 3);
                if (pos == 3) Console.SetCursorPosition(0, 5);
                if (pos == 4) Console.SetCursorPosition(0, 7);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && pos > 1) pos--;
                if (key.Key == ConsoleKey.DownArrow && pos < 4) pos++;

                if (key.Key == ConsoleKey.Escape)
                {
                    temp_Nome = nomeProduto;
                    temp_Local = localArmazenagem;
                    temp_Qtde = qtdeEstoque;

                    var opcao = UI_CSNHelper.ExibirMenu(new string[] { "Sair sem salvar",
                                                                       "Continuar editando"},0,true);
                    if (opcao == 0)
                    {
                        temp_Nome = "";
                        temp_Local = "";
                        temp_Qtde = "";
                        MenuPrincipal();
                        
                        return;
                    }
                    else if (opcao == 1)
                    {
                        MenuCadastrarProduto();
                    }
                }

                if (key.Key == ConsoleKey.F2)
                {
                    if (pos == 1)
                    {
                        nomeProduto = UI_CSNHelper.ModoEdicao();
                        pos++;
                    }
                    else if (pos == 3)
                    {
                        localArmazenagem = UI_CSNHelper.ModoEdicao();
                        pos++;
                    }
                    else if (pos == 4)
                    {
                        qtdeEstoque = UI_CSNHelper.ModoEdicao();

                        if (!decimal.TryParse(qtdeEstoque, out _))
                        {
                            Console.SetCursorPosition(0, 7);
                            Console.Write("Valor digitado não é número!");
                            qtdeEstoque = "";
                            Console.SetCursorPosition(0, 7);
                        }
                    }
                }

                if (key.Key == ConsoleKey.F5)
                {
                    if (nomeProduto == "")
                    {
                        Console.SetCursorPosition(0, 1);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Campo obrigatório!");
                        Console.ResetColor();
                    }
                    if (localArmazenagem == "")
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Campo obrigatório!");
                        Console.ResetColor();
                    }
                    if (qtdeEstoque == "")
                    {
                        Console.SetCursorPosition(0, 7);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(0, 7);
                        Console.Write("Campo obrigatório!");
                        Console.ResetColor();
                    }
                    if (nomeProduto != "" && localArmazenagem != "" && qtdeEstoque != "")
                    {
                        var opcao = UI_CSNHelper.ExibirMenu(new string[] { "Gravar e sair",
                                                                           "Gravar e inserir novo",
                                                                           "Continuar editando"},0,true);

                        temp_Nome = nomeProduto;
                        temp_Local = localArmazenagem;
                        temp_Qtde = qtdeEstoque;

                        if (opcao == 0)
                        {
                            var produto = new ProdutoCadastro()
                            {
                                Nome = nomeProduto.ToUpper(),
                                GUID = Guid.NewGuid(),
                                LocalArmazenagem = localArmazenagem.ToUpper(),
                                Quantidade = Convert.ToDecimal(qtdeEstoque),
                            };

                            produtoView.CadastrarAlterarProduto(produto);
                            temp_Nome = "";
                            temp_Local = "";
                            temp_Qtde = "";
                            MenuPrincipal();
                            return;
                        }
                        else if (opcao == 1)
                        {
                            var produto = new ProdutoCadastro()
                            {
                                Nome = nomeProduto.ToUpper(),
                                GUID = Guid.NewGuid(),
                                LocalArmazenagem = localArmazenagem.ToUpper(),
                                Quantidade = Convert.ToDecimal(qtdeEstoque),
                            };
                            produtoView.CadastrarAlterarProduto(produto);

                            temp_Nome = "";
                            temp_Local = "";
                            temp_Qtde = "";
                            MenuCadastrarProduto();
                            return;
                        }
                        else if (opcao == 2)
                        {
                            MenuCadastrarProduto();
                            return;
                        }
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
