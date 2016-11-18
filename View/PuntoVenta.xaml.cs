using Model.Venta.PuntoVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Interaction logic for PuntoVenta.xaml
    /// </summary>
    public partial class PuntoVenta : Window
    {
        private DetPuntoVenta detPuntoVenta;

        public PuntoVenta()
        {
            detPuntoVenta = new DetPuntoVenta();
            InitializeComponent();
        }

        private void keyDownField(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                detPuntoVenta.makeCalculoVenta(codigoField.Text);
            }
        }
    }

   
}
