using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula02.OOP___Herança
{
    class ContaPoupanca : Conta
    {
        public override void Saca(double valor)
        {
            //SE USAR AQUI PRECISA MUDAR A PROPRIEDADE DE SALDO DE PRIVATE PARA PROTECTED
            //this.Saldo -= (valor + 0.10);
            base.Saca(valor + 0.10);
        }
    }
}
