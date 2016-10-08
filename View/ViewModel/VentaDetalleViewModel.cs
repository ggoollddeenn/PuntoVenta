using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;
using System.Windows.Input;

namespace View.ViewModel
{
    public class VentaDetalleViewModel : INotifyPropertyChanged
    {
        VENTA_DETALLE Model;
        EmpleadoViewModel _empleadoViewModel;

        public VentaDetalleViewModel(EmpleadoViewModel empleado)
        {
            _empleadoViewModel = empleado;
        }

        #region Propiedades Model

        public int ID_VENTA_DETALLE
        {
            get
            {
                return Model.ID_VENTA_DETALLE;
            }
            set
            {
                Model.ID_VENTA_DETALLE = value;
                NotifyChange("ID_VENTA_DETALLE");
            }
        }
        public Nullable<int> ID_VENTA

        {
            get
            {
                return Model.ID_VENTA; //no le puse modelo
            }
            set
            {
                Model.ID_VENTA = value;
                NotifyChange("ID_VENTA");
            }
        }

        public Nullable<decimal> PRECIO_ARTICULO
        {


            get
            {
                return Model.PRECIO_ARTICULO;

            }
            set
            {
                Model.PRECIO_ARTICULO = value;
                NotifyChange("PRECIO_ARTICULO");

            }
        }

        public Nullable<int> CANTIDAD
        {
            get
            {
                return Model.CANTIDAD;
            }
            set
            {
                Model.CANTIDAD = value;
                NotifyChange("CANTIDAD");
            }
        }

        public decimal IMPORTE
        {
            get
            {
                return Model.IMPORTE;
            }

            set
            {
                Model.IMPORTE = value;
                NotifyChange("IMPORTE");
            }
        }

        public decimal TOTAL
        {
            get
            {
                return Model.TOTAL;
            }

            set
            {
                Model.TOTAL = value;
                NotifyChange("TOTAL");
            }

        }


        public int ID_OFERTA_CLIENTE
        {
            get
            {
                return Model.ID_OFERTA_CLIENTE;
            }
            set
            {
                Model.ID_OFERTA_CLIENTE = value;
                NotifyChange("ID_OFERTA_CLIENTE");
            }
        }

        public virtual ARTICULO ARTICULO
        {

            get
            {
                return Model.ARTICULO;
            }
            set
            {
                Model.ARTICULO = value;
                NotifyChange("ARTICULO");
            }
        }
        #endregion

        ICommand Insertar
        {
            get
            {
                return new RelayCommand(o => insertar());
            }
        }

        ICommand Eliminar
        {
            get
            {
                return new RelayCommand(o => eliminar());
            }
        }

        ICommand Editar
        {
            get
            {
                return new RelayCommand(o => editar());
            }
        }


        #region Métodos
        void insertar()
        {
            DataManager.insertarVentaDetalle(Model);
        }

        void editar()
        {
            DataManager.editarVentaDetalle(Model);
        }
        void eliminar()
        {
            DataManager.eliminarVentaDetalle(Model);
        }
        #endregion

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
