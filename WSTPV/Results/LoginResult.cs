using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSTPV.Results
{
    public class LoginResult
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public bool logeado { get; set; }
        public bool actualizado { get; set; }
        public bool creado { get; set; }
        public bool borrado { get; set; }
        public string error { get; set; }
    }
}
