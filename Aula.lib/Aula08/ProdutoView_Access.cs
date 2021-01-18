using Aula.Lib.Aula09;
using System;
using System.Data.OleDb;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Classe para banco de dados Access
    /// </summary>
    public class ProdutoView_Access : IProdutoViewExpandido
    {
        /// <summary>
        /// Buscar produto com base no nome
        /// </summary>
        /// <param name="key">Nome do produto</param>
        /// <returns>Retorna o produto</returns>
        public ProdutoCadastro BuscarProduto(string key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Busca o produto com parte do nome dele
        /// </summary>
        /// <param name="nome">Parte do nome do produto</param>
        /// <returns>Retorna o produto</returns>
        public ProdutoCadastro[] BuscarProdutoParteNome(string nome)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Realiza o cadastro do produto e caso já exista, atualiza
        /// </summary>
        /// <param name="Produto">Classe produtos a ser preenchida</param>
        public void CadastrarAlterarProduto(ProdutoCadastro Produto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        /// <returns>Retorna uma lista com todos os produtos</returns>
        public ProdutoCadastro[] ListarTodosOsProdutos()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Configuração do banco de dados
        /// </summary>
        public void Setup()
        {
            string pastaSistema = "";


        }
    }
}
