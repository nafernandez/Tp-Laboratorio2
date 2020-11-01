using System;
using System.Collections.Generic;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TestsTp3
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoEnUniversidadLanzaExcepcion()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno();

            _ = universidad + alumno;
            _ = universidad + alumno;

        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Alumno alumno = new Alumno(21, "Natalia", "Fernandez", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        public void TestListaAlumnosInstanciadaEnUniversidad()
        {
            //Arrange
            Universidad universidad;
            //Act
            universidad = new Universidad();
            //Assert
            Assert.IsInstanceOfType(universidad.Alumnos, typeof(List<Alumno>));
        }
    }
}
