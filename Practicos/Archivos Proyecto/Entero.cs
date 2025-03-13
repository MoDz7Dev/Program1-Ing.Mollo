using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos_Proyecto
{
    class Entero
    {
        private int n;

        public Entero()
        {
            n = 0;
        }
        public void cargar(int d)
        {
            n = d;
        }
        public int descargar()
        {
            return n;
        }

        public bool verifMayor(double n1)
        {
            return n > n1;
        }

        public bool verifMenor(double n1)
        {
            return n < n1;
        }
    }
}
