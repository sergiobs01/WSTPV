using System.ComponentModel.DataAnnotations;

namespace WSTPV.Entities
{
    public class Mesas
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
