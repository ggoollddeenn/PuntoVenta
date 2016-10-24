using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Shapes;
using System.Windows.Input;
using System;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using Model.Utilerias.Menu;

namespace Model.Utilerias.Menu
{
   
    public class UIMenu
    {
        public UIMenu(StackPanel _mainStack)
        {
            mainStack = _mainStack;
        }
        private StackPanel mainStack;

        private static int ALTURA_HEADER = 40;
        private static int ALTURA_ITEM = 26;
       

        public List<StackPanel> loadMenu(List<Item> main)
        {

            
            StackPanel panelHeader = null;
            int i = 5;
            List<StackPanel> listaAnimada = new List<StackPanel>();
            Rectangle rectangle = null;
            StackPanel stackPanelHeader = null;
            Label labelEpand = null;
            Label labelTitulo = null;
            foreach (Item itm in main)
            {
                panelHeader = new StackPanel();
                panelHeader.Name = "panel" + i;
                panelHeader.Height = ALTURA_HEADER + 1;

                //RegisterName(panelHeader.Name, panelHeader);

                stackPanelHeader = new StackPanel();
                labelTitulo = new Label();

                labelTitulo.HorizontalContentAlignment = HorizontalAlignment.Center;
                labelTitulo.VerticalContentAlignment = VerticalAlignment.Center;
                labelTitulo.Content = itm.descripcion;
                labelTitulo.Height = ALTURA_HEADER;
                labelTitulo.Width = 101;
                labelTitulo.Foreground = Brushes.White;
                labelTitulo.FontWeight = FontWeights.Bold;
                rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromRgb(217, 217, 217));
                rectangle.Height = 1;
                labelTitulo.Background = new SolidColorBrush(Color.FromRgb(113, 177, 209));



                stackPanelHeader.Orientation = Orientation.Horizontal;




                labelEpand = labelIcon("appbar_chevron_right");



                stackPanelHeader.Children.Add(labelIcon(itm.icono));
                stackPanelHeader.Children.Add(labelTitulo);
                stackPanelHeader.Children.Add(labelEpand);

                panelHeader.Children.Add(stackPanelHeader);
                panelHeader.Children.Add(rectangle);

                panelHijos(itm, panelHeader);

                listaAnimada.Add(panelHeader);
                i++;
            }
            EventTrigger entTrigger = null;
            Storyboard myWidthAnimatedButtonStoryboard = null;
            double tamano = 0;
            i = 0;
            StackPanel auxStack = null;
            foreach (StackPanel itm in listaAnimada)
            {
                auxStack = (StackPanel)itm.Children[0];
                itm.MouseLeftButtonUp += new MouseButtonEventHandler(clickHeader);

                tamano = (((Item)main[i]).hijos.Count * ALTURA_ITEM) + ALTURA_HEADER + 1 + 70;
                i++;
                myWidthAnimatedButtonStoryboard = new Storyboard();
                myWidthAnimatedButtonStoryboard.Children.Add(getAnimation(itm.Name, tamano));

                foreach (StackPanel sunItm in listaAnimada)
                {
                    if (!itm.Name.Equals(sunItm.Name))
                    {
                        myWidthAnimatedButtonStoryboard.Children.Add(getAnimation(sunItm.Name, ALTURA_HEADER + 1));
                    }
                }
                entTrigger = new EventTrigger(); ;
                entTrigger.RoutedEvent = UIElement.MouseLeftButtonUpEvent;
                entTrigger.Actions.Add(new BeginStoryboard { Storyboard = myWidthAnimatedButtonStoryboard });
                itm.Triggers.Add(entTrigger);
                mainStack.Children.Add(itm);
            }


            return listaAnimada;

        }

      

        private Label labelIcon(string icono)
        {
            Rectangle rectangleIcon = null;
            Label labelIcon = null;

            labelIcon = new Label();
            labelIcon.Width = 50;
            labelIcon.Height = ALTURA_HEADER;
            labelIcon.Background = new SolidColorBrush(Color.FromRgb(113, 177, 209));
            rectangleIcon = new Rectangle();
            rectangleIcon.Height = ALTURA_HEADER + 1;
            rectangleIcon.Width = 20;
            rectangleIcon.Fill =
             new VisualBrush()
             {
                 Visual = (Visual)Application.Current.FindResource(icono),
                 Stretch = Stretch.Uniform,
             };
            labelIcon.Content = rectangleIcon;

            return labelIcon;
        }

        private DoubleAnimation getAnimation(String name, double altura)
        {
            DoubleAnimation myDoubleAnimation = null;
            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.Duration = TimeSpan.FromSeconds(0.5);
            myDoubleAnimation.AccelerationRatio = 0.6;
            myDoubleAnimation.DecelerationRatio = 0.4;
            myDoubleAnimation.To = altura;
            Storyboard.SetTargetName(myDoubleAnimation, name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(StackPanel.HeightProperty));
            return myDoubleAnimation;
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
                    subItemUno = new Label();

                    subItemUno.MouseLeftButtonDown += delegate { eventoClick(subItemUno); };
                    subItemUno.Content = itm.descripcion;
                    subItemUno.HorizontalContentAlignment = HorizontalAlignment.Center;
                    subItemUno.Background = null;
                    rectangle1 = new Rectangle();
                    rectangle1.Fill = new SolidColorBrush(Color.FromRgb(217, 217, 217)); ;
                    rectangle1.Height = 1;
                    stackPanel.Children.Add(subItemUno);
                    stackPanel.Children.Add(rectangle1);
                }
            }
        }

        private static void eventoClick(Control control)
        {

            MessageBox.Show("asdasdasdasdas");
        }

        void clickHeader(Object sender, RoutedEventArgs e)
        {
            Rectangle rectangleIcon = null;


            var auxStak = ((StackPanel)sender).Children[0];
            double altura = ((StackPanel)sender).Height;
            if (altura == ALTURA_HEADER + 1)
            {
                rectangleIcon = new Rectangle();
                rectangleIcon.Height = ALTURA_HEADER;
                rectangleIcon.Width = 20;
                rectangleIcon.Fill =
                 new VisualBrush()
                 {
                     Visual = (Visual)Application.Current.FindResource("appbar_chevron_down"),
                     Stretch = Stretch.Uniform,
                 };
                ((Label)((StackPanel)auxStak).Children[2]).Content = rectangleIcon;
            }


            StackPanel stackAux = null;
            foreach (StackPanel itm in mainStack.Children)
            {
                stackAux = (StackPanel)itm.Children[0];


                if (!((StackPanel)sender).Name.Equals(itm.Name))
                {
                    rectangleIcon = new Rectangle();
                    rectangleIcon.Height = ALTURA_HEADER;
                    rectangleIcon.Width = 20;
                    rectangleIcon.Fill =
                    new VisualBrush()
                    {
                        Visual = (Visual)Application.Current.FindResource("appbar_chevron_right"),
                        Stretch = Stretch.Uniform,
                    };

                    ((Label)(stackAux).Children[2]).Content = rectangleIcon;

                }
            }


        }
    }


}
