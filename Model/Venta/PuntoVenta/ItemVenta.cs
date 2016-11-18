using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Venta.PuntoVenta
{

    public class ItemVenta
    {
        public int idArticulo { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }

        public override string ToString()
        {
            return descripcion + "   " + precio;
        }
    }
}
