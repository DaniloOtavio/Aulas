using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula02
{
    /// <summary>
    /// Classe feita para testar o CPF
    /// </summary>
    public class Exemplo02
    {
        //Fonte para obter o cálculo do CPF: http://www.macoratti.net/11/09/c_val1.htm
        //Fonte para entendimento do cálculo: https://campuscode.com.br/conteudos/o-calculo-do-digito-verificador-do-cpf-e-do-cnpj#:~:text=O%20c%C3%A1lculo%20de%20valida%C3%A7%C3%A3o%20do,2%20e%20somamos%20esse%20resultado.

        /// <summary>
        /// VerificarCPF
        /// </summary>
        /// <param name="CPF">CPF da pessoa a ser verificado</param>
        /// <returns>Retorna se o CPF é válido ou não</returns>
        public static bool VerificarCPF(string CPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCPF;
            string digito;
            int soma;
            int resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "")
                     .Replace("-", "")
                     .Replace(" ", "");

            if (CPF.Length != 11)
            {
                return false;
            }
                
            tempCPF = CPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCPF[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;

            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            
            tempCPF += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCPF[i].ToString()) * multiplicador2[i];
            }
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito += resto.ToString();

            return CPF.EndsWith(digito);
        }

        /// <summary>
        /// Aplicar Máscara ao CPF informado
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public static string AplicarMascaraCPF(string CPF)
        {
            return $"{CPF[0..3]}.{CPF[3..6]}.{CPF[6..9]}-{CPF[9..]}";
        }
    }
}
