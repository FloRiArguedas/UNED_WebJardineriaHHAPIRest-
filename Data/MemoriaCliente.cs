using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;

namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class MemoriaCliente
    {
        public static IList<Cliente> listadeClientes = new List<Cliente>();

        // GETALL: ClienteController
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
    }
}

