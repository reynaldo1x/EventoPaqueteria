using EventoAliExpress.Business;
using EventoAliExpress.Business.Proxy;
using EventoAliExpress.Business.Proxy.Service;
using EventoAliExpress.Interface.Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventoAliExpress
{
    public class Program
    {

        public static void Main(string[] args)
        {           
            Console.WriteLine("Nombre del archivo de texto: ");
            string fileName = Console.ReadLine();
            string pathFile = Path.Combine(Environment.CurrentDirectory, string.Concat(fileName,".txt"));

            AliExpressService AliExpress = new AliExpressService(pathFile, new VisorMensajesService(), new ProcesarDatosService());
            IProxy proxy = new Proxy(AliExpress, new ValidadorDatosPaqueteriaService(), new ValidarConexion(), new ObtenerDatosAliExpress());

            proxy.RastrearPaquete();

            Console.ReadLine();
        }
    }
}
