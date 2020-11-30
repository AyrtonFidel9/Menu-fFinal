using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVolumenPrisma
{
    class ClVolumen
    {
        public double volumenPrismaCuadrado (double altura, double lado)
        {
            Console.WriteLine("area de base: "+areaBase(lado));
            return (altura*areaBase(lado))/3;
        }

        private double areaBase (double lado)
        {   
            return Math.Pow(lado,2);
        }
    }
}
