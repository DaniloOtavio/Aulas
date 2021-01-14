using Aula.Lib.Aula08;

namespace Aula.Lib.Aula09
{
    public interface IProdutoView
    {
        void CadastrarAlterarProduto(string Key, ProdutoCadastro Produto);
        string[] ListarTodasKeys();
        ProdutoCadastro BuscarProduto(string key);
        void Setup();
    }
}
