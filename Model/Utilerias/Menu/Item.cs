using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Utilerias.Menu
{
    public class Item
    {
        

        #region Propiedades

        public Item(String _desripcion,int _idItem)
        {
            idItem = _idItem;
           descripcion = _desripcion;

        }



        public int idItem { get; set; }
        public String descripcion { get; set; }
        public String icono { get; set; }
        public List<Item> hijos { get; set; }

        #endregion
    }
}
