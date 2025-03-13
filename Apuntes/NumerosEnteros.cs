using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nument
{
    class Nent
    {
        private int n; // Esto seria los atributos o propiedades: osea las caracteristicas
                       // que representa un numero entero en este caso es una "n"
        //**********************************************************************

        public void nent() // Constructor debe llevar el mismo nombre que la clase
        {
            n = 0;
        }

        //**********************************************************************
        // Esto serian los getters y setters
        public void cargar(int dato)// Carga el Dato
        {
            n = dato;
        }
        public int descargar()// Descarga el Dato
        {
            return n;
        }
        // ---------------------METODOS O FUNCIONES-----------------------------
        // Funcion: Son operaciones que devuelven un dato, se define de que tipo va ser, si publica
        // o privada seguido por el tipo de dato a devolver (En este caso un booleano), y por ultimo el nombre
        // de la funcion
        // ---------------------------------------------------------------------
        // Metodo/Procedimiento: Es una operacion que no devuelve un dato es decir una serie de instrucciones
        // unicamente esta se define igual que una funcion unicamente que en lugar de poner el tipo de valor
        // a devolver se pone "void"
        public bool verifpar()
        {
            int r;
            bool b;
            r = n % 2;
            if (r == 0)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }
        public int inv()
        {
            int nv, d, a;
            a = n;
            nv = 0;
            while (n > 0)
            {
                d = n % 10;
                nv = nv * 10 + d;
                n = n / 10;
            }
            n = a;
            return nv;
        }
        public void lanzar()
        {
            Random r = new Random();
            int d, i;
            n = 0;
            for (i=1; i <= 5; i++)
            {
                d = r.Next(1, 6 + 1);
                n = n * 10 + d;
            }
        }
        public bool verifgra()
        {
            bool b;
            int dr, d, a;
            a = n;            
            b = true;

            dr = n % 10;
            n = n / 10;

            while ((n>0)&&(b==true))
            {
                d = n % 10;
                n = n / 10;
                if (!(d == dr))
                    b = false;
            }
            n = a;
            return b;
        }
        public int Ndigis()
        {
            int nd;
            if (n != 0)
                nd = (int)Math.Truncate(Math.Log10(Math.Abs(n)) + 1);
            else
                nd = 0;
            return nd;
        }
        public bool Perten(int dig)
        {
            bool b;
            int a, d;
            a = n;
            b = false;

            while ((n>0) && (b == false))
            {
                d = n % 10;
                n = n / 10;
                if (d == dig)
                    b = true;
            }
            n = a;
            return b;
        }
        public void filtrar(ref Nent otroNumero)
        {
            int a, d;
            a = n;
            otroNumero.n = 0;
            while (n > 0)
            {
                d = n % 10;
                n = n / 10;

                if (!(otroNumero.Perten(d) == true))
                    otroNumero.n = otroNumero.n * 10 + d;
            }
            n = a;
        }
        public bool verfifG1()
        {
            Nent faltaGrave;
            faltaGrave = new Nent();
            this.filtrar(ref faltaGrave);
            return (faltaGrave.Ndigis() == 1);
        }
        public int frec(int dig)
        {
            int a, d, fr;
            a = n;
            fr = 0;
            while (n > 0)
            {
                d = n % 10;
                n = n / 10;

                if (d == dig)
                    fr++;
            }
            n = a;
            return fr;
        }
        public bool pokar()
        {
            Nent f;
            bool b;
            int d1, d2;
            f = new Nent();
            this.filtrar(ref f);
            b = false;
            
            if (f.Ndigis() == 2)
            {
                d1 = f.n % 10;
                f.n = f.n / 10;

                d2 = f.n % 10;
                f.n = f.n / 10;

                if ((this.frec(d1) == 1) && (this.frec(d2) == 4))
                    b = true;
                else
                    if ((this.frec(d2) == 1) && (this.frec(d1) == 4))
                    b = false;
            }
            return b;
        }
    }
}
