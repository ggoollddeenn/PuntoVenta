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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Model.Utilerias.Menu;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            loadMenu();
        }
        private Item menuVentas(String titulo, String icono)
        {

            Item item = new Item(titulo, 1);
            item.icono = icono;
            List<Item> menuHijos = new List<Item>();
            Item itemHijos = null;
            item.hijos = new List<Item>();
            for (int i = 0; i < 3; i++)
            {
                itemHijos = new Item(titulo + i, 1);

                item.hijos.Add(itemHijos);
            }

            return item;
        }

        private void loadMenu()
        {
            List<Item> main = new List<Item>();
            main.Add(menuVentas("Ventas", "appbar_box"));
            main.Add(menuVentas("Pedidos", "appbar_brick"));
            main.Add(menuVentas("Inventario", "appbar_billing"));
            main.Add(menuVentas("Catalogos", "appbar_bing"));

            UIMenu uimenu = new UIMenu(mainStack);
           
           foreach(StackPanel itm in uimenu.loadMenu(main))
            {
                //mainStack.Children.Add(itm);
                RegisterName(itm.Name, itm);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menuFly.IsOpen = true;
        }
    }
}
