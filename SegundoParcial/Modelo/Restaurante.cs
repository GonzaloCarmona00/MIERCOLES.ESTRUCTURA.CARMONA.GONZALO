using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class Restaurante
    {
        public List<Combo> ListaCombos = new List<Combo>();
        public Queue<Pedido> PedidosCola = new Queue<Pedido>();
        public List<Combo> InfoCombo(List<Combo> ListaCombos)
        {
            ListaCombos.Add(new Combo() { IdInterno = "101", PlatoPrincipal = "Mcdowell Con Queso", Acompaniamiento = "Papas fritas", Bebida = "Coto Cola", Precio = 800.00m });
            ListaCombos.Add(new Combo() { IdInterno = "102", PlatoPrincipal = "Mcdowell Triple", Acompaniamiento = "Papas fritas", Bebida = "Zpunk", Precio = 1000.00m });
            ListaCombos.Add(new Combo() { IdInterno = "103", PlatoPrincipal = "Mcdowell Especial", Acompaniamiento = "Aros de cebolla", Bebida = "Coto Cola", Precio = 900.00m });
            ListaCombos.Add(new Combo() { IdInterno = "104", PlatoPrincipal = "Mcdowell Del Dia", Acompaniamiento = "Papas fritas", Bebida = "Agua", Precio = 600.00m });
            return ListaCombos;
        }
        public Pedido VerProximoPedido()
        {
            Console.Clear();
            Pedido pedidazo = PedidosCola.Peek();
            return pedidazo;
        }
        public Pedido PrepararProximoPedido()
        {
            Pedido pedidito = PedidosCola.Dequeue();
            return pedidito;
        }
    }
}
