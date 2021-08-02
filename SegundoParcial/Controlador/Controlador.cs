using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class prueba
    {
        PantallaPrincipalView PantallitaPrincipal = new PantallaPrincipalView();
        Restaurante Mcdowells = new Restaurante();
        NuevoPedidoView pedidoNuevo = new NuevoPedidoView();
        ProximoPedidoViewModel proximoPedido = new ProximoPedidoViewModel();
        PrepararPedidoViewModel prepararPedido = new PrepararPedidoViewModel();
        public void OpcionesElegidasSM()
        {
            bool seguirEnSM = true;
            while (seguirEnSM)
            {
                Console.Clear();
                int opcion = pedidoNuevo.NuevoPedido();
                switch (opcion)
                {
                    case 0:
                        MostrarOpcionesCombos();
                        SumarLosPrecios();
                        Console.Clear();
                        break;
                    case 1:
                        SumarLosPrecios();
                        EncolarPedidoEnCola();
                        Console.Clear();
                        seguirEnSM = false;
                        break;
                    case 2:
                        seguirEnSM = false;
                        break;
                }
            }
        }
        public void OpcionesElegidasMP()
        {
            bool nunca = true;
            CargarOpcionesCombos();
            PantallitaPrincipal.LlenarListaMenuPrincipal();
            pedidoNuevo.LlenarOpcionesCombo();
            while (nunca)
            {
                int eleccion = PantallitaPrincipal.PantallaPrincipal();
                switch (eleccion)
                {
                    case 0:
                        if (pedidoNuevo.combosElegidos.Count != 0)
                        {
                            pedidoNuevo.PedidoEnCurso();
                            break;
                        }
                        else 
                        {
                            
                            pedidoNuevo.DatosCliente();
                            OpcionesElegidasSM();
                        }
                        break;
                    case 1:
                        if (Mcdowells.PedidosCola.Count == 0)
                        {
                            proximoPedido.AvisoQueueVacio("Tenes que agregar un pedido para poder verlo");
                            break; 
                        }
                        proximoPedido.MostrarProximoPedido(Mcdowells.VerProximoPedido());
                        Console.Clear();
                        break;
                    case 2:
                        if (Mcdowells.PedidosCola.Count == 0)
                        {
                            proximoPedido.AvisoQueueVacio("Tenes que agregar un pedido para poder venderlo");
                            break; 
                        }
                        prepararPedido.PrepararProximoPedido(Mcdowells.PrepararProximoPedido());
                        Console.Clear();
                        EliminarValoresLista();
                        pedidoNuevo.TotalPrecio = 0;
                        break;
                }
            }
        }
        public void CargarOpcionesCombos()
        {
            foreach (Combo p in this.Mcdowells.InfoCombo(Mcdowells.ListaCombos))
            {
                pedidoNuevo.combosVista.Add(new Combo()
                {
                    IdInterno = p.IdInterno,
                    PlatoPrincipal = p.PlatoPrincipal,
                    Acompaniamiento = p.Acompaniamiento,
                    Bebida = p.Bebida,
                    Precio = p.Precio,
                });
            }
        }
        public void MostrarOpcionesCombos()
        {
            int eleccion = this.pedidoNuevo.MostrarOpcionesCombo();
            if(eleccion != Mcdowells.ListaCombos.Count)
            {
                Combo comboElegido = this.Mcdowells.ListaCombos[eleccion];
                pedidoNuevo.combosElegidos.Add(comboElegido);
            }
        }
        public void EncolarPedidoEnCola()
        {
            Mcdowells.PedidosCola.Enqueue(new Pedido()
            {
                Cliente = pedidoNuevo.Nombre,
                EsParaLLevar = pedidoNuevo.EsParaLLevar,
                PrecioTotal = pedidoNuevo.TotalPrecio,
                CombosOrdenados = pedidoNuevo.combosElegidos,
            });
        }
        public void SumarLosPrecios()
        {
            for(int i = 0; i < pedidoNuevo.combosElegidos.Count; i++)
            {
                pedidoNuevo.TotalPrecio += pedidoNuevo.combosElegidos[i].Precio;
            }
        }
        public void EliminarValoresLista()
        {
            pedidoNuevo.combosElegidos.Clear();
        }

    }
}
