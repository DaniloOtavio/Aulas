﻿using System;
using System.Collections.Generic;
using Aula.Lib.Aula08;

namespace Aula.Lib.Aula11
{
    /// <summary>
    /// Extensão da model ExtensaoProdutoCadastro
    /// </summary>
    public static class ExtensaoProdutoCadastro
    {

        /// <summary>
        /// Buscar produto por parte do nome
        /// </summary>
        /// <param name="produtos">Produtos</param>
        /// <param name="parteNome">Parte do nome</param>
        /// <returns>Retorna o produto com base no nome</returns>
        public static IEnumerable<ProdutoCadastro> FiltroNome(this IEnumerable<ProdutoCadastro> produtos, string parteNome)
        {
            foreach (var prod in produtos)
            {
                if (prod.Nome.ToString().Contains(parteNome))
                {
                    yield return prod;
                }
            }
        }
        public static IEnumerable<T> Filtro<T>(this IEnumerable<T> produtos, Func<T, bool> regra)
        {
            foreach (var prod in produtos)
            {
                if (!regra(prod)) continue;

                yield return prod;
            }
        }
        /// <summary>
        /// Função para consultar produtos intercalados
        /// </summary>
        /// <param name="produtos">Produtos</param>
        /// <returns>Retorna os produtos de forma intercalada</returns>
        public static IEnumerable<ProdutoCadastro> ProdutosAlternados(this IEnumerable<ProdutoCadastro> produtos)
        {
            bool pula = false;
            foreach (var prod in produtos)
            {
                if (pula == false)
                {
                    yield return prod;
                    pula = true;
                }
                else pula = false;
            }
        }
    }
}
