using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class PrepararPedidoViewModel
    {
        public void PrepararProximoPedido(Pedido hola)
        {
            Console.Clear();
            Console.WriteLine("==Nuevo pedido===");
            Console.WriteLine($"Cliente: {hola.Cliente}");
            Console.WriteLine($"Para llevar: {hola.EsParaLLevar}");
            Console.WriteLine("Detalle:");
            for (int i = 0; i < hola.CombosOrdenados.Count; i++)
            {
                Console.WriteLine($"* {i} - {hola.CombosOrdenados[i].IdInterno} - {hola.CombosOrdenados[i].PlatoPrincipal} - {hola.CombosOrdenados[i].Acompaniamiento} - {hola.CombosOrdenados[i].Bebida} - {hola.CombosOrdenados[i].Precio}");
            }
            Console.WriteLine();
            Console.WriteLine($"Total: ${hola.PrecioTotal}");
            Console.WriteLine($"!Listo para entregar¡");
            Console.WriteLine("Presione ENTER para continuar");
            Console.ReadLine();
        }
    }
}
