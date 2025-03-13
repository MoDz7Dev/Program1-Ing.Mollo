using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectores
{
    class Vec
    {
        const int dimension = 101;
        private int[] vector;
        private int cantidad;

        public Vec()
        {
            vector = new int[dimension];
            cantidad = 0;
        }

        public void cargarRandom(int cant, int ini, int fin)
        {
            this.cantidad = cant;
            int idx;
            Random rand = new Random();
            for(idx=1; idx<=cant; idx++)
            {
                vector[idx] = rand.Next(ini, fin + 1);
            }
        }

        public string descargarRandom()
        {
            string separador = "";
            int idx;
            for (idx = 1; idx <= cantidad; idx++)
            {
                separador = separador + vector[idx] + "I";
            }
            return separador;
        }

        public void cargarElexEle(int dato)
        {
            this.cantidad = this.cantidad + 1;
            vector[this.cantidad] = dato;
        }

        public int sumaVectores()
        {
            int suma = 0;
            int idx;
            for (idx = 1; idx <= this.cantidad; idx++)
            {
                suma = suma + vector[idx];
            }
            return suma;
        }

        public double proMedia()
        {
            double promedio;
            promedio = this.sumaVectores() / (double)this.cantidad;
            return promedio;
        }

        public int FrecElemento(int dato)
        {
            int contador = 0;
            for(int idx = 1; idx <= this.cantidad; idx++)
            {
                if (vector[idx] == dato)
                {
                    contador = contador + 1;
                }
            }
            return contador;
        }

        public int FrecPares()
        {
            numerosEnteros number = new numerosEnteros();
            int frecuencia = 0;
            for(int idx = 1; idx <= this.cantidad; idx++)
            {
                number.cargarDatos(vector[idx]);
                if (number.verifcarPar() == true)
                {
                    frecuencia++;
                }
            }
            return frecuencia;
        }

        public int FrecImpares()
        {
            int impares;
            impares  = this.cantidad - this.FrecPares();
            return impares;
        }
    }
}
