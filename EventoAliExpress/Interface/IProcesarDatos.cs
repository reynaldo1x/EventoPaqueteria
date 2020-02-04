using EventoAliExpress.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Interface
{
    public interface IProcesarDatos
    {
        TimeSpan ObtenerTiempoTraslado(int iDistancia, int iVelocidad);

        TimeSpan ObtenerFechaEntrega(TimeSpan tsTiempoTranscurriendo, TimeSpan tsTiempoTraslado);

        decimal ObtenerCostoEnvio(decimal dCostoTransporte, int iDistancia, decimal iMargenUtilidad);
    }
}
