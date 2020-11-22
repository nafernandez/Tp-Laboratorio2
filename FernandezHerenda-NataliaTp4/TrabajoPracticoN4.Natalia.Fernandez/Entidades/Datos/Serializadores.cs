using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.Datos
{
    public class Serializadores<T>
        where T : class, new()
    {
        /// <summary>
        /// Serializa un objeto a formato XML.
        /// </summary>
        /// <param name="objeto">Objeto a serializar.</param>
        /// <param name="ruta">Ruta donde se creará el archivo de serialización.</param>
        public static void SerializarAXml(T objeto, string ruta)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(ruta, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objeto);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Deserializa el archivo en la ruta indicada de XML al tipo genérico T.
        /// </summary>
        /// <param name="ruta">Ruta del archivo a deserializar.</param>
        /// <returns></returns>
        public static T DeserializarXml(string ruta)
        {
            XmlTextReader reader = null;
            T objeto = default(T);
            try
            {
                reader = new XmlTextReader(ruta);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                objeto = (T)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                throw new PetShopException("Ocurrió un error al tratar de deserializar el archivo XML.", ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return objeto;
        }
    }
}
