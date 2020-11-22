using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    /// <summary>
    /// EXCEPCIONES
    /// </summary>
    public class PetShopException : Exception
    {
        public PetShopException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
