namespace P2_FloricelaArguedas_WebApplication.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Provincia { get; set; }

        public string Canton { get; set; }

        public string Distrito { get; set; }

        public string DireccionExacta { get; set; }

        public string MantenimientoInvierno { get; set; }

        public string MantenimientoVerano { get; set; }
    }
}
