using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class NuevoPedidoView
    {
        public List<Combo> combosVista = new List<Combo>();
        public List<Combo> combosElegidos = new List<Combo>();
        PantallaPrincipalView pantallaPrincipal = new PantallaPrincipalView();
        public string Nombre;
        public string EsParaLLevar;
        public decimal TotalPrecio;
        public List<string> listaOpcionesCombo = new List<string>();
        public void LlenarOpcionesCombo()
        {
            listaOpcionesCombo.Add("Agregar combo");
            listaOpcionesCombo.Add("Finalizar");
            listaOpcionesCombo.Add("Cancelar");
        }
        public void DatosCliente()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del cliente");
            Nombre = Console.ReadLine();
            Console.WriteLine("¿Es para llevar? (si/no)");
            EsParaLLevar = Console.ReadLine();
            while(EsParaLLevar != "no" && EsParaLLevar != "si")
            {
                Console.Clear();
                Console.WriteLine("¿Es para llevar? (si/no)");
                EsParaLLevar = Console.ReadLine();
            }
        }
        public void ContenidoNuevoPedido()
        {
            Console.WriteLine("==Nuevo pedido===");
            Console.WriteLine($"Cliente: {Nombre}");
            Console.WriteLine($"Para llevar: {EsParaLLevar}");
            Console.WriteLine("Detalle:");
            MostrarCombosPedidos();
            Console.WriteLine();
            Console.WriteLine($"Total: ${TotalPrecio}");
            TotalPrecio = 0;
            Console.WriteLine("================");
            pantallaPrincipal.MostrarMenu("Opciones: ", listaOpcionesCombo);
        }
        public int NuevoPedido()
        {
            int opcion;
            int min = 0;
            int max = 2;
            Console.Clear();
            ContenidoNuevoPedido();
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion > max || opcion < min)
            {
                Console.Clear();
                pantallaPrincipal.MostrarMenu("Opciones: ", listaOpcionesCombo);
            }
            Console.WriteLine($"Su eleccion: {opcion}");
            return opcion;
        }
        public int MostrarOpcionesCombo()
        {
            int respuesta;
            Console.Clear();
            for(int i = 0; i < combosVista.Count; i++)
            {
                Console.WriteLine($"{i} - {combosVista[i].IdInterno} - {combosVista[i].PlatoPrincipal} - {combosVista[i].Acompaniamiento} - {combosVista[i].Bebida} - {combosVista[i].Precio}");
            }
            Console.WriteLine($"{combosVista.Count} - Cancelar");
            respuesta = NumeroEnRango("Su eleccion: ", 0, combosVista.Count);
            return respuesta;
        }
        private int NumeroEnRango(string mensaje, int min, int max)
        {
            int rv;
            Console.WriteLine(mensaje);
            while(!int.TryParse(Console.ReadLine(), out rv) || rv < min || rv > max)
            {
                Console.WriteLine(mensaje);
            }
            return rv;
        }
        public void MostrarCombosPedidos()
        {
            for(int i = 0; i < combosElegidos.Count; i++)
            {
                Console.WriteLine($"* {i} - {combosElegidos[i].IdInterno} - {combosElegidos[i].PlatoPrincipal} - {combosElegidos[i].Acompaniamiento} - {combosElegidos[i].Bebida} - {combosElegidos[i].Precio}");
            }
        }
        public void PedidoEnCurso()
        {
            Console.WriteLine("!Tenes un pedido en curso¡");
            Console.WriteLine("Prepara ese pedido antes de realizar otro");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
