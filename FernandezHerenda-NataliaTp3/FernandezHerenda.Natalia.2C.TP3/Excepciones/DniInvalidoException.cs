﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            : this("El DNI no es válido")
        {
        }

        public DniInvalidoException(string message)
            : base(message)
        {
        }
    }
}
