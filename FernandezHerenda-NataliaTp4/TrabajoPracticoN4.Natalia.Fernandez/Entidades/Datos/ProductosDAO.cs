using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Datos.EnumeradoBaseDeDatos;

namespace Entidades.Datos
{
    /// <summary>
    /// BASE DE DATOS
    /// </summary>
      public class ProductosDAO : ConexionABaseDeDatos
       {
            public delegate void ProductoDBDelegate(ComandoBaseDeDatos accion);
            public static event ProductoDBDelegate CambiosAProductos;

            /// <summary>
            /// Metodo donde se inserta un producto en la lista de productos de la base de datos
            /// </summary>
            /// <param name="descripcion"></param>
            /// <param name="precio"></param>
            /// <param name="stock"></param>
            public static void Insert(string descripcion, double precio, int stock)
            {
                ProductosDAO.Comando.CommandText = "INSERT INTO dbo.Productos (Descripcion, Precio, Stock) VALUES (@Descripcion, @Precio, @Stock);";
                ProductosDAO.Comando.Parameters.Clear();
                ProductosDAO.Comando.Parameters.AddWithValue("@Descripcion", descripcion);
                ProductosDAO.Comando.Parameters.AddWithValue("@Precio", precio);
                ProductosDAO.Comando.Parameters.AddWithValue("@Stock", stock);
                ProductosDAO.Ejecutar();
                CambiosAProductos.Invoke(ComandoBaseDeDatos.Insert);
            }
            /// <summary>
            /// Metodo donde se modifica un producto en la lista de productos de la base de datos
            /// </summary>
            /// <param name="descripcion"></param>
            /// <param name="precio"></param>
            /// <param name="stock"></param>
            public static void Update(int codigo, double nuevoPrecio, int stock)
            {
                ProductosDAO.Comando.CommandText = "UPDATE dbo.Productos SET Precio = @nuevoPrecio, Stock = @nuevoStock WHERE Codigo = @Codigo";
                ProductosDAO.Comando.Parameters.Clear();
                ProductosDAO.Comando.Parameters.AddWithValue("@nuevoPrecio", nuevoPrecio);
                ProductosDAO.Comando.Parameters.AddWithValue("@nuevoStock", stock);
                ProductosDAO.Comando.Parameters.AddWithValue("@Codigo", codigo);
                ProductosDAO.Ejecutar();
                CambiosAProductos.Invoke(ComandoBaseDeDatos.Insert);
            }

            /// <summary>
            /// Metodo donde se borra un producto en la lista de productos de la base de datos
            /// </summary>
            /// <param name="descripcion"></param>
            /// <param name="precio"></param>
            /// <param name="stock"></param>
            public static void Delete(int codigo)
                {
                    ProductosDAO.Comando.CommandText = "DELETE FROM dbo.Productos WHERE Codigo = @Codigo";
                    ProductosDAO.Comando.Parameters.Clear();
                    ProductosDAO.Comando.Parameters.AddWithValue("@Codigo", codigo);
                    ProductosDAO.Ejecutar();
                    CambiosAProductos.Invoke(ComandoBaseDeDatos.Insert);
            }
            /// <summary>
            /// Selecciona toda la lista de productos en la base de datos
            /// </summary>
            /// <returns></returns>
            public static List<Producto> SelectAll()
            {
                List<Producto> productosList = new List<Producto>();

                try
                {
                    ProductosDAO.Comando.CommandText = "SELECT * FROM dbo.Productos";

                    ProductosDAO.Conexion.Open();
                    SqlDataReader sqlReader = ProductosDAO.Comando.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        int codigo = Convert.ToInt32(sqlReader["Codigo"]);
                        string descripcion = sqlReader["Descripcion"].ToString();
                        double precio = Convert.ToDouble(sqlReader["Precio"]);
                        int stock = Convert.ToInt32(sqlReader["Stock"]);
                        Producto producto = new Producto(codigo, descripcion, stock, precio);
                        productosList.Add(producto);
                    }
                }
                catch (Exception ex)
                {
                    throw new PetShopException("Error al tratar de obtener los productos de la base de datos", ex);
                }
                finally
                {
                    if (ProductosDAO.Conexion.State == System.Data.ConnectionState.Open)
                    {
                        ProductosDAO.Conexion.Close();
                    }
                }
                return productosList;
            }
      }
    
}
