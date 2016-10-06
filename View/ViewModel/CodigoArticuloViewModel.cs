using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Input;

namespace View.ViewModel
{
    public class CodigoArticuloViewModel : INotifyPropertyChanged
    {
        CODIGO_ARTICULO Model;
        EmpleadoViewModel _empleadoViewModel;

        public CodigoArticuloViewModel(EmpleadoViewModel empleadoViewModel)
        {
            _empleadoViewModel = empleadoViewModel;
        }

        #region Propiedades Model

        public int ID_CODIGO_ARTICULO
        {
            get
            {
                return Model.ID_CODIGO_ARTICULO;
            }

            set
            {
                Model.ID_CODIGO_ARTICULO = value;
                NotifyChange("ID_CODIGO_ARTICULO");
            }
        }
        public Nullable<int> ID_ARTICULO
        {
            get
            {
                return Model.ID_ARTICULO;
            }
            set
            {
                Model.ID_ARTICULO = value;
                NotifyChange("ID_ARTICULO");
            }


        }
        public string CODIGO
        {
            get
            {
                return Model.CODIGO;
            }
            set
            {
                Model.CODIGO = value;
                NotifyChange("CODIGO");
            }
        }

        public Nullable<bool> PRINCIPAL
        {
            get
            {
                return Model.PRINCIPAL;
            }
            set
            {
                Model.PRINCIPAL = value;
                NotifyChange("PRINCIPAL");
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

        void NotifyChange(params string[] ids)
        {
            if (PropertyChanged != null)
                foreach (var id in ids)
                    PropertyChanged(this, new PropertyChangedEventArgs(id));
        }
        #endregion

        #region Commandos
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
        #endregion

        #region Métodos
        void insertar()
        {
            DataManager.insertarCodigoArticulo(Model);
        }

        void editar()
        {
            DataManager.eliminarCodigoArticulo(Model);
        }
        void eliminar()
        {
            DataManager.eliminarCodigoArticulo(Model);
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }



}
