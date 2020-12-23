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
        /// <summary>
        /// Função para verificar números pares entre 2 valores
        /// </summary>
        /// <param name="Inicio">Início do período</param>
        /// <param name="Fim">Fim do período</param>
        /// <returns>Retorna números pares</returns>
        public static double[] NumerosParesEntre(int Inicio, int Fim)
        {
            if (Inicio % 2 == 0 && Fim % 2 != 0)
            {
                return Array.Empty<double>();
            }
            else if(Inicio % 2 != 0 && Fim % 2 == 0)
            {
                return Array.Empty<double>();
            }
            else if (Inicio >= Fim)
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


    }
}
