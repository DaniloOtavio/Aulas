using Aula.Lib.Aula08;

namespace Aula.Lib.Aula09
{
    /// <summary>
    /// Interface para as views
    /// </summary>
    public interface IProdutoView
    {
        /// <summary>
        /// Faz o cadastro do produto caso o mesmo não exista. Caso exista apenas substitui a key existente com as alterações
        /// </summary>
        /// <param name="Produto">Classe do produto</param>
        void CadastrarAlterarProduto(ProdutoCadastro Produto);
        /// <summary>
        /// Listar todas as keys cadastradas
        /// </summary>
        /// <returns>Retorna todas as keys</returns>
        ProdutoCadastro[] ListarTodosOsProdutos();
        /// <summary>
        /// Consulta o produto com base na key informada
        /// </summary>
        /// <param name="key">Key do produto</param>
        /// <returns>Retorna a key encontrada na classe ProdutoCadastro</returns>
        ProdutoCadastro BuscarProduto(string key);
   
        /// <summary>
        /// Configuração do banco de dados
        /// </summary>
        void Setup();
    }
}
