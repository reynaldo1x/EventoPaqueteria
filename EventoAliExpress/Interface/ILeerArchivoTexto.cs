using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress.Interface
{
    public interface ILeerArchivoTexto
    {
        string[] ObtenerDatos(string path);
    }
}
