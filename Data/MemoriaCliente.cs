﻿
using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;
using System.Collections.Generic;

namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class MemoriaCliente
    {
        public static IList<Cliente> listadeClientes = new List<Cliente>();

        // GET: ClienteController
        public static IList<Cliente> Index()  //FUNCION PARA EL INDEX
        {
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


    
        public static Cliente SearchOne(int id)
        {
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
       
        public static Cliente Create(Cliente clienteNuevo)
        {
            try
            {
                if (clienteNuevo == null)
                {
                    return null;
                }
                listadeClientes.Add(clienteNuevo);
                return (clienteNuevo);
            }
            catch
            {
                return null;
            }
        }



        // POST: ClienteController/Edit/
      
        public static Cliente Editar(Cliente clienteEditado)
        {
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

        public static void Delete (int id)
        {
            try
            {
                Cliente clienteAEliminar = listadeClientes.FirstOrDefault(cliente => cliente.Id == id);
                if (clienteAEliminar != null)
                {
                    listadeClientes.Remove(clienteAEliminar);
                }
            }
            catch
            {
                return;
            }
        }


        // GET: ClienteController
        public static IList<Cliente> GetReportWeek(IList<Mantenimiento> listaMantenimientos)  
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
        public static IList<Cliente> GetReportMonth(IList<Mantenimiento> listaMantenimientos)
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

