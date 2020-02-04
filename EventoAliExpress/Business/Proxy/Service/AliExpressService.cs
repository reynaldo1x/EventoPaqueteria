using EventoAliExpress.Business.DTO;
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
    public class AliExpressService : IAliExpress
    {
        private readonly IVisorMensajes VisorMensaje;
        private readonly IProcesarDatos ProcesarDatos;
        private string pathFile = string.Empty;        

        public AliExpressService(string _path, IVisorMensajes _VisorMensaje, IProcesarDatos _ProcesarDatos)
        {
            pathFile = _path;
            VisorMensaje = _VisorMensaje;
            ProcesarDatos = _ProcesarDatos;
        }

        public void RastrearPaquete(List<AliExpressDTO> lstAliDTO)
        {
            List<AliExpressDTO> lstNueva = new List<AliExpressDTO>();

            lstNueva = (from m in lstAliDTO.Where(e => string.IsNullOrEmpty(e.cMensaje))
                         select m).ToList();

            for (int i = 0; i < lstNueva.Count; i++)
            {
                lstNueva[i] = this.EstablecerCostos(lstNueva[i]);
                this.MostrarMensaje(lstNueva[i]);
            }

        }

        public string ObtenerRuta()
        {
            return pathFile;
        }

        private AliExpressDTO EstablecerCostos(AliExpressDTO _Ali)
        {
            TimeSpan tsTiempoTraslado;
            TimeSpan tsTiempoTranscurriendo = _Ali.dtFechaHoraPedido - DateTime.Now;

            tsTiempoTraslado = ProcesarDatos.ObtenerTiempoTraslado(_Ali.iDistancia, _Ali.iVelocidadKm);
            _Ali.tsFechaEntrega = ProcesarDatos.ObtenerFechaEntrega(tsTiempoTranscurriendo, tsTiempoTraslado);
            _Ali.dCostoEnvio = ProcesarDatos.ObtenerCostoEnvio(_Ali.dCostoKm, _Ali.iDistancia, _Ali.iMargenUtilidad);

            return _Ali;
        }

        private void MostrarMensaje(AliExpressDTO _Ali)
        {
            int days = (int)_Ali.tsFechaEntrega.Days;
            int mins = (int)_Ali.tsFechaEntrega.Minutes;

            if (days > 30)
                VisorMensaje.MostrarMensaje($"Tu paquete salió  de {_Ali.cOrigen} y llegará a {_Ali.cDestino} dentro de {days / 30} meses");

            if(days > 1 && days <= 30)
                VisorMensaje.MostrarMensaje($"Tu paquete salió  de {_Ali.cOrigen} y llegará a {_Ali.cDestino} dentro de {days} días");

            if (days == 0 && mins > 59)
                VisorMensaje.MostrarMensaje($"Tu paquete salió  de {_Ali.cOrigen} y llegará a {_Ali.cDestino} dentro de {mins / 59} horas");

            if (days == 0 && mins > 0  && mins < 59)
                VisorMensaje.MostrarMensaje($"Tu paquete salió  de {_Ali.cOrigen} y llegará a {_Ali.cDestino} dentro de {mins} minutos");

            /*  */
            if (days < 0 && Math.Abs(days) > 30)
                VisorMensaje.MostrarMensaje($"Tu paquete salió  de {_Ali.cOrigen} y debió llegar a {_Ali.cDestino} hace {Math.Abs(days) / 30} meses");

            if (days < 0 && Math.Abs(days) <= 30)
                VisorMensaje.MostrarMensaje($"Tu paquete salió  de {_Ali.cOrigen} y debió llegar a {_Ali.cDestino} hace {Math.Abs(days)} días");

            if (days == 0 && Math.Abs(mins) > 59)
                VisorMensaje.MostrarMensaje($"Tu paquete salió  de {_Ali.cOrigen} y debió llegar a {_Ali.cDestino} dentro de {Math.Abs(mins) / 59} horas");

            if (days == 0 && Math.Abs(mins) < 59)
                VisorMensaje.MostrarMensaje($"Tu paquete salió  de {_Ali.cOrigen} y debió llegar a {_Ali.cDestino} dentro de {Math.Abs(mins)} minutos");
        }
    }
}
