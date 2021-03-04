using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Bedelho.Calisthenics
{
    // First Class Collections
    public class Regra4
    {
        void run()
        {
            var venda = new Vendas();
            venda.Add(new Produtos());


        }

        public class Produtos
        {
            public int ID { get; set; }
            public string Nome { get; set; }
        }

        public class ProdutosCollection : IEnumerable<Produtos>
        {
            List<Produtos> produtos = new List<Produtos>();

            public void Add(Produtos produto) => produtos.Add(produto);


            public IEnumerator<Produtos> GetEnumerator()
            {
                return produtos.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return produtos.GetEnumerator();
            }
        }

        public class Vendas
        {
            ProdutosCollection Produtos = new ProdutosCollection();

            public void Add(Produtos produto) => Produtos.Add(produto);


        }
    



    }
}
