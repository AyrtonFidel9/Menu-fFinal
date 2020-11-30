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
using System.Windows.Media.Animation;
using WpfAppJuego.Clases;
using WpfAppJuego.Controles;
using System.Windows.Threading;
using MahApps.Metro.Controls;

namespace WpfAppJuego
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Inicio objI = new Inicio();
        int speed = 5; // declaring an integer called speed with value of 10
        int altura = 100;
        int ancho = 100;

        int vida = 3;

        Image enem =new Image();
        Image enemigo1 = new Image();
        Image enemigo2 = new Image();
        Image enemigo3 = new Image();
        bool goUp; // this is the go up boolean
        bool goDown; // this is the go down boolean
        bool goLeft; // this is the go left boolean
        bool goRight; // this is the go right boolean
        int segundos = 60;
        int min = 1;
        DispatcherTimer colisiones = new DispatcherTimer();
        DispatcherTimer dispatcherTimer = new DispatcherTimer(); // adding the timer to the form
        DispatcherTimer enemigos = new DispatcherTimer();
        DispatcherTimer reloj = new DispatcherTimer();
        DispatcherTimer comp = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            
            
            grdPantalla.Children.Add(objI);

            comp.Tick += comprobar;
            comp.Interval = TimeSpan.FromMilliseconds(1000);
            comp.Start();

        }

        private void comprobar (object sender, EventArgs e)
        {
            if (objI.Visibility == Visibility.Hidden)
            {
                comp.Stop();       
                grdPantalla.Children.Remove(objI);
                AreaJuego.Focus();
                //Movimiento del avión

                dispatcherTimer.Tick += Timer_Tick; // linking the timer event
                dispatcherTimer.Interval = TimeSpan.FromMilliseconds(0.7); // running the timer every 20 milliseconds
                dispatcherTimer.Start(); // starting the timer

                //Generar enemigo y su movimiento

                enemigos.Tick += generarEnemigos;
                enemigos.Interval = TimeSpan.FromMilliseconds(1000);//1000
                enemigos.Start();

                //colisiones
                colisiones.Tick += capturarColisiones;
                colisiones.Interval = TimeSpan.FromMilliseconds(500);//500
                colisiones.Start();

                //tiempo

                reloj.Tick += tiempoReloj;
                reloj.Interval = TimeSpan.FromMilliseconds(1000);
                reloj.Start();
            }
        }

        private void capturarColisiones(object sender, EventArgs e)
        {
            EnumVisual(AreaJuego);
            if (vida == 2)
            {
                imgVida3.Visibility = Visibility.Hidden;
            }
            if (vida == 1)
            {
                imgVida3.Visibility = Visibility.Hidden;
                imgVida2.Visibility = Visibility.Hidden;
            }
            if (vida <= 0)
            {
                imgVida3.Visibility = Visibility.Hidden;
                imgVida2.Visibility = Visibility.Hidden;
                imgVida1.Visibility = Visibility.Hidden;
                GameOver usGO = new GameOver();
                usGO.setVentana(pantalla);
                grdPantalla.Children.Add(usGO);
                dispatcherTimer.Stop();
                enemigos.Stop();
                reloj.Stop();
                colisiones.Stop();
                pantalla.Focus();
            }
        }

        private void tiempoReloj(object sender, EventArgs e)
        {
            if(segundos == 60)
            {
                min--;
                segundos--;
                Tiempo.Text = min.ToString() + ":" + segundos.ToString();
            }
            else
            {
                segundos--;
                Tiempo.Text = min.ToString() + ":" + segundos.ToString();
            }

            if (segundos == 0 && vida > 0)
            {
                Ganador pG = new Ganador();
                pG.setVentana(pantalla);
                grdPantalla.Children.Add(pG);
                dispatcherTimer.Stop();
                enemigos.Stop();
                colisiones.Stop();
                reloj.Stop();
                pantalla.Focus();

            }
                
        }

        private void generarEnemigos(object sender, EventArgs e)
        {
            Random rdmPosicionTop = new Random();
            double posTop = rdmPosicionTop.Next(0, 400);
            Random enemigo = new Random();
            double enem = enemigo.Next(1,4);
            Random velocidad = new Random();
            int vel = enemigo.Next(1, 5);

            enemigo1.Height = altura;
            enemigo1.Width = ancho;
            enemigo1.Source = new BitmapImage(new Uri("/Images/murcielago.png", UriKind.Relative));

            //Image enemigo2 = new Image();
            enemigo2.Width = ancho;
            enemigo2.Height = altura;
            enemigo2.Source = new BitmapImage(new Uri("/Images/asteroide.png", UriKind.Relative));
            //Image enemigo3 = new Image();
            enemigo3.Width = ancho+50;
            enemigo3.Height = altura+50;
            enemigo3.Source = new BitmapImage(new Uri("/Images/mothman.png", UriKind.Relative));

            Enemigos objE = new Enemigos();
            objE.setAreaDibujo(AreaJuego);

            switch (enem)
            {
                case 1:

                    try
                    {
                        AreaJuego.Children.Add(enemigo1);
                        Canvas.SetLeft(enemigo1, AreaJuego.Width + enemigo1.ActualHeight);
                        Canvas.SetTop(enemigo1, posTop);
                        objE.setCuerpoEnemigo(enemigo1);
                        objE.moverEnemigo(vel);
                    }
                    catch
                    {

                    }
                    
                   
                    break;

                case 2:

                    try
                    {
                        AreaJuego.Children.Add(enemigo2);
                        Canvas.SetLeft(enemigo2, AreaJuego.Width + enemigo2.ActualHeight);
                        Canvas.SetTop(enemigo2, posTop);
                        objE.setCuerpoEnemigo(enemigo2);
                        objE.moverEnemigo(vel);
                    }
                    catch
                    {

                    }

                    break;

                case 3:
                    try
                    {
                        AreaJuego.Children.Add(enemigo3);
                        Canvas.SetLeft(enemigo3, AreaJuego.Width + enemigo3.ActualHeight);
                        Canvas.SetTop(enemigo3, posTop);
                        objE.setCuerpoEnemigo(enemigo3);
                        objE.moverEnemigo(vel);
                    }
                    catch
                    {

                    }
                    break;

            }

        }

        

        private void AreaJuego_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = true;
            }
            else if (e.Key == Key.Up)
            {
                goUp = true;
            }
            else if (e.Key == Key.Left)
            {
                goLeft = true;
            }
            else if (e.Key == Key.Right)
            {
                goRight = true;
            }
        }

        private void AreaJuego_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                goDown = false; // down is released go down will be false
                //MessageBox.Show("Entre 1");
            }
            else if (e.Key == Key.Up)
            {
                goUp = false; // up key is released go up will be false
                //MessageBox.Show("Entre 2");
            }
            else if (e.Key == Key.Left)
            {
                goLeft = false; // left key is released go left will be false
                //MessageBox.Show("Entre 3");
            }
            else if (e.Key == Key.Right)
            {
                goRight = false; // right key is released go right will be false
                //MessageBox.Show("Entre 4");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (segundos == 0)
            {
                reloj.Stop();
            }

            if (goUp && Canvas.GetTop(icAvion) > 0)
            {

                Canvas.SetTop(icAvion, Canvas.GetTop(icAvion) - speed);
                // if go up is true and player is within the boundary from the top 
                // then we can use the set top to move the rec1 towards top of the screen
            }
            if (goDown && (Canvas.GetTop(icAvion) + (icAvion.Height * 2)) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(icAvion, Canvas.GetTop(icAvion) + speed);
                // if go down is true and player is within the boundary from the bottom of the screen
                // then we can set top of rec1 to move down
            }
            if (goLeft && Canvas.GetLeft(icAvion) > 0)
            {
                Canvas.SetLeft(icAvion, Canvas.GetLeft(icAvion) - speed);
                // if go left is true and player is inside the boundary from the left
                // then we can set left of the player to move towards left of the screen
            }
            if (goRight && Canvas.GetLeft(icAvion) + (icAvion.Width * 2) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(icAvion, Canvas.GetLeft(icAvion) + speed);
                // if go right is true and player is inside the boundary from the right
                // then we can set left of the player to move towards right of the screen
            }     
        }

        public void EnumVisual(Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                //// Do processing of the child visual object.
                try
                {
                    if ((childVisual as FrameworkElement).ToString() == "System.Windows.Controls.Image")
                    {
                        colision(icAvion, (childVisual as Image));
                    }
                }
                catch
                {

                }
                // Enumerate children of the child visual object.
                EnumVisual(childVisual);
            }
        }

        private bool CheckCollision(TextBlock e1, Image e2)
        {
            var r1 = e1.ActualWidth / 2;
            var x1 = Canvas.GetLeft(e1) + r1;
            var y1 = Canvas.GetTop(e1) + r1;
            var r2 = e2.ActualWidth / 2;
            var x2 = Canvas.GetLeft(e2) + r2;
            var y2 = Canvas.GetTop(e2) + r2;
            var d = new Vector(x2 - x1, y2 - y1);
            return d.Length <= r1 + r2;
        }

        private void colision (TextBlock e1, Image e2)
        {
            var x1 = Canvas.GetLeft(e1);
            var y1 = Canvas.GetTop(e1);
            Rect r1 = new Rect(x1, y1, e1.ActualWidth, e1.ActualHeight);


            var x2 = Canvas.GetLeft(e2);
            var y2 = Canvas.GetTop(e2);
            Rect r2 = new Rect(x2, y2, e2.ActualWidth, e2.ActualHeight);

            if (r1.IntersectsWith(r2))
            {
                vida--;
               
            }
                
        }
    }

   
}
