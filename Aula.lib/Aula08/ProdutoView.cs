using Isaac.FileStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Classe contendo os métodos e funções do sistema
    /// </summary>
    public class ProdutoView
    {
        /// <summary>
        /// Variável do BD
        /// </summary>
        public static Core BD { get; private set; }

        /// <summary>
        /// Grava o produto no cadastro
        /// </summary>
        /// <param name="Key">Identificador do produto</param>
        /// <param name="Produto">Classe produtos a ser preenchida</param>
        public static void CadastrarProduto(string Key, ProdutoCadastro Produto)
        {
            BD.Insert(Key,Produto);
        }

        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        /// <returns>Retorna todos os produtos cadastrados</returns>
        public static string[] ListarTodosProdutos()
        {
            var produtos = BD.GetAllKeys();
            return produtos.ToArray();
        }

        /// <summary>
        /// Busca o produto
        /// </summary>
        /// <param name="key">Nome do Produto (key)</param>
        /// <returns>Retorna o produto cadastrado</returns>
        public static ProdutoCadastro BuscarProduto(string key)
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
        public static void Setup()
        {
            BD = new Core("SistemaEstoque");
        }
    }
}
