using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSerie.Clases
{
    class Serie
    {
        private int cantidad = 0;
        public int Cantidad { get => cantidad; set => cantidad = value; }

        
        
        public double valorSerie ()
        {
            if(cantidad != 0)
            {
                factorial(3);
                int exp = 1;
                double serie = 0;
                int i = 1;
                int par = 2;
                int impar = 1;
                while (i <= cantidad)
                {
                    if (i % 2 == 0)
                        serie -= (factorial(par) / Math.Pow(impar, exp));
                    else
                        serie += (Math.Pow(impar, exp) / factorial(par));
                    par += 2;
                    impar += 2;
                    exp++;
                    i++;

                }

                return serie;
            }
            return 0;
        }

        private int factorial(int num, int valor = 1)
        {
            if(num == 1)
                return valor;
            else
            {
                valor *= num;
                return factorial(num-1,valor);
            }
        }

    }
}
