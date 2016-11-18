using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Venta.PuntoVenta
{
    

    public class DetPuntoVenta : INotifyPropertyChanged
    {
        public ObservableCollection<ItemVenta> itemsVenta { get; set; }

        public DetPuntoVenta()
        {
            itemsVenta = new ObservableCollection<ItemVenta>();
        }
        public void makeCalculoVenta(string clave)
        {
            ItemVenta itemVenta = new ItemVenta();
            itemVenta.descripcion = " PRIMER PRODUCTO ";
            itemVenta.idArticulo = 1;
            itemVenta.precio = 10;

            itemsVenta.Add(itemVenta);
            NotifyChange("itemsVenta");

        }

        void NotifyChange(params string[] ids)
        {
            if (PropertyChanged != null)
                foreach (var id in ids)
                    PropertyChanged(this, new PropertyChangedEventArgs(id));
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }

}
