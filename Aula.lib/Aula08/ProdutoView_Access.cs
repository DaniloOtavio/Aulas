using Aula.Lib.Aula09;
using System;
using System.IO;
using System.Data.OleDb;
using System.Linq;
using System.Collections.Generic;

namespace Aula.Lib.Aula08
{
    /// <summary>
    /// Classe para banco de dados Access
    /// </summary>
    public class ProdutoView_Access : IProdutoViewExpandido
    {
        /// <summary>
        /// Variável de conexão
        /// </summary>
        public OleDbConnection Con { get; private set; }
        /// <summary>
        /// Variável de comandos
        /// </summary>
        public OleDbCommand CMD { get; set; }

        /// <summary>
        /// Reader para realizar leitura no banco de dados 
        /// </summary>
        public OleDbDataReader Reader { get; set; }

        /// <summary>
        /// Buscar produto com base no nome
        /// </summary>
        /// <param name="key">Nome do produto</param>
        /// <returns>Retorna o produto</returns>
        public ProdutoCadastro BuscarProduto(string key)
        {

            throw new NotImplementedException();
        }
        /// <summary>
        /// Busca o produto com parte do nome dele
        /// </summary>
        /// <param name="nome">Parte do nome do produto</param>
        /// <returns>Retorna o produto</returns>
        public IEnumerable<ProdutoCadastro> BuscarProdutoParteNomeIE(string nome)
        {
            nome = $"'%{nome}%'";
            CMD = new OleDbCommand($"SELECT * FROM ProdutoCadastro WHERE Nome LIKE {nome}", Con);

            Reader = CMD.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    yield return new ProdutoCadastro()
                    {
                        Nome = Reader["Nome"].ToString(),
                        GUID = Guid.Parse(Reader["ID"].ToString()),
                        LocalArmazenagem = Reader["LocalArmazenagem"].ToString(),
                        Quantidade = Convert.ToDecimal(Reader["Quantidade"]),
                    };
                }
            }
        }
        public ProdutoCadastro[] BuscarProdutoParteNome(string nome) => BuscarProdutoParteNomeIE(nome).ToArray();
        /// <summary>
        /// Realiza o cadastro do produto e caso já exista, atualiza
        /// </summary>
        /// <param name="Produto">Classe produtos a ser preenchida</param>
        public void CadastrarAlterarProduto(ProdutoCadastro Produto)
        {
            CMD = new OleDbCommand("INSERT INTO ProdutoCadastro(Nome, ID, LocalArmazenagem, Quantidade) VALUES(@Nome, @ID, @LocalArmazenagem, @Quantidade)", Con);
            CMD.Parameters.AddWithValue("@Nome", Produto.Nome);
            CMD.Parameters.AddWithValue("@ID", Produto.GUID);
            CMD.Parameters.AddWithValue("@LocalArmazenagem", Produto.LocalArmazenagem);
            CMD.Parameters.AddWithValue("@Quantidade", Produto.Quantidade);

            CMD.ExecuteNonQuery();
        }
        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        /// <returns>Retorna uma lista com todos os produtos</returns>
        public ProdutoCadastro[] ListarTodosOsProdutos() => BuscarProdutoParteNomeIE("").ToArray();
        /// <summary>
        /// Configuração do banco de dados
        /// </summary>
        public void Setup()
        {
            Con = new OleDbConnection();
            Con.ConnectionString = "";
            Con.Open();
        }
    }
}
