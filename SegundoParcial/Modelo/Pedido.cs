using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public class Pedido
    {
        public string Cliente { get; set; }
        public string EsParaLLevar { get; set; }
        public decimal PrecioTotal { get; set; }
        public List<Combo> CombosOrdenados { get; set; }
    }
}
