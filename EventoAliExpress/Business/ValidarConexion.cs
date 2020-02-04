using EventoAliExpress.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Business
{
    public class ValidarConexion : IValidarConexion
    {
        public bool ValidarArchivo(string path)
        {
            bool lExisteArchivo = false;
            try
            {
                if (System.IO.File.Exists(path))
                    lExisteArchivo = true;
            }
            catch (Exception)
            {
            }

            return lExisteArchivo;
        }
    }
}
