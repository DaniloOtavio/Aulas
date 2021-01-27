using System;
using System.Collections.Generic;

namespace Aula.Lib.Aula13
{
    /// <summary>
    /// Classe de extensões genéricas
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Filtro genérico
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="itens">Itens a serem filtrados</param>
        /// <param name="regra">Regra</param>
        /// <returns>Retorna itens</returns>
        public static IEnumerable<T> Filtrar<T>(this IEnumerable<T> itens, Func<T,bool> regra)
        {
            foreach (var item in itens)
            {
                if (!regra(item)) continue;
                yield return item;
            }
        }

        /// <summary>
        /// Filtrar pelos primeiros X
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="itens">Itens a serem filtrados</param>
        /// <param name="regra">Regra</param>
        /// <returns>Retorna os X primeiros itens</returns>
        public static IEnumerable<T> PrimeirosX<T>(this IEnumerable<T> itens, int regra)
        {
            int i = 1;
            foreach (var item in itens)
            {
                if (i <= regra) yield return item;
                i++;
            }
        }
        public static IEnumerable<T> PulaOsPrimeirosX<T>(this IEnumerable<T> itens, int regra)
        {
            int i = 1;
            foreach (var item in itens)
            {
                if (i > regra) yield return item;
                i++;
            }
        }

        public static IEnumerable<TOut> Empacotar<TIn, TOut>(this IEnumerable<TIn> itens, Func<TIn, TOut> regra)
        {
            foreach (TIn item in itens)
            {
                yield return regra(item);
            }
        }

    }
}
