using System;
using Entidades;
using Entidades.Datos;
using Entidades.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        public void TestDePruebaDeSingleton()
        {
            //arrange
            PetShop petShop;

            petShop = PetShop.GetInstance();

            //assert
            Assert.IsTrue(petShop == PetShop.GetInstance());
        }

        [TestMethod]
        public void TestPruebaCompraProducto()
        {
            //arrange
            Producto producto = new Producto();
            PetShop petShop = PetShop.GetInstance();

            //act
            Compra compra = petShop.Comprar(producto, 20);

            //assert
            Assert.IsTrue(petShop.Compras.Contains(compra));
        }

        [TestMethod]
        public void TestPruebaVentaProducto()
        {
            //arrange
            Producto producto = new Producto();
            PetShop petShop = PetShop.GetInstance();

            //act
            Venta venta = petShop.Vender(producto, 20);

            //assert
            Assert.IsTrue(petShop.Ventas.Contains(venta));
        }
    }
}
