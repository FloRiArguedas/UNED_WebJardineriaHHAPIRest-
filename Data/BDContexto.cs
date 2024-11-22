using Microsoft.EntityFrameworkCore;

namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class BDContexto: DbContext //Heredo de DB context todas las capacidades.
    {
        public BDContexto(DbContextOptions<BDContexto> opciones) : base(opciones)
        {
              
        }
        public DbSet<Models.Cliente> Cliente { get; set; }
        public DbSet<Models.Empleado> Empleado { get; set; }

        public DbSet<Models.Maquinaria> Maquinaria { get; set; }

        public DbSet<Models.Mantenimiento> Mantenimiento { get; set; }
    }
}
