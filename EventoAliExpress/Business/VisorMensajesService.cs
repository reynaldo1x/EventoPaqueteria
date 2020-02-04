using EventoAliExpress.Business.DTO;
using EventoAliExpress.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Business
{
    public class VisorMensajesService : IVisorMensajes
    {
        public void MostrarMensaje(string Mensaje)
        {

            //Console.ForegroundColor = ConsoleColor.Red;
            if (!string.IsNullOrEmpty(Mensaje))
            {               
                Console.WriteLine(Mensaje);
            }

        }

        public void MostrarMensaje(List<AliExpressDTO> _lstAliExpress)
        {
            List<string> cMensajes = new List<string>();

            cMensajes = (from m in _lstAliExpress.Where(e => e.cMensaje != string.Empty)
                         select m.cMensaje).ToList();

            if(cMensajes.Count > 0)
            {
                for (int i = 0; i < cMensajes.Count; i++)
                {
                    Console.WriteLine(cMensajes[i]);
                }
            }
        }
    }
}
