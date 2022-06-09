namespace WSTPV.Results
{
    public class DescuentoResult
    {
        public int cliente_id { get; set; }
        public int cantidad { get; set; }
        public bool actualizado { get; set; }
        public bool creado { get; set; }
        public bool borrado { get; set; }
        public string error { get; set; }
    }
}
