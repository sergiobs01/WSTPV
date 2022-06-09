using System.ComponentModel.DataAnnotations;

namespace WSTPV.Entities
{
    public class Almacen
    {
        [Key]
        public int id { get; set; }
        public string articulo { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public string url { get; set; }
        public string observaciones { get; set; }
    }
}
