﻿using Aula.Lib.Aula09;
using Simple.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula08
{
    class ProdutoView_SQLite : IProdutoViewExpandido
    {
        public SqliteDB BD { get; private set; }

        //USANDO LAMBDA (O PRÓPRIO => JÁ DÁ O RETURN, ENTÃO ECONOMIZA LINHA, MAS FICA DIFÍCIL PRA LER)
        public ProdutoCadastro BuscarProduto(string key) => BD.Get<ProdutoCadastro>("Nome", key);

        public ProdutoCadastro[] BuscarProdutoParteNome(string nome)
        {
            nome = $"%{nome}%";
            var produtos = BD.ExecuteQuery<ProdutoCadastro>($"SELECT * FROM ProdutoCadastro WHERE Nome LIKE @Nome ", new { nome });
            return produtos.ToArray();
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
            BD = new SqliteDB("BDSistemaEstoque.db");

            BD.CreateTables()
              .Add<ProdutoCadastro>()
              .Commit();
        }
    }
}