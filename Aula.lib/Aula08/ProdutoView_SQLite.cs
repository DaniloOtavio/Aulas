using Aula.Lib.Aula09;
using Simple.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula08
{
    class ProdutoView_SQLite : IProdutoView
    {
        public SqliteDB BD { get; private set; }

        public ProdutoCadastro BuscarProduto(string key)
        {
            var produto = BD.Get<ProdutoCadastro>(key);
            return produto;
        }
        public void CadastrarAlterarProduto(ProdutoCadastro Produto)
        {
            BD.Insert(Produto);
        }
        public ProdutoCadastro[] ListarTodosOsProdutos()
        {
            var produtos = BD.GetAll<ProdutoCadastro>();
            return produtos.ToArray();
        }
        public void Setup()
        {
            BD = new SqliteDB("Database.db");

            BD.CreateTables()
              .Add<ProdutoCadastro>()
              .Commit();
        }
    }
}
