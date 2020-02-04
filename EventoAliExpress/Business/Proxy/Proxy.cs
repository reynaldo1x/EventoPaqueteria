using EventoAliExpress.Business.DTO;
using EventoAliExpress.Business.Proxy.Service;
using EventoAliExpress.Interface;
using EventoAliExpress.Interface.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Business.Proxy
{
    public class Proxy : IProxy
    {
        private readonly IAliExpress AliExpress;
        protected readonly IValidarDatosPaqueteria ValidadorDatos;
        private readonly IValidarConexion ValidarConexion;
        private readonly IVisorMensajes _VisualizarMensaje = new VisorMensajesService();
        private readonly IObtenerDatosAliExpress ObtenerDatosAli;
        private string cMensaje = string.Empty;
        private List<AliExpressDTO> lstAliDTO = new List<AliExpressDTO>();
        //Creo desde aca se envia el archivo para que pueda ser procesado

        public Proxy(IAliExpress _AliExpress, IValidarDatosPaqueteria _ValidarDatosPaqueteria, IValidarConexion _ValidarConexion, IObtenerDatosAliExpress _ObtenerDatosAliExpress)
        {
            AliExpress = _AliExpress;
            ValidadorDatos = _ValidarDatosPaqueteria;
            ValidarConexion = _ValidarConexion;
            ObtenerDatosAli = _ObtenerDatosAliExpress;
        }

        public void RastrearPaquete()
        {
            string ruta = AliExpress.ObtenerRuta();

            if (ValidarArchivo(ruta))
            {
                lstAliDTO = ObtenerDatosAli.ObtenerListadoDTO(ruta, new LeerArchivoTexto());

                if (ValidarDatos())
                    AliExpress.RastrearPaquete(lstAliDTO);
            }

            this.VerMensajesDeError();
        }

        private bool ValidarArchivo(string ruta)
        {          
            if (!ValidarConexion.ValidarArchivo(ruta))
            {
                cMensaje = "Archivo no encontrado";
                return false;
            }           

            return true;
        }

        private bool ValidarDatos()
        {
            if(lstAliDTO.Count > 0)
            {
                foreach (var item in lstAliDTO)
                {
                    if (!ValidadorDatos.ValidarServicioDePaqueteria(item.enumPaqueteria))
                    {
                        item.cMensaje = $"La Paqueteria: {item.cPaqueteria} no se encuentra registrada en una red de distribución";
                        continue;
                    }

                    if (!ValidadorDatos.ValidarServicioTransporte(item.enumTransporte))
                    {
                        item.cMensaje = $"{item.cPaqueteria} no ofrece el servicio de transporte {item.cTransporte}, te recomendamos cotizar en otra empresa";
                        continue;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }         
        }

        private void VerMensajesDeError()
        {
            _VisualizarMensaje.MostrarMensaje(cMensaje);
            _VisualizarMensaje.MostrarMensaje(lstAliDTO);          
        }
    }
}
