using Isaac.FileStorage;
using System;
using System.Linq;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Classe contendo os métodos e funções do sistema
    /// </summary>
    public class ProdutoView_Arquivo : Aula09.IProdutoViewExpandido
    {
        /// <summary>
        /// Variável do BD
        /// </summary>
        public Core BD { get; private set; }

        /// <summary>
        /// Grava o produto no cadastro
        /// </summary>
        /// <param name="Key">Identificador do produto</param>
        /// <param name="Produto">Classe produtos a ser preenchida</param>
        public void CadastrarAlterarProduto(string Key, ProdutoCadastro Produto)
        {
            BD.Insert(Key,Produto);
        }

        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        /// <returns>Retorna todos os produtos cadastrados</returns>
        public string[] ListarTodasKeys()
        {
            var produtos = BD.GetAllKeys();
            return produtos.ToArray();
        }

        // exemplos que vou remover por hora
        // e depois você re-implementa
        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>Retorna todos os produtos</returns>
        public ProdutoCadastro[] ListarTodosOsProdutos()
        {
            return BD.GetAllKeys()
                     .Select(k => BD.Get<ProdutoCadastro>(k))
                     .ToArray();
        }
        //public static ProdutoCadastro[] ListarProdutosNomeContem(string ParteNome)
        //{
        //    return ListarTodosProdutosProdutos()
        //        .Where(p => p.Nome.Contains(ParteNome))
        //        .ToArray();
        //}


        /// <summary>
        /// Busca o produto
        /// </summary>
        /// <param name="key">Nome do Produto (key)</param>
        /// <returns>Retorna o produto cadastrado</returns>
        public ProdutoCadastro BuscarProduto(string key)
        {
            try
            {
                var produto = BD.Get<ProdutoCadastro>(key);
                return produto;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Inicializa Banco
        /// </summary>
        public void Setup()
        {
            BD = new Core("SistemaEstoque");
        }

        /// <summary>
        /// Realiza a busca de um produto de acordo com parte do nome digitado
        /// </summary>
        /// <param name="nome">Parte do nome do produto a ser pesquisado</param>
        /// <returns>Retorna o produto</returns>
        public ProdutoCadastro[] BuscarProdutoParteNome(string nome)
        {
            return ListarTodosOsProdutos()
                .Where(p => p.Nome.Contains(nome))
                .ToArray();
        }
    }
}
