using Aula.Lib.Aula02.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.Lib.Aula03.Interfaces
{
    public interface ICliente
    {
        ClienteDB CarregaCliente(int CodigoCliente);


    }
}
