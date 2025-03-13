using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matriz
    {
        const int DFilas = 101;
        const int DColumnas = 101;
        new int[,] matriz;
        new int filas, columnas;

        public Matriz()
        {
            matriz = new int[DFilas, DColumnas];
            this.filas = 0; this.columnas = 0;
        }

        public void CargarRandom(int nfilas,int ncolumnas,int ini, int fin)
        {
            Random rand = new Random();
            this.filas = nfilas;
            this.columnas = ncolumnas;
            for(int fila = 1; fila <= nfilas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
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
        //Funciones Auxiliares
        public void intercambio(int fil1,int col1,int fil2, int col2)
        {
            int aux = matriz[fil1, col1];
            matriz[fil1, col1] = matriz[fil2, col2];
            matriz[fil2, col2] = aux;
        }

        public void IntercambioFilas(int fil1, int fil2)
        {
            for(int columna = 1; columna <= this.columnas; columna++)
            {
                int aux = matriz[fil1, columna];
                matriz[fil1, columna] = matriz[fil2, columna];
                matriz[fil2, columna] = aux;
            }
        }

        public bool BusquedaSecuencial(int elemento)
        {
            bool respuesta = false;
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
                {
                    if(elemento == matriz[fila, columna])
                    {
                        respuesta = true;
                    }
                }
            }
            return respuesta;
        }
        public bool EsPrimo(int elemento)
        {
            bool respuesta = false;
            int contador = 0;
            for(int idx = 1; idx <= elemento; idx++)
            {
                int residuo = elemento % idx;
                if (residuo == 0)
                {
                    contador++;
                }
            }
            if (contador == 2 || contador == 1)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public bool EsPar(int elemento)
        {
            bool respuesta = false;
            if (elemento % 2 == 0)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public void ORDENARFILASizquierdaaderecha()
        {
            int filpos, colpos, fildesp, coldesp, idx;
            for (filpos = 1; filpos <= this.filas; filpos++)
            {
                for (colpos = 1; colpos <= this.columnas; colpos++)
                {
                    for (fildesp = filpos; fildesp <= this.filas; fildesp++)
                    {
                        if (fildesp == filpos)
                        {
                            idx = colpos;
                        }
                        else
                        {
                            idx = 1;
                        }

                        for (coldesp = idx; coldesp <= this.columnas; coldesp++)
                        {
                            if (matriz[filpos, colpos] > matriz[fildesp, coldesp])
                            {
                                this.intercambio(fildesp, coldesp, filpos, colpos);
                            }
                        }
                    }
                }
            }
        }
        public void ORDENARCOLUMNASabajoarriba()
        {
            int filpos, colpos, fildesp, coldesp, idx;
            for (colpos = 1; colpos <= this.columnas; colpos++)
            {
                for (filpos = this.filas; filpos >= 1; filpos--)
                {
                    for (coldesp = colpos; coldesp <= this.columnas; coldesp++)
                    {
                        if (coldesp == colpos)
                        {
                            idx = filpos;
                        }
                        else
                        {
                            idx = this.filas;
                        }

                        for (fildesp = idx; fildesp >= 1; fildesp--)
                        {
                            if (matriz[filpos, colpos] > matriz[fildesp, coldesp])
                            {
                                this.intercambio(fildesp, coldesp, filpos, colpos);
                            }
                        }
                    }
                }
            }
        }

        public void ORDENARCOLUMNASarribaabajo()
        {
            int filpos, colpos, fildesp, coldesp, idx;
            for (colpos = 1; colpos <= this.columnas; colpos++)
            {
                for (filpos = 1; filpos <= this.filas; filpos++)
                {
                    for (coldesp = colpos; coldesp <= this.columnas; coldesp++)
                    {
                        if (coldesp == colpos)
                        {
                            idx = filpos;
                        }
                        else
                        {
                            idx = 1;
                        }

                        for (fildesp = idx; fildesp <= this.filas; fildesp++)
                        {
                            if (matriz[filpos, colpos] > matriz[fildesp, coldesp])
                            {
                                this.intercambio(fildesp, coldesp, filpos, colpos);
                            }
                        }
                    }
                }
            }
        }

        public void ORDENARCOLUMNASabajoarribaPARAMETROS(int fili, int filf, int coli, int colf)
        {
            int filpos, colpos, fildesp, coldesp, idx;
            for (colpos = coli; colpos <= colf; colpos++)
            {
                for (filpos = filf; filpos >= 1; filpos--)
                {
                    for (coldesp = colpos; coldesp <= colf; coldesp++)
                    {
                        if (coldesp == colpos)
                        {
                            idx = filpos;
                        }
                        else
                        {
                            idx = filf;
                        }

                        for (fildesp = idx; fildesp >= 1; fildesp--)
                        {
                            if (matriz[filpos, colpos] > matriz[fildesp, coldesp])
                            {
                                this.intercambio(fildesp, coldesp, filpos, colpos);
                            }
                        }
                    }
                }
            }
        }

        public void ORDENARCOLUMNASarribaabajoPARAMETROS(int fili, int filf, int coli, int colf)
        {
            int filpos, colpos, fildesp, coldesp, idx;
            for (colpos = coli; colpos <= colf; colpos++)
            {
                for (filpos = fili; filpos <= filf; filpos++)
                {
                    for (coldesp = colpos; coldesp <= colf; coldesp++)
                    {
                        if (coldesp == colpos)
                        {
                            idx = filpos;
                        }
                        else
                        {
                            idx = fili;
                        }

                        for (fildesp = idx; fildesp <= filf; fildesp++)
                        {
                            if (matriz[filpos, colpos] > matriz[fildesp, coldesp])
                            {
                                this.intercambio(fildesp, coldesp, filpos, colpos);
                            }
                        }
                    }
                }
            }
        }

        public int FrecElemFilaMatriz(int elemento,int fila)
        {
            int contador = 0;
            for (int columna = 1; columna <= this.columnas; columna++)
            {
                if (matriz[fila, columna] == elemento)
                {
                    contador++;
                }
            }
            return contador;
        }


        //-------------PRACTICO 1: MATRICES--------------------

        //1. Con elementos primos de la matriz acumular.
        public double OperPrimos()
        {
            double respuesta = 0;
            bool bandera = false;
            for(int fila = this.filas; fila >= 1; fila--)
            {
                for(int columna = this.columnas; columna >= 1; columna--)
                {
                    int elemento = matriz[fila, columna];
                    if (EsPrimo(elemento) == true)
                    {
                        if (bandera == false) 
                        {
                            respuesta = respuesta - Math.Sqrt(matriz[fila,columna]);
                            bandera = true;
                        }
                        else
                        {
                            respuesta = respuesta + Math.Sqrt(matriz[fila, columna]);
                            bandera = false;
                        }
                    }
                }
            }
            return respuesta;
        }

        //2. Encontrar la frecuencia de un elemento en la matriz.
        public int FrecElemMatriz(int elemento)
        {
            int contador = 0;
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
                {
                    if (matriz[fila, columna] == elemento)
                    {
                        contador++;
                    }
                }
            }
            return contador;
        }

        //3. Contar elementos que no se repiten (únicos).
        public int ElementonoRep()
        {
            int contador = 0;
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
                {
                    if (this.FrecElemMatriz(matriz[fila, columna])==1)
                    {
                        contador++;
                    }
                }
            }
            return contador;
        }

        //4. Cargar la matriz con la serie de Fibonacci según esquema. “Pinponear en cambio de filas”
        public void CargarFibo(int nfilas, int ncolumnas)
        {
            this.filas = nfilas;
            this.columnas = ncolumnas;
            int var1, var2, varfibo, fila;
            bool aux = false;
            var1 = -1; var2 = 1;varfibo = 0; fila = 1;
            while (fila <= nfilas)
            {
                if (aux == false)
                {
                    aux = true;
                    for(int columna = 1; columna <= ncolumnas; columna++)
                    {
                        varfibo = var1 + var2;
                        matriz[fila, columna] = varfibo;
                        var1 = var2; var2 = varfibo;                       
                    }
                }
                else
                {
                    aux = false;
                    for (int columna = ncolumnas; columna > 0 ; columna--)
                    {
                        varfibo = var1 + var2;
                        matriz[fila, columna] = varfibo;
                        var1 = var2; var2 = varfibo;
                    }
                }
               
                fila++;
            }
        }

        //5. Verificar si todas las filas están ordenadas en forma ascendente.
        public bool VerfAsce()
        {
            bool respuesta = true;
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
                {
                    if (respuesta == true)
                    {
                        if (matriz[fila, columna - 1] > matriz[fila, columna]) 
                        {
                            respuesta = false;
                        }
                    }
                }
            }
            return respuesta;
        }

        //6. Para todas las filas, encontrar el elemento de mayor frecuencia y colocarlas en la última columna
        public void MayorFrecFila()
        {
            int frec1, frec2, ele, auxc;
            frec1 = 0; frec2 = 0;auxc = 0;
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
                {
                    ele = matriz[fila, columna];
                    frec1 = this.FrecElemFilaMatriz(ele, fila);
                    if (frec1 >= frec2)
                    {
                        auxc = columna;
                        frec2 = frec1;
                    }
                }
                this.intercambio(fila, auxc, fila, this.columnas);
            }
        }

        //7. Verificar si la matriz esta ordenada con rigor r=1 del esquema según el ejemplo
        public bool VerifOrdeColum()
        {
            bool respuesta = true;
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
                {
                    if (matriz[fila, columna] < matriz[fila, columna - 1])
                    {
                        respuesta = false;
                    }
                }
            }
            return respuesta;
        }

        //8. Verificar si una matriz está incluida en otro a matriz
        public bool VerifInclusion(ref Matriz matrizB)
        {
            bool respuesta = true;
            for(int fila = 1; fila <= this.filas; fila++)
            {
                for(int columna = 1; columna <= this.columnas; columna++)
                {
                    int elemento = matriz[fila, columna];
                    if (matrizB.BusquedaSecuencial(elemento) == false) 
                    {
                        respuesta = false;
                    }
                }
            }
            return respuesta;
        }

        //9. Segmentar las filas de la matriz en pares e impares ordenados
        public void SegmentarParImpar()
        {
            for (int fil1 = 1; fil1 <= this.filas; fil1++)
            {
                for (int col1 = 1; col1 <= this.columnas; col1++)
                {
                    for (int col2 = 1; col2 <= this.columnas; col2++)
                    {
                        int numero1 = matriz[fil1, col1];
                        int numero2 = matriz[fil1, col2];

                        if ((EsPar(numero1)) && !(EsPar(numero2)) ||
                            (EsPar(numero1)) && (EsPar(numero2)) && (matriz[fil1, col1] < matriz[fil1, col2]) ||
                            !(EsPar(numero1)) && !(EsPar(numero2)) && (matriz[fil1, col1] < matriz[fil1, col2]))
                        {
                            this.intercambio(fil1, col1, fil1, col2);
                        }
                    }
                }
            }
        }



        //10. Ordenar las filas por el número de elementos primos.
        public void OrdenFilaPrimos()
        {
            int contador, elemento;
            contador = 0;
            for (int fila = 1; fila <= this.filas; fila++)
            {
                for (int columna = 1; columna <= this.columnas; columna++)
                {
                    elemento = matriz[fila, columna];
                    if (EsPrimo(elemento) == true)
                    {
                        contador++;
                    }
                }              
                matriz[fila, this.columnas + 1] = contador;
                contador = 0;
            }
            this.columnas++;
            for(int filap = 1; filap < this.filas; filap++)
            {
                for(int filad = filap + 1; filad <= this.filas; filad++)
                {
                    if (matriz[filap, this.columnas] < matriz[filad, this.columnas])
                    {
                        IntercambioFilas(filap, filad);
                    }
                }
            }
        }





        //---------------------- PRACTICO 2 -------------------------------------

        //1. Ordenar los elementos de una matriz por su frecuencia en el rango
        public void OrdFrecRango(int filaI,int filaF,int columnaI,int columnaF)
        {
            for(int fila = filaI; fila <= filaF; fila++)
            {

            }
        }
        //2. Ordenar en forma “senozoidal” la matriz, ver esquema.
        public void ordenSenozoidal()
        {
            bool aux = false;
            int colaux = 1;
            while (colaux <= this.columnas)
            {
                if(aux == false)
                {
                    aux = true;
                    ORDENARCOLUMNASabajoarribaPARAMETROS(1, this.filas, colaux, this.columnas);
                }
                else
                {
                    aux = false;
                    ORDENARCOLUMNASarribaabajoPARAMETROS(1, this.filas, colaux, this.columnas);
                }
                colaux++;
            }
        }




    }
}
