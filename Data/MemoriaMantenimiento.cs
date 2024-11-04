using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;
namespace P2_FloricelaArguedas_WebApplication.Data
{
    public class MemoriaMantenimiento
    {

        public static IList<Mantenimiento> listadeMantenimientos = new List<Mantenimiento>();

        // GET: MantenimientoController
        public static IList<Mantenimiento> Index()
        {
            if (!listadeMantenimientos.Any())
            {
                Mantenimiento mantenimiento = new Mantenimiento
                {
                    IdMantenimiento = 1,
                    IdCliente = 1,
                    FechaEjecutado = new DateTime(2024, 10, 10, 10, 0, 0),
                    FechaAgendado = new DateTime(2024, 11, 12, 10, 0, 0),
                    m2Propiedad = 250,
                    m2CercaViva = 40,
                    EstadoMantenimiento = "En Proceso",
                    DiasSinChapia = 15,
                    FechaSiguienteChapia = new DateTime(2024, 12, 12, 10, 0, 0),
                    TipoZacate = "San Agustin",
                    ProductoAplicado = "Si",
                    TipoProductoAplicado = "Coyolillo",
                    CostoChapiaM2 = 100,
                    CostoProductoM2 = 50,
                    CostoTotalMantenimiento = 50000
                };
                listadeMantenimientos.Add(mantenimiento);
            }
            return listadeMantenimientos;
        }

        // GET: MantenimientoController/Details/5
        public static Mantenimiento SearchOne(int Id)
        {
            if (!listadeMantenimientos.Any())
            {

                throw new ArgumentNullException("En este momento no existen Mantenimientos");
                
            }
            Mantenimiento MantenimientoALeer = listadeMantenimientos.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == Id);
            if (MantenimientoALeer == null) 
            {
                throw new KeyNotFoundException($"No se encontró Mantenimiento con el ID {Id}.");
            }
            return (MantenimientoALeer);
        }


        //LOGICA PARA CAMPOS AUTOCALCULADOS PARA LOS ATRIBUTOS DEL OBJETO

        // Instancia del objeto Mantenimiento para poder usar sus atributos para calcular campos
        Mantenimiento mantenimiento = new Mantenimiento();

        //METODO PARA DIAS SIN CHAPIA
        public static void DiasSinChapia(Mantenimiento MantenimientoNuevo)
        {
            DateOnly FechaActual = DateOnly.FromDateTime(DateTime.Now); //Obtengo la fecha actual en ejecución
            TimeSpan tiempotranscurrido = FechaActual.ToDateTime(TimeOnly.MinValue) - MantenimientoNuevo.FechaEjecutado; //Resta de las fechas
            MantenimientoNuevo.DiasSinChapia = (int)tiempotranscurrido.TotalDays; //Extraigo el total de días y lo paso a INT
        }

        //METODO PARA FECHA SIGUIENTE CHAPIA

        public static void fechaSiguientehapia(IList<Cliente> ListaClientes, Mantenimiento MantenimientoNuevo)
        {
            Cliente ClienteMantenimiento = null;
            if (ListaClientes.Any())
            {
                ClienteMantenimiento = ListaClientes.FirstOrDefault(cliente => cliente.Id == MantenimientoNuevo.IdCliente);
                //VERANO
                DateTime FechaActual = DateTime.Now;
                if (FechaActual.Month == 12 || FechaActual.Month <= 4)
                {
                    if (ClienteMantenimiento.MantenimientoVerano == "Quincenal")
                    {
                        MantenimientoNuevo.FechaSiguienteChapia = MantenimientoNuevo.FechaEjecutado.AddDays(15);
                    }
                    else
                    {
                        MantenimientoNuevo.FechaSiguienteChapia = MantenimientoNuevo.FechaEjecutado.AddDays(30);
                    }
                }
                else
                { //INVIERNO

                    if (ClienteMantenimiento.MantenimientoInvierno == "Quincenal")
                    {
                        MantenimientoNuevo.FechaSiguienteChapia = MantenimientoNuevo.FechaEjecutado.AddDays(15);
                    }
                    else
                    {
                        MantenimientoNuevo.FechaSiguienteChapia = MantenimientoNuevo.FechaEjecutado.AddDays(30);
                    }
                }
            }
        }


        //METODO PARA COSTO TOTAL MANTENIMIENTO

        public static void CostoTotal(Mantenimiento MantenimientoNuevo)
        {

            int CostoTotal = (((MantenimientoNuevo.m2Propiedad + MantenimientoNuevo.m2CercaViva) * MantenimientoNuevo.CostoChapiaM2) +
                              ((MantenimientoNuevo.m2Propiedad + MantenimientoNuevo.m2CercaViva) * MantenimientoNuevo.CostoProductoM2));
            double CostoTotalconIVA = CostoTotal + (CostoTotal * 0.13);
            double CostoTotalconDescuento;

            //SWITCH PARA MANEJAR LOS DESCUENTOS

            switch (MantenimientoNuevo.m2Propiedad) 
            {

                case int m2Propiedad when (m2Propiedad >= 400 && m2Propiedad <= 900):
                    CostoTotalconDescuento = CostoTotalconIVA - (CostoTotalconIVA * 0.02); //Descuento del 2%
                    break;

                case int m2Propiedad when (m2Propiedad >= 901 && m2Propiedad <= 1500):
                    CostoTotalconDescuento = CostoTotalconIVA - (CostoTotalconIVA * 0.03); //Descuento del 3%
                    break;

                case int m2Propiedad when (m2Propiedad >= 1501 && m2Propiedad <= 2000):
                    CostoTotalconDescuento = CostoTotalconIVA - (CostoTotalconIVA * 0.04); //Descuento del 4%
                    break;

                case int m2Propiedad when (m2Propiedad > 2000):
                    CostoTotalconDescuento = CostoTotalconIVA - (CostoTotalconIVA * 0.05); //Descuento del 5%
                    break;

                default:
                    CostoTotalconDescuento = CostoTotalconIVA; // Mantengo el precio sin descuento.
                    break;
            }

            //Envio el precio al atributo del mantenimiento
                MantenimientoNuevo.CostoTotalMantenimiento = CostoTotalconDescuento;
        }
            
        
        // POST: MantenimientoController/Create

        public static Mantenimiento Create(Mantenimiento MantenimientoNuevo)
        {
            //OBTENGO LA LISTA DE CLIENTES Y EXTRAIGO EL QUE SE NECESITA
            IList<Cliente> ListaClientes = Data.MemoriaCliente.listadeClientes;

            try
            {
                if (MantenimientoNuevo == null)
                {
                    throw new ArgumentNullException(nameof(MantenimientoNuevo), "El Mantenimiento no puede ser nulo.");
                }
                else
                {
                    //Llamo a las funciones para los campos AutoCalculados
                    if (ListaClientes.Count != 0)
                    {
                        DiasSinChapia(MantenimientoNuevo);
                        fechaSiguientehapia(ListaClientes, MantenimientoNuevo);
                        CostoTotal(MantenimientoNuevo);
                        listadeMantenimientos.Add(MantenimientoNuevo);
                    }
                }
                return MantenimientoNuevo;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar el mantenimiento a la lista.", ex);
            }
        }


        // POST: MantenimientoController/Edit/5

        public static Mantenimiento Edit(Mantenimiento MantenimientoEditado)
        {
            //OBTENGO LA LISTA DE CLIENTES Y EXTRAIGO EL QUE SE NECESITA
            IList<Cliente> ListaClientes = Data.MemoriaCliente.listadeClientes;
            try
            {
                if (!listadeMantenimientos.Any())
                {
                    throw new ArgumentNullException("En este momento no existen mantenimientos");
                }

                Mantenimiento MantenimientoAActualizar = listadeMantenimientos.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == MantenimientoEditado.IdMantenimiento);
                MantenimientoAActualizar.FechaEjecutado = MantenimientoEditado.FechaEjecutado;
                MantenimientoAActualizar.FechaAgendado = MantenimientoEditado.FechaAgendado;
                MantenimientoAActualizar.m2Propiedad = MantenimientoEditado.m2Propiedad;
                MantenimientoAActualizar.m2CercaViva = MantenimientoEditado.m2CercaViva;
                MantenimientoAActualizar.EstadoMantenimiento = MantenimientoEditado.EstadoMantenimiento;
                MantenimientoAActualizar.TipoZacate = MantenimientoEditado.TipoZacate;
                MantenimientoAActualizar.ProductoAplicado = MantenimientoEditado.ProductoAplicado;
                MantenimientoAActualizar.TipoProductoAplicado = MantenimientoEditado.TipoProductoAplicado;
                MantenimientoAActualizar.CostoChapiaM2 = MantenimientoEditado.CostoChapiaM2;
                MantenimientoAActualizar.CostoProductoM2 = MantenimientoEditado.CostoProductoM2;
                //Llamo a la funciones para que recalculen estos campos nuevamente y queden actualizados
                DiasSinChapia(MantenimientoEditado);
                fechaSiguientehapia(ListaClientes, MantenimientoEditado);
                CostoTotal(MantenimientoEditado);
                MantenimientoAActualizar.DiasSinChapia = MantenimientoEditado.DiasSinChapia;
                MantenimientoAActualizar.FechaSiguienteChapia = MantenimientoEditado.FechaSiguienteChapia;
                MantenimientoAActualizar.CostoTotalMantenimiento = MantenimientoEditado.CostoTotalMantenimiento;
                return MantenimientoAActualizar;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar el mantenimiento a la lista.", ex);
            }
        }


        // POST: MantenimientoController/Delete/5

        public static void Delete(int id)
        {
            try
            {
                Mantenimiento MantenimientoAEliminar = listadeMantenimientos.FirstOrDefault(mantenimiento => mantenimiento.IdMantenimiento == id);
                if (MantenimientoAEliminar != null)
                {
                    listadeMantenimientos.Remove(MantenimientoAEliminar);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al eliminar el mantenimiento de la lista.", ex);
            }
        }

    }
}

        
