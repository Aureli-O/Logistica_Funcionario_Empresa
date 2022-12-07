using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica_Empresa
{
    internal class HorasInvalidas : Exception 
    {

        public HorasInvalidas(string mensagem):base(mensagem)
        {

        }

    }
}
