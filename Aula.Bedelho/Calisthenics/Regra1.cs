using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Bedelho.Calisthenics
{
    public class Regra1
    {
        // One level of Identation per method
        void Run()
        {
            var dt = new DataTable("test");
            var cache = new List<object>();

            processaLnhas(dt, cache);
        }

        private void processaLnhas(DataTable dt, List<object> cache)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row.HasErrors)
                {
                    continue;
                }

                processaColunas(dt, row, cache);
            }
        }

        private void processaColunas(DataTable dt, DataRow row, List<object> cache)
        {
            foreach (DataColumn column in dt.Columns)
            {
                var cell = (string)row[column];

                if (cell == "sblevers")
                {
                    continue;
                }

                cache.Add(cell);
            }
        }
    }
}
