namespace WSTPV.Results
{
    public class VentaResult
    {
        public string usuario { get; set; }
        public int cliente_id { get; set; }
        public int articulo_id { get; set; }
        public int mesa_id { get; set; }
        public int cantidad { get; set; }
        public string dia_venta { get; set; }
        public string observaciones { get; set; }
        public bool actualizado { get; set; }
        public bool creado { get; set; }
        public bool borrado { get; set; }
        public string error { get; set; }
    }
}
