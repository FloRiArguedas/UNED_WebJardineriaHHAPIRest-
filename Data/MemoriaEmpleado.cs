using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;

namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class MemoriaEmpleado
    {
        public static IList<Empleado> ListadeEmpleados = new List<Empleado>();


        // GET: EmpleadoController
        public static IList<Empleado> Index()
        {
            if (!ListadeEmpleados.Any())
            {
                Empleado empleado = new Empleado()
                {
                    Cedula = 115420652,
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
        public static Empleado SearchOne(int cedula)
        {
            try
            {
                if (ListadeEmpleados.Any())
                {
                    Empleado EmpleadoEncontrado = ListadeEmpleados.FirstOrDefault(empleado => empleado.Cedula == cedula);
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

        public static Empleado Create(Empleado EmpleadoNuevo)
        {
            try
            {
                if (EmpleadoNuevo == null)
                {
                    return null;
                }
                ListadeEmpleados.Add(EmpleadoNuevo);
                return (EmpleadoNuevo);
            }
            catch
            {
                return null;
            }
        }


        // POST: EmpleadoController/Editar UPDATE

        public static Empleado Editar(Empleado EmpleadoActualizado)
        {
            try
            {
                if (ListadeEmpleados.Any())
                {
                    Empleado EmpleadoAEditar = ListadeEmpleados.FirstOrDefault(empleado => empleado.Cedula == EmpleadoActualizado.Cedula);
                    EmpleadoAEditar.FechaNacimiento = EmpleadoActualizado.FechaNacimiento;
                    EmpleadoAEditar.Lateralidad = EmpleadoActualizado.Lateralidad;
                    EmpleadoAEditar.FechaIngreso = EmpleadoActualizado.FechaIngreso;
                    EmpleadoAEditar.SalarioxHora = EmpleadoActualizado.SalarioxHora;
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
        public static void Delete(int id)
        {
            try
            {
                Empleado EliminarEsteEmpleado = ListadeEmpleados.FirstOrDefault(empleado => empleado.Cedula == id);

                if (EliminarEsteEmpleado != null)
                {
                    ListadeEmpleados.Remove(EliminarEsteEmpleado);
                }

            }
            catch
            {
                return;
            }
        }
    }
}

