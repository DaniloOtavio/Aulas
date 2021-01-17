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
        ProdutoCadastro[] ListarTodosOsProdutos();
        
        /// <summary>
        /// Realiza a busca de um produto de acordo com parte do nome digitado
        /// </summary>
        /// <param name="nome">Parte do nome do produto a ser pesquisado</param>
        /// <returns>Retorna o produto</returns>
        ProdutoCadastro[] BuscarProdutoParteNome(string nome);

    }
}
