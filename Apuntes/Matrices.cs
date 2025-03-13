using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices_Practica1
{
    class Matriz
    {
        const int DimensionF = 50;
        const int DimensionC = 50;
        private int[,] matriz;
        private int filas , columnas;

        public Matriz()
        {
            matriz = new int[DimensionC, DimensionF];
            filas = 0;
            columnas = 0;
        }

        public void CargarRandom(int nfilas,int ncolumnas,int ini, int fin)
        {
            Random rand = new Random();
            this.filas = nfilas;
            this.columnas = ncolumnas;
            for(int fila = 1; fila <= nfilas; fila++)
            {
                for(int columna = 1; columna <= ncolumnas; columna++)
                {
                    matriz[fila, columna] = rand.Next(ini, fin + 1);
                }
            }
        }

        public string DescargarMatriz()
        {
            string concatenar = "";
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
                {
                    concatenar = concatenar + matriz[fila, columna] + "\t";
                }
                concatenar = concatenar + "\x000d" + "\x000a";
            }
            return concatenar;
        }

        public void CargarSerie(int nfilas, int ncolumnas,int termini,int razon)
        {
            this.filas = nfilas;
            this.columnas = ncolumnas;
            int idx = 0;
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna=1;columna <= this.columnas; columna++)
                {
                    idx++;
                    matriz[fila, columna] = termini + (idx - 1) * razon;
                }
            }
        }

        public void SumaMatrices(Matriz matriz2,ref Matriz matrizR)
        {
            for(int fil = 1; fil <= this.columnas; fil++)
            {
                for(int col = 1; col <= this.filas; col++)
                {
                    matrizR.matriz[fil, col] = this.matriz[fil, col] + matriz2.matriz[fil, col];
                }
            }
            matrizR.filas = this.filas;
            matrizR.columnas = this.columnas;
        }

        public void MultiplicacionMatrices(Matriz matriz2,ref Matriz matrizR)
        {
            for(int fil = 1; fil <= this.filas; fil++)
            {
                for(int col = 1; col <= matriz2.columnas; col++)
                {
                    matrizR.matriz[fil, col] = 0;
                    for(int rcol = 1; rcol <= this.columnas; rcol++)
                    {
                        matrizR.matriz[fil, col] = matrizR.matriz[fil, col] + this.matriz[fil, rcol] * matriz2.matriz[rcol, col];
                    }
                }
            }
            matrizR.filas = this.filas;
            matrizR.columnas = matriz2.columnas;
        }

        //Auxiliar para la Multiplicacion
        public void DimensionMatriz(ref int numfilas,ref int numcolumnas)
        {
            numfilas = this.filas;
            numcolumnas = this.columnas;
        }
    }
}
