using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos_de_Examen_by_MoDz7
{
    class Vec
    {
        //Declaramos las variables, constantes globaes y iniciamos el Constructor
        const int dimension = 101;
        private int cantidad;
        private int[] vector;

        public Vec()
        {
            this.cantidad = 0;
            vector = new int[dimension];
        }

        //Operaciones de Cargar y Descargar
        public void CargarRandom(int cant, int ini, int fin)
        {
            this.cantidad = cant;
            Random rand = new Random();
            for(int idx = 1; idx <= cant; idx++)
            {
                vector[idx] = rand.Next(ini, fin + 1);
            }
        }

        public void CargarxElementos(int termino)
        {
            this.cantidad = this.cantidad + 1;
            vector[this.cantidad] = termino;
        }
      

        public string DescargarVector()
        {
            string concatenar = "|";
            for(int idx = 1; idx <= this.cantidad; idx++)
            {
                concatenar = concatenar + vector[idx] + "|";
            }
            return concatenar;
        }




        //-------------Funciones y Procedimientos Auxiliares--------------

        //Cargar un Vector Randomicamente sin repetir Elementos
        public void CargarRandomSinRepetir(int cant, int ini, int fin)
        {
            this.cantidad = cant;
            Random rand = new Random();
            int idx = 1;
            while (idx <= cant)
            {
                int aux = rand.Next(ini, fin + 1);
                if (BusquedaSecuencial(aux) == false)
                {
                    vector[idx] = aux;
                    idx++;
                }
                
            }

        }

        //Intercambiar 2 elementos de un Vector
        public void IntercambiarElementos(int termino1,int termino2)
        {
            int aux = vector[termino2];
            vector[termino2] = vector[termino1];
            vector[termino1] = aux;
        }

        //Eliminar un Elemento del Vector
        public void EliminarElemento(int posicion)
        {
            for(int idx = posicion; idx <= this.cantidad; idx++)
            {
                vector[idx] = vector[idx + 1];
            }
            this.cantidad = this.cantidad - 1;
        }

        //Ordenar vector de Menor a Mayor por parametros
        public void OrdMenaMay(int ini,int fin)
        {
            for(int ter1 = ini; ter1 <= fin; ter1++)
            {
                for(int ter2 = ter1 + 1; ter2 <= fin; ter2++)
                {
                    if (vector[ter2] < vector[ter1])
                    {
                        IntercambiarElementos(ter2, ter1);

                    }
                }
            }
        }

        //Ordenar vector de Mayor a Menor por parametros
        public void OrdMayaMen(int ini, int fin)
        {
            for (int ter1 = ini; ter1 <= fin; ter1++)
            {
                for (int ter2 = ter1 + 1; ter2 <= fin; ter2++)
                {
                    if (vector[ter2] > vector[ter1])
                    {
                        IntercambiarElementos(ter2, ter1);

                    }
                }
            }
        }

        //Realiza una busqueda secuencial de un elemento en el vector
        public bool BusquedaSecuencial(int elemento)
        {
            bool respuesta = false;
            for(int idx = 1; idx <= this.cantidad; idx++)
            {
                if (elemento == vector[idx])
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }




        //-------------------EXAMENES-----------------------
        //--------------Modelo de Examen Nro1-----------------

        //Pregunta 1: Eliminar elementos repetidos del vector "PURGAR" en el mismo vector
        public void EliminarElemRep()
        {
            int idx = 1;
            OrdMenaMay(idx, this.cantidad);
            while (idx <= this.cantidad)
            {
                int elemento = vector[idx];
                idx++;
                if (elemento == vector[idx])
                {
                    EliminarElemento(idx);
                }
            }
        }

        //Pregunta 2: Cargar 2 vectores (random sin repetir) y hacer la union de estos en un nuevo vector (TEORIA DE CONJUNTOS)
        public void UnionVectores(Vec vector2,ref Vec vectorUnion)
        {
            vectorUnion.cantidad = 0;
            for(int idx1 = 1; idx1 <= this.cantidad; idx1++)
            {
                vectorUnion.CargarxElementos(this.vector[idx1]);
            }
            for(int idx2 = 1; idx2 <= vector2.cantidad; idx2++)
            {
                vectorUnion.CargarxElementos(vector2.vector[idx2]);
            }
        }

        //--------------Modelo de Examen Nro2------------------

        //Pregunta 3: Encontrar Elementos y Frecuencias ordenados de < a > con elementos de Fibonacci de rango a y b
        public void EleyFrecFibo(int ini, int fin, ref Vec vecEle,ref Vec vecFrec)
        {
            vecEle.cantidad = 0;
            vecFrec.cantidad = 0;
            int idx, elemento, frecuencia, varA, varB, varFibo;
            idx = ini; varA = 0; varB = 1; varFibo = 0;
            OrdMenaMay(ini, fin);
            while(idx<=fin)
            {
                elemento = vector[idx];
                frecuencia = 0;
                varFibo = varA + varB;
                if(elemento == varFibo)
                {
                    while(elemento == vector[idx])
                    {
                        frecuencia++;idx++;
                    }
                    vecEle.CargarxElementos(elemento);
                    vecFrec.CargarxElementos(frecuencia);
                }
                else if(elemento < varFibo)
                {
                    idx++;
                }
                else if(elemento > varFibo)
                {
                    varA = varB;varB = varFibo;
                }

            }
        }

        //Pregunta 4 : Cargar randomicamente el vector sin Elementos repetidos
        //Esta operacion ya la hice en la parte de funciones y procedimientos auxiliares


        //--------------Modelo de Examen Nro3------------------

        //Pregunta 5 : Cargar 2 vectores, realizar diferencia simetrica en un nuevo vector (TEORIA DE CONJUNTOS)
        public void DifSimetrica(Vec vector2, ref Vec vecDifSim)
        {
            vecDifSim.cantidad = 0;
            for(int idx1 = 1; idx1 <= this.cantidad; idx1++)
            {
                int aux1 = this.vector[idx1];
                if (vector2.BusquedaSecuencial(aux1) == false)
                {
                    vecDifSim.CargarxElementos(aux1);
                }
            }
            for (int idx2 = 1; idx2 <= vector2.cantidad; idx2++)
            {
                int aux2 = vector2.vector[idx2];
                if (this.BusquedaSecuencial(aux2) == false)
                {
                    vecDifSim.CargarxElementos(aux2);
                }
            }
        }


    }
}
