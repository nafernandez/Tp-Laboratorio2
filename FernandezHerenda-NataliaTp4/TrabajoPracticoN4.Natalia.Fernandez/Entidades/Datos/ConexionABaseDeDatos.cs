using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Datos
{
    public class ConexionABaseDeDatos
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        /// <summary>
        /// Constructos statico donde se iniciliza los atributos estaticos
        /// </summary>
        static ConexionABaseDeDatos()
        {
            ConexionABaseDeDatos.conexion = new SqlConnection("Server=.\\SQLEXPRESS;Database=PetShop;Trusted_Connection=True;");
            ConexionABaseDeDatos.comando = new SqlCommand();
            ConexionABaseDeDatos.comando.Connection = ConexionABaseDeDatos.conexion;
        }
        /// <summary>
        /// Propiedad de lectura de Conexion
        /// </summary>
        protected static SqlConnection Conexion
        {
            get
            {
                return ConexionABaseDeDatos.conexion;
            }
        }
        /// <summary>
        /// Propiedad de solo lectura de comando
        /// </summary>
        protected static SqlCommand Comando
        {
            get
            {
                return ConexionABaseDeDatos.comando;
            }
        }
        /// <summary>
        /// Metodo para ejecutar la base de datos
        /// </summary>
        protected static void Ejecutar()
        {
            try
            {
                ConexionABaseDeDatos.Conexion.Open();
                ConexionABaseDeDatos.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               throw new PetShopException("Ocurrió un error en la base de datos.", ex);
            }
            finally
            {
                if (ConexionABaseDeDatos.Conexion.State == System.Data.ConnectionState.Open)
                {
                    ConexionABaseDeDatos.Conexion.Close();
                }
            }
        }
    }
}
