using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Archivos_e_Interfaz
{
    public class Archivos
    {
        /// <summary>
        /// Metodo que se utiliza para escribir el archivo
        /// </summary>
        /// <param name="objeto"></param>
        /// <param name="append"></param>
        public static void Escribir(IArchivos objeto, bool append)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(objeto.Ruta, append, Encoding.UTF8);
                sw.Write(objeto.Texto);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
        /// <summary>
        /// Metodo que se utiliza para leer el archivo
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static string Leer(string ruta)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(ruta);
                return sr.ReadToEnd();
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }
    }
}
