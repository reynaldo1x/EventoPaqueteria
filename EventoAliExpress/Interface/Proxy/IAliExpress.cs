using EventoAliExpress.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Interface.Proxy
{
    public interface IAliExpress
    {
        void RastrearPaquete(List<AliExpressDTO> lstAliDTO);

        string ObtenerRuta();
    }
}
