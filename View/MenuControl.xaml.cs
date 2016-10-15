using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro.Controls;
using System.Drawing;
using System.Windows.Shapes;
using System.Windows.Input;
using System;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using Model.Utilerias.Menu;
namespace View
{
    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl : MetroWindow
    {
        public MenuControl()
        {

            InitializeComponent();
            loadMenu();
        }

        private static int ALTURA_HEADER = 40;
        private Item menuVentas(String titulo)
        {

            Item item = new Item(titulo,1);
            List<Item> menuHijos = new List<Item>();
            Item itemHijos = null;
            item.hijos = new List<Item>();
            for (int i=0; i<3; i++)
            {
                itemHijos = new Item(titulo + i,1);
                item.hijos.Add(itemHijos);
            }

            return item;
        }

        private void loadMenu()
        {

            List<Item> main = new List<Item>();
            main.Add(menuVentas("Ventas"));
            main.Add(menuVentas("Pedidos"));
            main.Add(menuVentas("Inventario"));
            main.Add(menuVentas("Catalogos"));
            DoubleAnimation myDoubleAnimation = null;
            StackPanel panelHeader = null;
            int i = 5;
            List<StackPanel> listaAnimada = new List<StackPanel>();
            Rectangle rectangle = null;
            foreach (Item itm in main)
            {
                panelHeader = new StackPanel();
                panelHeader.Name = "panel" + i;
                panelHeader.Height = ALTURA_HEADER+1;
                RegisterName(panelHeader.Name, panelHeader);

                Label labelTitulo = new Label();
              
                labelTitulo.HorizontalContentAlignment = HorizontalAlignment.Center;
                labelTitulo.VerticalContentAlignment = VerticalAlignment.Center;
                labelTitulo.Content = itm.descripcion;
                labelTitulo.Height = ALTURA_HEADER;
                labelTitulo.Foreground = Brushes.White;
                labelTitulo.FontWeight = FontWeights.Bold;
                rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromRgb(217, 217, 217));
                rectangle.Height = 1;


                LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
                linearGradientBrush.EndPoint = new Point(0.5, 1);
                linearGradientBrush.StartPoint = new Point(0.5, 0);
                GradientStop gradientStopUno = new GradientStop();
                gradientStopUno.Offset = 0.01;
                gradientStopUno.Color = Color.FromRgb(124, 200, 236);
                linearGradientBrush.GradientStops.Add(gradientStopUno);
                GradientStop gradientStopDos = new GradientStop();
                gradientStopDos.Offset = 1;
                gradientStopDos.Color = Color.FromRgb(93, 148, 174);
                linearGradientBrush.GradientStops.Add(gradientStopDos);
                //labelTitulo.Background = linearGradientBrush;
                labelTitulo.Background = new SolidColorBrush(Color.FromRgb(113, 177, 209));


                panelHeader.Children.Add(labelTitulo);
                panelHeader.Children.Add(rectangle);
                panelHijos(itm, panelHeader);

                listaAnimada.Add(panelHeader);
                i++;
            }
            EventTrigger entTrigger = null;
            Storyboard myWidthAnimatedButtonStoryboard = null;
            foreach (StackPanel itm in listaAnimada)
            {
                myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.Duration = TimeSpan.FromSeconds(0.5);
                myDoubleAnimation.AccelerationRatio = 0.6;
                myDoubleAnimation.DecelerationRatio = 0.4;
                myDoubleAnimation.To = 200;
                myWidthAnimatedButtonStoryboard = new Storyboard();
                Storyboard.SetTargetName(myDoubleAnimation, itm.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(StackPanel.HeightProperty));
                myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);

                foreach (StackPanel sunItm in listaAnimada)
                {
                    if (!itm.Name.Equals(sunItm.Name))
                    {
                        myDoubleAnimation = new DoubleAnimation();
                        myDoubleAnimation.Duration = TimeSpan.FromSeconds(0.5);
                        myDoubleAnimation.AccelerationRatio = 0.6;
                        myDoubleAnimation.DecelerationRatio = 0.4;
                        myDoubleAnimation.To = ALTURA_HEADER+1;
                        Storyboard.SetTargetName(myDoubleAnimation, sunItm.Name);
                        Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(StackPanel.HeightProperty));
                        myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);
                    }
                }
                entTrigger = new EventTrigger(); ;
                entTrigger.RoutedEvent = UIElement.MouseLeftButtonUpEvent;
                entTrigger.Actions.Add(new BeginStoryboard { Storyboard = myWidthAnimatedButtonStoryboard });
                itm.Triggers.Add(entTrigger);
                mainStack.Children.Add(itm);
            }

            


        }

        private void panelHijos(Item item, StackPanel stackPanel)
        {
            Label subItemUno = null;
            Rectangle rectangle1 = null;
            foreach (Item itm in item.hijos)
            {
                
                if (itm.hijos != null)
                {
                    panelHijos(item, stackPanel);
                }
                else
                {
                    subItemUno  = new Label();
                    
                    subItemUno.MouseLeftButtonDown += delegate { eventoClick(subItemUno); };
                    subItemUno.Content = itm.descripcion;
                    subItemUno.HorizontalContentAlignment = HorizontalAlignment.Center;
                    subItemUno.Background = null;
                    rectangle1 = new Rectangle();
                    rectangle1.Fill = new SolidColorBrush(Color.FromRgb(217, 217, 217)); ;
                    rectangle1.Height = 1;
                    //rectangle1.Stroke = new SolidColorBrush(Color.FromRgb(255, 170, 170));
                    stackPanel.Children.Add(subItemUno);
                    stackPanel.Children.Add(rectangle1);
                }
            }
        }

        private static void eventoClick(Control control)
        {
            MessageBox.Show("asdasdasdasdas");
        }

        private void loadMenuComponente()
        {
            for (int i = 0; i < 1; i++)
            {

                StackPanel panelVentas = new StackPanel();
                panelVentas.Name = "panelV" + i;
                panelVentas.Height = 26;

                Label labelTitulo = new Label();
                labelTitulo.HorizontalContentAlignment = HorizontalAlignment.Center;
                labelTitulo.VerticalContentAlignment = VerticalAlignment.Center;
                labelTitulo.Content = panelVentas.Height;

                labelTitulo.Foreground = Brushes.White;
                labelTitulo.FontWeight = FontWeights.Bold;



                LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
                linearGradientBrush.EndPoint = new Point(0.5, 1);
                linearGradientBrush.StartPoint = new Point(0.5, 0);
                GradientStop gradientStopUno = new GradientStop();
                gradientStopUno.Offset = 0.01;
                gradientStopUno.Color = Color.FromRgb(124, 200, 236);
                linearGradientBrush.GradientStops.Add(gradientStopUno);
                GradientStop gradientStopDos = new GradientStop();
                gradientStopDos.Offset = 1;
                gradientStopDos.Color = Color.FromRgb(93, 148, 174);
                linearGradientBrush.GradientStops.Add(gradientStopDos);
                labelTitulo.Background = linearGradientBrush;

                Label subItemUno = new Label();
                subItemUno.Content = "Punto de Venta";
                subItemUno.HorizontalContentAlignment = HorizontalAlignment.Center;
                subItemUno.Background = null;
                Rectangle rectangle1 = new Rectangle();
                rectangle1.Fill = new SolidColorBrush(Color.FromRgb(255, 170, 170));
                rectangle1.Height = 10;
                rectangle1.Stroke = new SolidColorBrush(Color.FromRgb(255, 170, 170));



                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.Duration = TimeSpan.FromSeconds(0.5);
                myDoubleAnimation.AccelerationRatio = 0.6;
                myDoubleAnimation.DecelerationRatio = 0.4;
                myDoubleAnimation.To = 379;

                DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
                myDoubleAnimation1.Duration = TimeSpan.FromSeconds(0.5);
                myDoubleAnimation1.AccelerationRatio = 0.6;
                myDoubleAnimation1.DecelerationRatio = 0.4;
                myDoubleAnimation1.To = 26;


                DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
                myDoubleAnimation2.Duration = TimeSpan.FromSeconds(0.5);
                myDoubleAnimation2.AccelerationRatio = 0.6;
                myDoubleAnimation2.DecelerationRatio = 0.4;
                myDoubleAnimation2.To = 26;

                DoubleAnimation myDoubleAnimation3 = new DoubleAnimation();
                myDoubleAnimation3.Duration = TimeSpan.FromSeconds(0.5);
                myDoubleAnimation3.AccelerationRatio = 0.6;
                myDoubleAnimation3.DecelerationRatio = 0.4;
                myDoubleAnimation3.To = 26;

                DoubleAnimation myDoubleAnimation4 = new DoubleAnimation();
                myDoubleAnimation4.Duration = TimeSpan.FromSeconds(0.5);
                myDoubleAnimation4.AccelerationRatio = 0.6;
                myDoubleAnimation4.DecelerationRatio = 0.4;
                myDoubleAnimation4.To = 26;

                this.RegisterName(panelVentas.Name, panelVentas);

                Storyboard.SetTargetName(myDoubleAnimation, "panelV0");
                Storyboard.SetTargetName(myDoubleAnimation1, "Panel1");
                Storyboard.SetTargetName(myDoubleAnimation2, "Panel2");
                Storyboard.SetTargetName(myDoubleAnimation3, "Panel3");
                Storyboard.SetTargetName(myDoubleAnimation4, "Panel4");

                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(StackPanel.HeightProperty));
                Storyboard.SetTargetProperty(myDoubleAnimation1, new PropertyPath(StackPanel.HeightProperty));
                Storyboard.SetTargetProperty(myDoubleAnimation2, new PropertyPath(StackPanel.HeightProperty));
                Storyboard.SetTargetProperty(myDoubleAnimation3, new PropertyPath(StackPanel.HeightProperty));
                Storyboard.SetTargetProperty(myDoubleAnimation4, new PropertyPath(StackPanel.HeightProperty));

                Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
                myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation1);
                myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation2);
                myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation3);
                myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation4);
                myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);


                EventTrigger entTrigger = new EventTrigger(); ;
                entTrigger.RoutedEvent = UIElement.MouseLeftButtonUpEvent;

                entTrigger.Actions.Add(new BeginStoryboard { Storyboard = myWidthAnimatedButtonStoryboard });

                panelVentas.Triggers.Add(entTrigger);



                panelVentas.Children.Add(labelTitulo);
                panelVentas.Children.Add(subItemUno);
                panelVentas.Children.Add(rectangle1);
                mainStack.Children.Add(panelVentas);
            }

        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World");
        }


    }

}
