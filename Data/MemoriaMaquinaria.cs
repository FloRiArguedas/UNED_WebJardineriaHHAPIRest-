using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;
namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class MemoriaMaquinaria
    {
        private BDContexto ContextoBaseDatos;

        public MemoriaMaquinaria(BDContexto ctxt)
        {
            ContextoBaseDatos = ctxt ?? throw new ArgumentNullException(nameof(ctxt));
        }

        public IList<Maquinaria> ObtenerLista()
        {
            var listaLeida = from c in ContextoBaseDatos.Maquinaria select c;
            return listaLeida.ToList();
        }

        // GET: MaquinariaController
        public IList<Maquinaria> Index()
        {
            IList<Maquinaria> listadeMaquinaria = ObtenerLista();
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
        public Maquinaria SearchOne(int id)
        {
            IList<Maquinaria> listadeMaquinaria = ObtenerLista();
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
        public Maquinaria Create(Maquinaria maquinariaNueva)
        {
            try
            {
                IList<Maquinaria> listadeMaquinaria = ObtenerLista();
                if (maquinariaNueva == null)
                {
                    throw new ArgumentNullException(nameof(maquinariaNueva), "La maquinaria no puede ser nula.");
                }

                ContextoBaseDatos.Add(maquinariaNueva);
                ContextoBaseDatos.SaveChanges();

                return (maquinariaNueva);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar la maquinaria a la lista.", ex);
            }
        }


        // POST: MaquinariaController/Edit/5

        public Maquinaria Edit(Maquinaria MaquinariaEditada)
        {
            try
            {
                IList<Maquinaria> listadeMaquinaria = ObtenerLista();
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

                ContextoBaseDatos.Update(maquinariaAEditar);
                ContextoBaseDatos.SaveChanges();

                return (maquinariaAEditar);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al editar la maquinaria.", ex);
            }
        }


        // POST: MaquinariaController/Delete/5

        public void Delete(int id)
        {
            try
            {
                IList<Maquinaria> listadeMaquinaria = ObtenerLista();
                Maquinaria EliminarEstaMaquinaria = listadeMaquinaria.FirstOrDefault(maquinaria => maquinaria.Id == id);
                if (EliminarEstaMaquinaria != null)
                {
                    ContextoBaseDatos.Remove(EliminarEstaMaquinaria);
                    ContextoBaseDatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar la maquinaria de la lista.", ex);
            }
        }
    }
}
