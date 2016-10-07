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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using View.ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        async private void btnIniciarSession_Click(object sender, RoutedEventArgs e)
        {
            var metroWindow = getWindow("Login") as MetroWindow;
            
            var controller = await metroWindow.ShowProgressAsync("Please wait", "Connecting to the database...");
            int respuesta = await DataManager.login(txtUsuario.Text, txtContrasena.Password);
            //int respuesta = DataManager.login(txtUsuario.Text, txtContrasena.Password);
            if (respuesta != 0)
            {

                controller.SetMessage("Bienvenido");
                WaitSeconds(2);
                controller.CloseAsync();
            }
            else {
                controller.SetMessage("Contraseña incorrecta");
                WaitSeconds(2);
                controller.CloseAsync();
            }
        }

        public Window getWindow(string title)
        {
            Window windowObject = null;
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.Title == title)
                {
                    windowObject = window;
                }
            }
            return windowObject;
        }

        private static void WaitSeconds(double nSecs)
        {
            // Esperar los segundos indicados

            // Crear la cadena para convertir en TimeSpan
            string s = "0.00:00:" + nSecs.ToString().Replace(",", ".");
            TimeSpan ts = TimeSpan.Parse(s);

            // Añadirle la diferencia a la hora actual
            DateTime t1 = DateTime.Now.Add(ts);

            // Esta asignación solo es necesaria
            // si la comprobación se hace al principio del bucle
            DateTime t2 = DateTime.Now;

            // Mientras no haya pasado el tiempo indicado
            while (t2 < t1)
            {
                // Un respiro para el sitema
                System.Windows.Forms.Application.DoEvents();
                // Asignar la hora actual
                t2 = DateTime.Now;
            }
        }
    }
}
