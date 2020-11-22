using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Archivos_e_Interfaz
{
    /// <summary>
    /// Interfaz para implementar en PetShop Compra y Venta
    /// </summary>
    public interface IArchivos
    {
        string Texto 
        { 
            get; 
        }
        string Ruta
        {
            get;
        }
    }
}
