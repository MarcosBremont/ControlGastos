using System;
using System.Collections.Generic;
using System.Text;

namespace ControlGastos.Modelo.Entidades
{
    public class EUsuario
    {
        public string nombre { get; set; }
        public string clave { get; set; }
        public string tokens { get; set; }
        public string respuesta { get; set; }
        public string nombrepersonaentrante { get; set; }
        public int idControlGastosAppTokens { get; set; }
        public string result { get; set; }
        public string emoji { get; set; }
    }
}
