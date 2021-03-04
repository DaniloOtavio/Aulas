using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Bedelho.Calisthenics
{
    public class Regra5
    {
        // One dot per line
        void run()
        {
            var view = new Lib.Aula08.ProdutoView_SQLite();
            // don't do that ....
            Console.WriteLine(view.BuscarProdutoParteNome("a").First().Nome);

            // do that
            var produtosBuscados = view.BuscarProdutoParteNome("a");
            var primeiro = produtosBuscados.First();
            Console.WriteLine(primeiro.Nome);

            // Exceção:
            // 1. Linq pode .... mas não exagera

            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //não fazer
            items.Where(i => i % 2 == 0).Select(i => i.ToString()).OrderBy(o => o);

            //fazer
            items.Where(i => i % 2 == 0)
                 .Select(i => i.ToString())
                 .OrderBy(o => o);


            // 2. Chaining
            var db = new Simple.Sqlite.SqliteDB("fuck");
            // chaining ... ... vai...
            db.CreateTables()
              .Add<int>()
              .Add<decimal>()
              .Commit();

        }



    }
}
