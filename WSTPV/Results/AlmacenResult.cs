namespace WSTPV.Results
{
    public class AlmacenResult
    {
        public string articulo { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public string url { get; set; }
        public string observaciones { get; set; }
        public bool actualizado { get; set; }
        public bool creado { get; set; }
        public bool borrado { get; set; }
        public string error { get; set; }
    }
}
