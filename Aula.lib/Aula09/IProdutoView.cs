using System;
using System.Collections.Generic;
using System.Text;
using Aula.Lib.Aula08;

namespace Aula.Lib.Aula09
{
    public interface IProdutoView
    {
        void CadastrarProduto(string Key, ProdutoCadastro Produto);
        string[] ListarTodasKeys();
        ProdutoCadastro BuscarProduto(string key);
        void Setup();
    }
}
