using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_Examen
{
    class Matriz
    {
        const int DFilas = 101;
        const int DColumnas = 101;
        private int filas, columnas;
        private int[,] matriz;

        public Matriz()
        {
            matriz = new int[DFilas, DColumnas];
            filas = 0; columnas = 0;
        }

        public void CargarRandom(int fila,int columna,int inicio,int fin)
        {
            Random rand = new Random();
            this.filas = fila; this.columnas = columna; 
            for(int fil = 1; fil <= this.filas; fil++)
            {
                for(int col = 1; col <= this.columnas; col++)
                {
                    matriz[fil, col] = rand.Next(inicio, fin + 1);
                }
            }
        }

        public string Descargar()
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

        public void intercambio(int fil1,int col1,int fil2,int col2)
        {
            int aux = matriz[fil1, col1];
            matriz[fil1, col1] = matriz[fil2, col2];
            matriz[fil2, col2] = aux;
        }

        public void OrdColArribaaAbajoMenorMayor()
        {
            int idx = 0;
            for(int columnap = 1; columnap <= this.columnas; columnap++)
            {
                for(int filap = 1; filap <= this.filas; filap++)
                {
                    for(int columnad = columnap; columnad <= this.columnas; columnad++)
                    {
                        if (columnap == columnad)
                        {
                            idx = filap;
                        }
                        else
                        {
                            idx = 1;
                        }
                        for (int filad = idx; filad <= this.filas; filad++)
                        {
                            if (matriz[filap, columnap] > matriz[filad, columnad])
                            {
                                intercambio(filap,columnap,filad,columnad);
                            }
                        }
                    }
                }
            }
        }
        
    }
}
