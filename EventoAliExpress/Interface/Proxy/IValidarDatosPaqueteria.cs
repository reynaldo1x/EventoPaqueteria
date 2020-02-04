using EventoAliExpress.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Interface.Proxy
{
    public interface IValidarDatosPaqueteria
    {
        /// <summary>
        /// ¿Existe el archivo de rastreo?
        /// </summary>
        /// <returns></returns>
        //bool ValidarArchivoDeRastreo(string path);

        /// <summary>
        /// ¿El tipo de paqueteria es válido?
        /// </summary>
        /// <returns></returns>
        bool ValidarServicioDePaqueteria(AliExpressEnum.Paqueteria paqueteria);

        /// <summary>
        /// ¿El tipo de transporte es válido?
        /// </summary>
        /// <returns></returns>
        bool ValidarServicioTransporte(AliExpressEnum.Transporte transporte);
    }
}
