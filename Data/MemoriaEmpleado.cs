using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;

namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class MemoriaEmpleado
    {
       private BDContexto ContextoBaseDatos;

        public MemoriaEmpleado(BDContexto ctxt)
        {
            ContextoBaseDatos = ctxt ?? throw new ArgumentNullException(nameof(ctxt));
        }

        //Obtengo la lista de la base de datos

        public IList<Empleado> ObtenerLista()
        {
            var listaLeida = from c in ContextoBaseDatos.Empleado select c;
            return listaLeida.ToList();
        }

        // GET: EmpleadoController
        public IList<Empleado> Index()
        {
            IList<Empleado> ListadeEmpleados = ObtenerLista();

            if (!ListadeEmpleados.Any())
            {
                Empleado empleado = new Empleado()
                {
                    Id = 115420652,
                    FechaNacimiento = new DateTime(1993, 07, 10),
                    Lateralidad = "Zurdo",
                    FechaIngreso = new DateTime(2015, 03, 23),
                    SalarioxHora = 1900
                };
                ListadeEmpleados.Add(empleado);
            }
            return ListadeEmpleados;
        }

        // GET: EmpleadoController/Detalles (LEER)
        public Empleado SearchOne(int Id)
        {
            try
            {
                IList<Empleado> ListadeEmpleados = ObtenerLista();
                if (ListadeEmpleados.Any())
                {
                    Empleado EmpleadoEncontrado = ListadeEmpleados.FirstOrDefault(empleado => empleado.Id == Id);
                    if (EmpleadoEncontrado != null) 
                    {
                        return EmpleadoEncontrado;
                    }
                    
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        // POST: EmpleadoController/Create

        public Empleado Create(Empleado EmpleadoNuevo)
        {
            try
            {
                IList<Empleado> ListadeEmpleados = ObtenerLista();
                if (EmpleadoNuevo == null)
                {
                    return null;
                }
                ContextoBaseDatos.Empleado.Add(EmpleadoNuevo);
                ContextoBaseDatos.SaveChanges();
                return (EmpleadoNuevo);
            }
            catch
            {
                return null;
            }
        }


        // POST: EmpleadoController/Editar UPDATE

        public Empleado Editar(Empleado EmpleadoActualizado)
        {
            try
            {
                IList<Empleado> ListadeEmpleados = ObtenerLista();
                if (ListadeEmpleados.Any())
                {
                    Empleado EmpleadoAEditar = ListadeEmpleados.FirstOrDefault(empleado => empleado.Id == EmpleadoActualizado.Id);
                    EmpleadoAEditar.FechaNacimiento = EmpleadoActualizado.FechaNacimiento;
                    EmpleadoAEditar.Lateralidad = EmpleadoActualizado.Lateralidad;
                    EmpleadoAEditar.FechaIngreso = EmpleadoActualizado.FechaIngreso;
                    EmpleadoAEditar.SalarioxHora = EmpleadoActualizado.SalarioxHora;

                    ContextoBaseDatos.Empleado.Update(EmpleadoAEditar);
                    ContextoBaseDatos.SaveChanges();

                    return EmpleadoAEditar;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        // POST: EmpleadoController/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            try
            {
                IList<Empleado> ListadeEmpleados = ObtenerLista();
                Empleado EliminarEsteEmpleado = ListadeEmpleados.FirstOrDefault(empleado => empleado.Id == id);

                if (EliminarEsteEmpleado != null)
                {
                    ContextoBaseDatos.Empleado.Remove(EliminarEsteEmpleado);
                    ContextoBaseDatos.SaveChanges();
                }

            }
            catch
            {
                return;
            }
        }
    }
}

