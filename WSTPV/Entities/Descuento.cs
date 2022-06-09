using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSTPV.Entities
{
    public class Descuento
    {
        [Key]
        public int id { get; set; }
        public int cliente_id { get; set; }
        public int cantidad { get; set; }
    }
}
