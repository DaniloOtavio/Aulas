using Simple.Sqlite;
using System.Linq;

namespace Aula.Lib.Aula06.E0
{
    /// <summary>
    /// View para Produto
    /// </summary>
    public class Item_View
    {
        /// <summary>
        /// Variável SQLite
        /// </summary>
        public static SqliteDB DB { get; private set; }

        /// <summary>
        /// Grava o item no banco
        /// </summary>
        /// <param name="item">Código do item</param>
        public static void Inserir(Item item)
        {
            DB.Insert(item);
        }
        /// <summary>
        /// Consulta por número de patrimônio
        /// </summary>
        /// <param name="Patrimonio">Número do patrimônio</param>
        /// <returns>Retorna o item através da consulta por número do patrimônio</returns>
        public static Item BuscaPatrimonio(string Patrimonio)
        {
           return DB.Get<Item>("Patrimonio", Patrimonio);
        }
        /// <summary>
        /// Busca todos os itens
        /// </summary>
        /// <returns>Retorna todos os itens</returns>
        public static Item[] TrazACambada()
        {
            return DB.GetAll<Item>().ToArray() ;
        }
        /// <summary>
        /// Configuração Banco de dados
        /// </summary>
        public static void Setup()
        {
            DB = new SqliteDB("MyShit.db");

            DB.CreateTables()
              .Add<Item>()
              .Commit();
        }
    }
}
