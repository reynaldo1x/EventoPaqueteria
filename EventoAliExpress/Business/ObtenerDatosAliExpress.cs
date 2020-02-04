using EventoAliExpress.Business.DTO;
using EventoAliExpress.Business.Enum;
using EventoAliExpress.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventoAliExpress.Business.Enum.AliExpressEnum;

namespace EventoAliExpress.Business
{
    public class ObtenerDatosAliExpress : IObtenerDatosAliExpress
    {
        public List<AliExpressDTO> ObtenerListadoDTO(string file, ILeerArchivoTexto LeerArchivo)
        {
            List<AliExpressDTO> lstData = new List<AliExpressDTO>();
            AliExpressDTO AliData;
            string[] data = LeerArchivo.ObtenerDatos(file);

            foreach (var item in data)
            {
                AliData = new AliExpressDTO();
                try
                {
                    AliData.cOrigen = item.Split(',')[0];
                    AliData.cDestino = item.Split(',')[1];
                    AliData.iDistancia = int.Parse(item.Split(',')[2]);
                    AliData.cPaqueteria = item.Split(',')[3];
                    AliData.enumPaqueteria = ObtenerTipoPaqueteria(item.Split(',')[3]);
                    AliData.cTransporte = item.Split(',')[4];
                    AliData.enumTransporte = ObtenerTipoTransporte(AliData.enumPaqueteria, item.Split(',')[4]);
                    AliData.dtFechaHoraPedido = Convert.ToDateTime(item.Split(',')[5]);
                    AliData.iVelocidadKm = ObtenerVelocidadTransporte(AliData.enumTransporte);
                    AliData.dCostoKm = ObtenerCostoKmTransporte(AliData.enumTransporte);
                    AliData.iMargenUtilidad = ObtenerMargenUtilidad(AliData.enumPaqueteria);
                }
                catch (Exception)
                {
                    AliData = new AliExpressDTO();
                    throw;
                }

                lstData.Add(AliData);
            }

            return lstData;
        }

        public Paqueteria ObtenerTipoPaqueteria(string paquete)
        {
            Paqueteria paq;
            switch (paquete.ToUpper())
            {
                case "FEDEX":
                    paq = Paqueteria.Fedex;
                    break;
                case "ESTAFETA":
                    paq = Paqueteria.Estafeta;
                    break;
                case "DHL":
                    paq = Paqueteria.DHL;
                    break;
                default:
                    paq = Paqueteria.None;
                    break;
            }

            return paq;
        }

        public Transporte ObtenerTipoTransporte(Paqueteria paqueteria, string transporte)
        {
            Transporte paq;
            switch (transporte.ToUpper())
            {
                case "BARCO":
                    paq = ObtenerTransportePaqueteria(paqueteria, Transporte.Barco);
                    break;
                case "TREN":
                    paq = ObtenerTransportePaqueteria(paqueteria, Transporte.Tren);
                    break;
                case "AVION":
                    paq = ObtenerTransportePaqueteria(paqueteria, Transporte.Avion);
                    break;
                default:
                    paq = Transporte.None;
                    break;
            }

            return paq;
        }

        private Transporte ObtenerTransportePaqueteria(Paqueteria paqueteria, Transporte transporte)
        {
            Transporte paq;

            switch (paqueteria)
            {
                case Paqueteria.Fedex:
                    paq = transporte == Transporte.Barco ? transporte : Transporte.None;
                    break;
                case Paqueteria.DHL:
                    paq = (transporte == Transporte.Barco) ? transporte : (transporte == Transporte.Avion) ? transporte : Transporte.None;
                    break;
                case Paqueteria.Estafeta:
                    paq = transporte == Transporte.Tren ? transporte : Transporte.None;
                    break;
                default:
                    paq = Transporte.None;
                    break;
            }

            return paq;
        }

        private int ObtenerVelocidadTransporte(Transporte transporte)
        {
            int iVelocidad = 0;

            switch (transporte)
            {
                case Transporte.Avion:
                    iVelocidad = 600;
                    break;
                case Transporte.Tren:
                    iVelocidad = 80;
                    break;
                case Transporte.Barco:
                    iVelocidad = 46;
                    break;
                default:
                    iVelocidad = 0;
                    break;
            }

            return iVelocidad;
        }

        private decimal ObtenerCostoKmTransporte(Transporte transporte)
        {
            decimal dCosto = 0;

            switch (transporte)
            {
                case Transporte.Avion:
                    dCosto = 10;
                    break;
                case Transporte.Tren:
                    dCosto = 5;
                    break;
                case Transporte.Barco:
                    dCosto = 1;
                    break;
                default:
                    dCosto = 0;
                    break;
            }

            return dCosto;
        }

        private decimal ObtenerMargenUtilidad(Paqueteria paqueteria)
        {
            decimal iMargenUtilidad = 0;

            switch (paqueteria)
            {
                case Paqueteria.Fedex:
                    iMargenUtilidad = 1.5M;
                    break;
                case Paqueteria.DHL:
                    iMargenUtilidad = 1.4M;
                    break;
                case Paqueteria.Estafeta:
                    iMargenUtilidad = 1.2M;
                    break;
            }

            return iMargenUtilidad;
        }
    }
}
