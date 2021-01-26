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
            foreach (var it in itens)
            {
                if (!regra(it)) continue;
                yield return it;
            }
        }
    }
}
