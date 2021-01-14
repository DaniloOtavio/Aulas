using System;
using System.Collections.Generic;
using System.Text;
using Aula.Lib.Aula08;

namespace Aula.Lib.Aula09
{
    /// <summary>
    /// View para trabalhar com SQLite
    /// </summary>
    public class ProdutoView_SqlLite : IProdutoView
    {
        /// <summary>
        /// Consulta o produto com base na key informada
        /// </summary>
        /// <param name="key">Key do produto</param>
        /// <returns>Retorna a key encontrada na classe ProdutoCadastro</returns>
        public ProdutoCadastro BuscarProduto(string key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Faz o cadastro do produto caso o mesmo não exista. Caso exista apenas substitui a key existente com as alterações
        /// </summary>
        /// <param name="Key">Key do produto</param>
        /// <param name="Produto">Classe do produto</param>
        public void CadastrarAlterarProduto(string Key, ProdutoCadastro Produto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Listar todas as keys cadastradas
        /// </summary>
        /// <returns>Retorna todas as keys</returns>
        public string[] ListarTodasKeys()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Configuração do banco de dados
        /// </summary>
        public void Setup()
        {
            throw new NotImplementedException();
        }
    }
}
