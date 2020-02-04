using EventoAliExpress.Business.DTO;
using EventoAliExpress.Business.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Interface
{
    public interface IObtenerDatosAliExpress
    {
        List<AliExpressDTO> ObtenerListadoDTO(string file, ILeerArchivoTexto LeerArchivo);

        AliExpressEnum.Paqueteria ObtenerTipoPaqueteria(string paquete);

        AliExpressEnum.Transporte ObtenerTipoTransporte(AliExpressEnum.Paqueteria paqueteria, string transporte);
    }
}
