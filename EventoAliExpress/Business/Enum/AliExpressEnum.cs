using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Business.Enum
{
    public class AliExpressEnum
    {
        public enum Paqueteria
        {
            None,
            Fedex,
            DHL,
            Estafeta
        }

        public enum Transporte
        {
            None,
            Barco,
            Tren,
            Avion           
        }
    }
}
