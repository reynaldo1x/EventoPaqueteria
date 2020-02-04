using EventoAliExpress.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Business
{
    public class ProcesarDatosService : IProcesarDatos
    {
        public TimeSpan ObtenerTiempoTraslado(int iDistancia, int iVelocidad)
        {
            TimeSpan time = new TimeSpan(iDistancia / iVelocidad, 0, 0);
            return time;
        }

        public TimeSpan ObtenerFechaEntrega(TimeSpan tsTiempoTranscurriendo, TimeSpan tsTiempoTraslado)
        {          
            return tsTiempoTranscurriendo.Add(tsTiempoTraslado);
        }

        public decimal ObtenerCostoEnvio(decimal dCostoTransporte, int iDistancia, decimal iMargenUtilidad)
        {
            decimal dCostoEnvio = 0;

            dCostoEnvio = (dCostoTransporte * iDistancia) * (1 + iMargenUtilidad / 100);

            return dCostoEnvio;
        }
    }
}
