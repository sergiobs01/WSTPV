using System.ComponentModel.DataAnnotations;

namespace WSTPV.Entities
{
    public class Venta
    {
        [Key]
        public int id { get; set; }
        public string usuario { get; set; }
        public int cliente_id { get; set; }
        public int articulo_id { get; set; }
        public int mesa_id { get; set; }
        public int cantidad { get; set; }
        public string dia_venta { get; set; }
        public string observaciones { get; set; }
    }
}
