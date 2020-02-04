using EventoAliExpress.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Interface
{
    public interface IVisorMensajes
    {
        void MostrarMensaje(string Mensaje);

        void MostrarMensaje(List<AliExpressDTO> _lstAli);
    }
}
