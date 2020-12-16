using Aula.Lib.Aula02.Models_DB;
using System;

namespace Aula.Lib.Aula02.View
{
    /// <summary>
    /// Classe para representar a view do cliente, herdando de ClienteDB
    /// </summary>
    public class ClienteView : ClienteDB
    {
        /// <summary>
        /// Validação de CPF
        /// </summary>
        public bool CPFValido
        {
            get
            {
                return Exemplo02.VerificarCPF(CPF);
            }
        }

    }
}
