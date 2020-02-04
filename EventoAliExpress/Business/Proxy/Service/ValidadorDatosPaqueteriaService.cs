using EventoAliExpress.Business.Enum;
using EventoAliExpress.Interface;
using EventoAliExpress.Interface.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Business.Proxy.Service
{
    public class ValidadorDatosPaqueteriaService : IValidarDatosPaqueteria
    {

        public bool ValidarServicioDePaqueteria(AliExpressEnum.Paqueteria paqueteria)
        {
            return paqueteria != AliExpressEnum.Paqueteria.None ? true : false;
        }

        public bool ValidarServicioTransporte(AliExpressEnum.Transporte transporte)
        {
            return transporte != AliExpressEnum.Transporte.None ? true : false;
        }

    }
}
