using Aula.Lib.Aula08;
using System.Collections.Generic;

namespace Aula.Lib.Aula09
{
    /// <summary>
    /// Interface expandida da IProdutoView
    /// </summary>
    public interface IProdutoViewExpandido : IProdutoView
    {
        /// <summary>
        /// Realiza a busca de um produto de acordo com parte do nome digitado
        /// </summary>
        /// <param name="nome">Parte do nome do produto a ser pesquisado</param>
        /// <returns>Retorna o produto</returns>
        IEnumerable<ProdutoCadastro> BuscarProdutoParteNome(string nome);

    }
}
