using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSTPV.Entities
{
    public class Logins
    {
        [Key]
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string nombre { get; set; }
        public string ultimo_login { get; set; }
    }
}
