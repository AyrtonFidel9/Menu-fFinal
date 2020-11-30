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
using System.Windows.Threading;

namespace WpfAppJuego.Clases
{
    class Enemigos
    {
        Image enemigo;
        int speed;
        Canvas lienzo;
      
        public void setCuerpoEnemigo (Image img)
        {
            this.enemigo = img;
        }

        public void setAreaDibujo (Canvas cv)
        {
            this.lienzo = cv;
        }
        public void moverEnemigo(int velocidad)
        {
            this.speed = velocidad;
            DispatcherTimer mover = new DispatcherTimer();
            mover.Tick += moverCuerpoEnemigo;
            mover.Interval = TimeSpan.FromMilliseconds(30);
            mover.Start();
        }

        private void moverCuerpoEnemigo (object sender, EventArgs e)
        {
            if (enemigo != null)
            {
                if(Canvas.GetLeft(enemigo) > -enemigo.ActualWidth)
                {
                    Canvas.SetLeft(enemigo, Canvas.GetLeft(enemigo) - speed);
                    
                }
                else
                {
                    lienzo.Children.Remove(enemigo);
                }
            }

            

        }


        
    }
}
