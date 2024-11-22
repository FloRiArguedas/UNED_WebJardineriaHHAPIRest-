
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P2_FloricelaArguedas_WebApplication.Models;
using System.Collections.Generic;

namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class MemoriaCliente
    {
        private BDContexto ContextoBaseDatos;

        public MemoriaCliente(BDContexto ctxt)
        {
            ContextoBaseDatos = ctxt ?? throw new ArgumentNullException(nameof(ctxt));
        }

        //Obtengo la lista de la base de datos

        public IList<Cliente> ObtenerLista()  
        {
            var listaLeida = from c in ContextoBaseDatos.Cliente select c;
            return listaLeida.ToList();
        }

         
        // GET: ClienteController
        public IList<Cliente> Index()  //FUNCION PARA EL INDEX
        {
            IList<Cliente> listadeClientes = ObtenerLista();
            if (!listadeClientes.Any())
            {
                Cliente cliente = new Cliente
                {
                    Id = 1,
                    Nombre = "Floricela",
                    Provincia = "Heredia",
                    Canton = "Santo Domingo",
                    Distrito = "Santo Domingo",
                    DireccionExacta = "Contiguo Templo Católico",
                    MantenimientoInvierno = "Quincenal",
                    MantenimientoVerano = "Mensual"
                };
                listadeClientes.Add(cliente);
            }
            return listadeClientes;
        }


    
        public  Cliente SearchOne(int id)
        {
            IList<Cliente> listadeClientes = ObtenerLista();
            if (listadeClientes.Any())
            { 
                Cliente clienteAbuscar = listadeClientes.FirstOrDefault(cliente => cliente.Id == id);
                if (clienteAbuscar != null)
                {
                    return clienteAbuscar;
                }
            }
            return (null);
        }


        // POST: ClienteController/Create
       
        public Cliente Create(Cliente clienteNuevo)
        {
            try
            {
                if (clienteNuevo == null)
                {
                    return null;
                }
                ContextoBaseDatos.Cliente.Add(clienteNuevo);
                ContextoBaseDatos.SaveChanges();
                return (clienteNuevo);
            }
            catch
            {
                return null;
            }
        }



        // POST: ClienteController/Edit/
      
        public Cliente Editar(Cliente clienteEditado)
        {
            IList<Cliente> listadeClientes = ObtenerLista();
            try
            {
                if (listadeClientes.Any())
                {
                    Cliente clienteaEditar = listadeClientes.FirstOrDefault(cliente => cliente.Id == clienteEditado.Id);
                    clienteaEditar.Nombre = clienteEditado.Nombre;
                    clienteaEditar.Provincia = clienteEditado.Provincia;
                    clienteaEditar.Canton = clienteEditado.Canton;
                    clienteaEditar.Distrito = clienteEditado.Distrito;
                    clienteaEditar.DireccionExacta = clienteEditado.DireccionExacta;
                    clienteaEditar.MantenimientoInvierno = clienteEditado.MantenimientoInvierno;
                    clienteaEditar.MantenimientoVerano = clienteEditado.MantenimientoVerano;

                    ContextoBaseDatos.Cliente.Update(clienteaEditar);
                    ContextoBaseDatos.SaveChanges();

                    return clienteaEditar;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        // POST: ClienteController/Delete/

        public void Delete (int id)
        {
            IList<Cliente> listadeClientes = ObtenerLista();
            try
            {
                Cliente clienteAEliminar = listadeClientes.FirstOrDefault(cliente => cliente.Id == id);
                if (clienteAEliminar != null)
                {
                    ContextoBaseDatos.Cliente.Remove(clienteAEliminar);
                    ContextoBaseDatos.SaveChanges();
                }
            }
            catch
            {
                return;
            }
        }


        // GET: ClienteController
        public IList<Cliente> GetReportWeek(IList<Mantenimiento> listaMantenimientos)  
        {
            DateTime FechaHoy = DateTime.Now;
            DateTime FechaSemanaEntrante = FechaHoy.AddDays(8);

            IList<Cliente> listadeClientesReporteSemana = new List<Cliente>() ;

            foreach (var mantenimiento in listaMantenimientos) 
            {
                if (FechaHoy <= mantenimiento.FechaAgendado  &&  FechaSemanaEntrante >= mantenimiento.FechaAgendado)
                {
                    Cliente ClienteAgendado = SearchOne(mantenimiento.IdCliente);
                    listadeClientesReporteSemana.Add(ClienteAgendado);
                }
            }
            return listadeClientesReporteSemana;
        }


        // GET: ClienteController
        public IList<Cliente> GetReportMonth(IList<Mantenimiento> listaMantenimientos)
        {
            IList<Cliente> listadeClientesReporteAtrasados = new List<Cliente>();

            foreach (var mantenimiento in listaMantenimientos)
            {

                DateOnly FechaActual = DateOnly.FromDateTime(DateTime.Now); //Obtengo la fecha actual en ejecución
                TimeSpan tiempotranscurrido = FechaActual.ToDateTime(TimeOnly.MinValue) - mantenimiento.FechaEjecutado; //Resta de las fechas

                if ((int)tiempotranscurrido.TotalDays >= 60)
                {
                    Cliente ClienteSinServicio = SearchOne(mantenimiento.IdCliente);
                    listadeClientesReporteAtrasados.Add(ClienteSinServicio);
                }
            }
            return listadeClientesReporteAtrasados;
        }
    }
}

