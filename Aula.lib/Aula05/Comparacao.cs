using System;
using System.Collections;

namespace Aula.Lib.Aula05
{
    /// <summary>
    /// Classe para comparação de itens
    /// </summary>
    public class Comparacao
    {
        /// <summary>
        /// Ordenar itens
        /// </summary>
        /// <param name="Itens">Itens a serem ordenados</param>
        /// <returns>Retorna os itens ordenados</returns>
        public static int[] Ordenar(int[] Itens)
        {
            if (Itens == null) throw new ArgumentNullException();
            int[] valores = new int[Itens.Length];
            valores = Itens;

            int x;

            for (int i = 0; i < Itens.Length; i++)
            {
                for (int a = 0; a < Itens.Length; a++)
                {
                    if (valores[i] < valores[a])
                    {
                        x = valores[i];
                        valores[i] = valores[a];
                        valores[a] = x;
                    }
                }
            }
            return valores;
        }
    }
}
