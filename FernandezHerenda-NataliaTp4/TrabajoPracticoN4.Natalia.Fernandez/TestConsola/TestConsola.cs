using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Excepciones;

namespace TestConsola
{
    class TestConsola
    {
        static void Main(string[] args)
        {
            try
            {
                ///Se Agregan dos productos, se compran y se realiza una venta, se utiliza los dos metodos de mostrar compra y venta 
                ///para mostrarlos en la consola, sino lanza excepcion
                Producto productoUno = new Producto(20, "Rascador para gatos", 20, 200);
                Producto productoDos = new Producto(25, "Palito golosina", 5, 20);
                PetShop.GetInstance().Comprar(productoUno, 3);
                PetShop.GetInstance().Comprar(productoDos, 2);
                PetShop.GetInstance().Vender(productoDos, 2);
                Console.WriteLine("Compras: {0}\n",PetShop.GetInstance().MostrarCompras());
                Console.WriteLine("Ventas: {0}\n" , PetShop.GetInstance().MostrarVentas());
                Console.ReadKey();
                
            }catch(Exception ex)
            {
                throw new PetShopException("No se pudo completar el proceso", ex);
            }
        }
    }
}
