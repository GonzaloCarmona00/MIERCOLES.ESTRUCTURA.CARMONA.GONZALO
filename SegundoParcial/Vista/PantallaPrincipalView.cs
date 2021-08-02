using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class PantallaPrincipalView
    {
        List<string> menuPrincipal = new List<string>();
        public void LlenarListaMenuPrincipal()
        {
            menuPrincipal.Add("Nuevo pedido");
            menuPrincipal.Add("Ver proximo pedido");
            menuPrincipal.Add("Preparar proximo pedido");
        }
        public void MostrarMenu(string msj, List<string> aux)
        {
            Console.WriteLine(msj);
            for(int i = 0; i < aux.Count; i++)
            {
                Console.WriteLine($"{i} - {aux[i]}");
            }
        }
        public int PantallaPrincipal()
        {
            int min = 0;
            int max = 2;
            int eleccion;
            MostrarMenu("===McDowells===", menuPrincipal);
            while (!int.TryParse(Console.ReadLine(), out eleccion) || eleccion > max || eleccion < min)
            {
                Console.Clear();
                MostrarMenu("===McDowells===", menuPrincipal);
            }
            Console.WriteLine($"Su eleccion: {eleccion}");
            return eleccion;
        }
    }
}
