using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;
namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class MemoriaMaquinaria
    {
        public static IList<Maquinaria> listadeMaquinaria = new List<Maquinaria>();

        // GET: MaquinariaController
        public static IList<Maquinaria> Index()
        {
            if (!listadeMaquinaria.Any())
            {
                Maquinaria maquinaria = new Maquinaria
                {
                    Id = 1,
                    Descripcion = "Chapeadora",
                    Tipo = "Corta Setos",
                    HorasUsoActual = 8,
                    HorasUsoMaximo = 1000,
                    HorasMantenimiento = 100
                };
                listadeMaquinaria.Add(maquinaria);
            }
            return listadeMaquinaria;
        }

        // GET: MaquinariaController/Details/5
        public static Maquinaria SearchOne(int id)
        {
                if (!listadeMaquinaria.Any())
                {
                    throw new ArgumentNullException("En este momento no existe maquinaria");
                   
                }
                Maquinaria MaquinariaALeer = listadeMaquinaria.FirstOrDefault(maquinaria => maquinaria.Id == id);
                if (MaquinariaALeer == null)
                {
                    throw new KeyNotFoundException($"No se encontró maquinaria con el ID {id}.");
                }
                return MaquinariaALeer;
                
        }


        // POST: MaquinariaController/Create
        public static Maquinaria Create(Maquinaria maquinariaNueva)
        {
            try
            {
                if (maquinariaNueva == null)
                {
                    throw new ArgumentNullException(nameof(maquinariaNueva), "La maquinaria no puede ser nula.");
                }
                listadeMaquinaria.Add(maquinariaNueva);
                return (maquinariaNueva);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar la maquinaria a la lista.", ex);
            }
        }


        // POST: MaquinariaController/Edit/5

        public static Maquinaria Edit(Maquinaria MaquinariaEditada)
        {
            try
            {
                if (!listadeMaquinaria.Any())
                {
                    throw new ArgumentNullException("En este momento no existe maquinaria");
                }
                Maquinaria maquinariaAEditar = listadeMaquinaria.FirstOrDefault(maquinaria => maquinaria.Id == MaquinariaEditada.Id);
                maquinariaAEditar.Descripcion = MaquinariaEditada.Descripcion;
                maquinariaAEditar.Tipo = MaquinariaEditada.Tipo;
                maquinariaAEditar.HorasUsoActual = MaquinariaEditada.HorasUsoActual;
                maquinariaAEditar.HorasUsoMaximo = MaquinariaEditada.HorasUsoMaximo;
                maquinariaAEditar.HorasMantenimiento = MaquinariaEditada.HorasMantenimiento;
                return (maquinariaAEditar);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al editar la maquinaria.", ex);
            }
        }


        // POST: MaquinariaController/Delete/5

        public static void Delete(int id)
        {
            try
            {
                Maquinaria EliminarEstaMaquinaria = listadeMaquinaria.FirstOrDefault(maquinaria => maquinaria.Id == id);
                if (EliminarEstaMaquinaria != null)
                {
                    listadeMaquinaria.Remove(EliminarEstaMaquinaria);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar la maquinaria de la lista.", ex);
            }
        }
    }
}
