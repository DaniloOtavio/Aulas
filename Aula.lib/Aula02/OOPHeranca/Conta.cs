using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula02.OOP___Herança
{
    /// <summary>
    /// Classe pai de Conta - https://www.caelum.com.br/apostila-csharp-orientacao-objetos/heranca#polimorfismo
    /// </summary>
    public class Conta
    {
        /// <summary>
        /// Valor
        /// </summary>
        public int Numero { get; set; }
        /// <summary>
        /// Saldo
        /// </summary>
        public double Saldo { get; private set; }
        /// <summary>
        /// CPF do titular
        /// </summary>
        public string ClienteTitular { get; set; }

        /// <summary>
        /// Sacar
        /// </summary>
        /// <param name="valor"></param>
        public virtual void Saca(double valor)
        {
            this.Saldo -= valor;
        }

        /// <summary>
        /// Depositar
        /// </summary>
        /// <param name="valor"></param>
        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }
    }
}
