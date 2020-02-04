using EventoAliExpress.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Business
{
    public class LeerArchivoTexto : ILeerArchivoTexto
    {
        public string[] ObtenerDatos(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            return lines;
        }
    }
}
