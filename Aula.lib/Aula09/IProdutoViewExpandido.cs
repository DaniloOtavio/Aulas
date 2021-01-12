using System;
using System.Collections.Generic;
using System.Text;
using Aula.Lib.Aula08;

namespace Aula.Lib.Aula09
{
    public interface IProdutoViewExpandido : IProdutoView
    {
        ProdutoCadastro[] ListarTodosProdutosProdutos();
    }
}
