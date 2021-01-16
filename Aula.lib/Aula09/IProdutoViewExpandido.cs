using System;
using System.Collections.Generic;
using System.Text;
using Aula.Lib.Aula08;

namespace Aula.Lib.Aula09
{
    /// <summary>
    /// Interface expandida da IProdutoView
    /// </summary>
    public interface IProdutoViewExpandido : IProdutoView
    {
        /// <summary>
        /// Listar todos os produtos cadastrados
        /// </summary>
        /// <returns>Retorna todos os produtos cadastrados</returns>
        ProdutoCadastro[] ListarTodosProdutosProdutos();

        /// <summary>
        /// Busca o produto por parte do nome
        /// </summary>
        /// <param name="nome">Parte do nome a ser pesquisado</param>
        void BuscaProduto(string nome)
        {

        }
    }
}
