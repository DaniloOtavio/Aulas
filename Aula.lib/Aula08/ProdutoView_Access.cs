using Aula.Lib.Aula09;
using Aula.Lib.Aula11;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;

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
            CMD = new OleDbCommand($"SELECT * FROM ProdutoCadastro WHERE Nome = '{key}'",Con);

            Reader = CMD.ExecuteReader();

            if (Reader.HasRows)
            {
                Reader.Read();
                ProdutoCadastro prod = new ProdutoCadastro()
                {
                    Nome = Reader["Nome"].ToString(),
                    GUID = Guid.Parse(Reader["ID"].ToString()),
                    LocalArmazenagem = Reader["LocalArmazenagem"].ToString(),
                    Quantidade = Convert.ToDecimal(Reader["Quantidade"]),
                };
                return prod;
            }
            else return null;
        }
        /// <summary>
        /// Busca o produto com parte do nome dele
        /// </summary>
        /// <param name="nome">Parte do nome do produto</param>
        /// <returns>Retorna o produto</returns>
        public IEnumerable<ProdutoCadastro> BuscarProdutoParteNomeIE(string nome)
        {
            //return ListarTodosOsProdutos().FiltroNome(nome);

            nome = $"'%{nome}%'";
            nome = nome.Replace("%", "")
                       .Replace("'", "")
                       .Replace("\"", "")
                       .Replace("=", "")
                       .Replace("!", "");

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
        /// <summary>
        /// Busca o produto por parte do nome informado
        /// </summary>
        /// <param name="nome">Nome/ parte do nome do produto</param>
        /// <returns>Retorna o produto</returns>
        public IEnumerable<ProdutoCadastro> BuscarProdutoParteNome(string nome) => BuscarProdutoParteNomeIE(nome);
        /// <summary>
        /// Realiza o cadastro do produto e caso já exista, atualiza
        /// </summary>
        /// <param name="Produto">Classe produtos a ser preenchida</param>
        public void CadastrarAlterarProduto(ProdutoCadastro Produto)
        {
            string SQL = $"SELECT ID FROM ProdutoCadastro WHERE ID = '{Produto.GUID}'";
            CMD = new OleDbCommand
            {
                CommandText = SQL,
                Connection = Con,
            };

            Reader = CMD.ExecuteReader();

            if (!Reader.HasRows) SQL = "INSERT INTO ProdutoCadastro(Nome, ID, LocalArmazenagem, Quantidade) VALUES(@Nome, @ID, @LocalArmazenagem, @Quantidade)";
            else SQL = $"UPDATE ProdutoCadastro SET Nome='{Produto.Nome}', ID='{Produto.GUID}', LocalArmazenagem='{Produto.LocalArmazenagem}', Quantidade='{Produto.Quantidade}' WHERE ID='{Produto.GUID}' ";

            CMD.CommandText = SQL;
            CMD.Parameters.AddWithValue("@Nome", Produto.Nome);
            CMD.Parameters.AddWithValue("@ID", Produto.GUID.ToString());
            CMD.Parameters.AddWithValue("@LocalArmazenagem", Produto.LocalArmazenagem);
            CMD.Parameters.AddWithValue("@Quantidade", Produto.Quantidade);

            CMD.ExecuteNonQuery();
        }
        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        /// <returns>Retorna uma lista com todos os produtos</returns>
        public IEnumerable<ProdutoCadastro> ListarTodosOsProdutos() => BuscarProdutoParteNomeIE("");
        /// <summary>
        /// Configuração do banco de dados
        /// </summary>
        public void Setup()
        {
            string pastaBD = AppDomain.CurrentDomain.BaseDirectory;
            string nomeBD = "SistemaEstoque";
            string senha = "123";


            try
            {
                Con = new OleDbConnection
                {
                    ConnectionString = @$"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pastaBD}\{nomeBD}.accdb;Jet OLEDB:Database Password={senha}"
                };
                Con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                //throw new Exception("Provedor Microsoft.ACE.OLEDB.12.0 não foi encontrado. Certifique-se de que o Microsoft Access esteja instalado e sua respectiva engine.");
            }
        }
        /// <summary>
        /// Função para listar os produtos de forma alternada
        /// </summary>
        /// <returns>Retorna produtos intercalados</returns>
        public IEnumerable<ProdutoCadastro> ProdutosAlternados()
        {
            return ListarTodosOsProdutos().ProdutosAlternados();
        }
    }
}
