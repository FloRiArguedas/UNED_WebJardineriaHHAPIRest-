namespace P2_FloricelaArguedas_WebApplication.Models
{
    public class Maquinaria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public string Tipo { get; set; }

        public int HorasUsoActual { get; set; }

        public int HorasUsoMaximo { get; set; }

        public int HorasMantenimiento { get; set; }
    }
}
