using EventoAliExpress.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Business.DTO
{
    public class AliExpressDTO
    {
        public string cOrigen { get; set; }
        public string cDestino { get; set; }

        public int iDistancia { get; set; }

        public string cPaqueteria { get; set; }
        public AliExpressEnum.Paqueteria enumPaqueteria { get; set; }

        //public int MyProperty { get; set; }

        public string cTransporte { get; set; }

        public AliExpressEnum.Transporte enumTransporte { get; set; }

        public decimal dCostoKm { get; set; }

        public int iVelocidadKm { get; set; }

        public decimal iMargenUtilidad { get; set; }

        public DateTime dtFechaHoraPedido { get; set; }

        public string cMensaje { get; set; }

        public TimeSpan tsFechaEntrega { get; set; }

        public decimal dCostoEnvio { get; set; }
    }
}
