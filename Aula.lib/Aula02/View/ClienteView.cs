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

        /// <summary>
        /// Formatação de CPF no padrão ###.###.###-##
        /// </summary>
        public string CPFFormatado
        {
            //Fonte: https://www.codigoexpresso.com.br/Home/Postagem/28
            set
            {
                CPF = Convert.ToUInt64(value).ToString(@"000\.000\.000\-00");
            }
        }
    }
}
