using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula04
{
    /// <summary>
    /// Exercícios Aula01
    /// </summary>
    public static class ExercicioAula04
    {
        #region NúmerosParesEntre
        /// <summary>
        /// Função para verificar números pares entre 2 valores
        /// </summary>
        /// <param name="Inicio">Início do período</param>
        /// <param name="Fim">Fim do período</param>
        /// <returns>Retorna números pares</returns>
        public static double[] NumerosParesEntre(int Inicio, int Fim)
        {
            if (Inicio >= Fim)
            {
                return Array.Empty<double>();
            }
            double[] numerosPares = new double[(Fim - Inicio) / 2];
            int pos = 0;

            for (int i = Inicio; i < Fim; i++)
            {
                if (i % 2 == 0)
                {
                    numerosPares[pos] = i;
                    _ = pos++;
                }
            }
            return numerosPares;
        }
        #endregion

        #region NumerosMultiplos2e3Entre
        /// <summary>
        /// Função para retornar números múltiplos de 2 e 3
        /// </summary>
        /// <param name="Inicio">Início do período</param>
        /// <param name="Fim">Fim do período</param>
        /// <returns>Retorna números múltiplos entre 2 e 3</returns>
        //////public static List<int> NumerosMultiplo2e3Entre(int Inicio, int Fim)
        //////{
        //////    List<int> multiplos2e3 = new List<int>();
        //////    int pos = 0;

        //////    for (int i = Inicio; i < Fim; i++)
        //////    {
        //////        if (i % 2 == 0 || i % 3 == 0)
        //////        {
        //////            multiplos2e3.Add(i);
        //////            _ = pos++;
        //////        }
        //////    }
        //////    return multiplos2e3;
        //////}
        public static int[] NumerosMultiplo2e3Entre(int Inicio, int Fim)
        {
            int arraySize = 0;
            for (int i = Inicio; i < Fim; i++)
            {
                if (i % 2 == 0 || i % 3 == 0)
                {
                    arraySize += 1;
                }
            }

            int[] multiplos2e3 = new int[arraySize];
            int pos = 0;

            for (int i = Inicio; i < Fim; i++)
            {
                if (i % 2 == 0 || i % 3 == 0)
                {
                    multiplos2e3[pos] = i;
                    _ = pos++;
                }
            }
            return multiplos2e3;

        }
        #endregion

        #region Fibonacci
        /// <summary>
        /// Calcula Fibonacci
        /// </summary>
        /// <param name="Quantidade">Quantidade de números</param>
        /// <returns>Retorna a quantidade de números calculados</returns>
        public static int[] Fibonacci(int Quantidade)
        {
            if (Quantidade > 46) { return Array.Empty<int>(); }

            int x = 0;
            int y = 1;
            int[] numeros = new int[Quantidade + 1];

            for (int i = 0; i <= Quantidade; i++)
            {
                if (i == 0) { numeros[i] = 0; }
                else if (i == 1) { numeros[i] = 1; }
                else
                {
                    int z = x + y;
                    numeros[i] = z;
                    x = y;
                    y = z;

                    if (z > 2147483647)
                    {
                        return Array.Empty<int>();
                    }    
                }
                
            }
            return numeros;
        }
        #endregion
    }
}

