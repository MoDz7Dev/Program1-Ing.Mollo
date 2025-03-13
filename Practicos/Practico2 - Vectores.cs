using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Vectores
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

        public int DimensionVector()
        {
            return this.cantidad;
        }

        public void CargarVectorRandomicamente(int cant, int ini, int fin)
        {
             this.cantidad = cant;
            Random rand = new Random();
            for (int idx = 1; idx <= cant; idx++)
            {
                vector[idx] = rand.Next(ini, fin + 1);
            }
        }

        public void CargarVectorElemento(int dato)
        {
            this.cantidad = this.cantidad + 1;
            vector[this.cantidad] = dato;
        }

        public string DescargarVector()
        {
            string concatenar = "";
            for (int idx = 1; idx <= this.cantidad; idx++)
            {
                concatenar = concatenar + vector[idx] + "|";
            }
            return "|" + concatenar;
        }

        public bool BusquedaSecuencial(int dato)
        {
            bool respuesta = false;
            int idx = 1;
            while(idx<=this.cantidad && respuesta == false)
            {
                if (vector[idx] == dato)
                {
                    respuesta = true;
                }
                idx++;
            }
            return respuesta;
        }
        public void intercambio(int date1, int date2)
        {
            int aux = vector[date2];
            vector[date2] = vector[date1];
            vector[date1] = aux;
        }
        public void ordenIntercambio()
        {
            for (int ter1 = 1; ter1 < this.cantidad; ter1++)
            {
                for (int ter2 = ter1 + 1; ter2 <= this.cantidad; ter2++)
                {
                    if (vector[ter2] < vector[ter1])
                    {
                        this.intercambio(ter2, ter1);
                    }
                }
            }
        }
        public void ordenParmetros(int date1, int date2)
        {
            for (int ter1 = date1; ter1 < date2; ter1++)
            {
                for (int ter2 = ter1 + 1; ter2 <= date2; ter2++)
                {
                    if (vector[ter2] < vector[ter1])
                    {
                        this.intercambio(ter2, ter1);
                    }
                }
            }
        }
        public void ordenamientoBurbuja()
        {
            for (int ter1 = this.cantidad; ter1 > 1; ter1--)
            {
                for (int ter2 = 1; ter2 < this.cantidad; ter2++)
                {
                    if (vector[ter2] > vector[ter2 + 1])
                    {
                        this.intercambio((ter2), (ter2 + 1));
                    }
                }
            }
        }
        public int elemFrecuParam(int number, int inicio, int fin)
        {
            int conta = 0;
            for (int ter = inicio; ter <= fin; ter++)
            {
                if (vector[ter] == number)
                {
                    conta++;
                }
            }
            return conta;
        }
        //                                PRACTICO 2 VECTORES - PARTE 1
        //1. Cargar ne elementos el vector con la serie de Fibonacci en sentido de derecha a izquierda
        public void Fibonacci(int cant)
        {
            int ini = -1; int fin = 1; int fibo = 0;
            this.cantidad = cant;
            for (int idx = 1; idx <= cant; idx++)
            {
                fibo = ini + fin;
                ini = fin;
                fin = fibo;
                vector[idx] = fibo;
            }

        }

        public string DescargarInvertido()
        {
            string concatenar = "";
            for (int idx = this.cantidad; idx > 0; idx--)
            {
                concatenar = concatenar + vector[idx] + "|";
            }
            return "|" + concatenar;
        }
        //2. Realizar la operación:
        public double OperacionFibonacci(int dato)
        {
            double resultadoS = 0;
            double resultadoR = 0;
            double resultado = 0;
            bool bandera = true;
            for (int idx = 1; idx <= this.cantidad; idx++)
            {
                int numerador = vector[idx];
                int denominador = dato * idx;

                if (bandera == true)
                {
                    resultadoS += ((double)numerador / (double)denominador);
                    bandera = false;
                }
                else
                {
                    resultadoR -= ((double)numerador / (double)denominador);
                    bandera = true;
                }
                resultado = resultadoS + resultadoR;
            }

            return resultado;

        }

        //3. Buscar el elemento mayor de las posiciones múltiplos de m
        public int ElementoMayorporSegmento(int multiplo)
        {
            int posicion = 1;
            int termino = vector[posicion * multiplo];
            for (posicion = 1; posicion <= this.cantidad; posicion++)
            {
                if (vector[posicion * multiplo] > termino)
                {
                    termino = vector[posicion * multiplo];
                }
            }
            return termino;
        }

        //4. Encontrar la media de las posiciones múltiplos de m
        public double MediaporSegmentos(int multiplo)
        {
            double suma = 0;
            for (int idx = 1; idx <= this.cantidad; idx++)
            {
                suma = suma + vector[idx * multiplo];
            }
            return suma / (double)(this.cantidad / multiplo);
        }

        //5. Seleccionar los elementos múltiplos de m y NÓ múltiplos de m.
        public void ElementosMultilposyNo(int multiplo, ref Vec vector1, ref Vec vector2)
        {
            vector1.cantidad = 0;
            vector2.cantidad = 0;
            for (int idx = 1; idx <= this.cantidad; idx++)
            {
                if (vector[idx] % multiplo == 0)
                {
                    vector1.CargarVectorElemento(vector[idx]);
                }
                else
                {
                    vector2.CargarVectorElemento(vector[idx]);
                }
            }
        }
        //6. Invertir los elementos del vector sin usar objeto vector auxiliar. 
        public void VectorInvertido()
        {
            int aux;
            int cant = this.cantidad;
            for (int idx = 1; idx <= (this.cantidad / 2); idx++)
            {
                aux = vector[idx];
                vector[idx] = vector[cant];
                vector[cant] = aux;
                cant--;
            }
        }
        //7. Verificar si todo los elementos son iguales.
        public bool VerificarIgualdad()
        {
            bool respuesta = true;
            int aux = vector[1];
            for (int idx = 1; idx <= this.cantidad; idx++)
            {
                if (vector[idx] != aux)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        //8. Encontrar la unión de elementos (Teoría de conjuntos, donde cada vector es un conjunto)
        public void UnionVectores(Vec Vector2, ref Vec UVector)
        {
            UVector.cantidad = 0;
            for(int ter = 1; ter <= this.cantidad; ter++)
            {
                UVector.CargarVectorElemento(vector[ter]);
            }
            for(int ter2=1;ter2 <= Vector2.cantidad; ter2++)
            {
                if (this.BusquedaSecuencial(Vector2.vector[ter2]) == false)
                {
                    UVector.CargarVectorElemento(Vector2.vector[ter2]);
                }
            }

        }

        //9. Encontrar la diferencia de elementos (Teoría de conjuntos, donde cada vector es un conjunto) .
        public void DiferenciaVectores(Vec Vector2, ref Vec DifVector)
        {
            DifVector.cantidad = 0;
            for(int ter=1; ter <= this.cantidad; ter++)
            {
                if(Vector2.BusquedaSecuencial(vector[ter]) == false)
                {
                    DifVector.CargarVectorElemento(vector[ter]);
                }
            }
        }

        //10. Verificar si el segmento a y b esta ordenado
        public bool VerificarporSegmentos(int ini, int fin)
        {
            bool respuesta = true;
            int idx = ini;
            while (idx<fin && respuesta == true)
            {
                if (!(vector[idx] <= vector[idx + 1]))
                {
                    respuesta = false;
                }
                idx++;
            }
            return respuesta;
        }
        //                                PRACTICO 2 VECTORES - PARTE 2
        //11. Eliminar los elementos NO PRIMOS del vector. (En el mismo vector)
        public void EliminarNoPrimos()
        {
            numerosEnteros numero = new numerosEnteros();
            int cant;
            cant = this.cantidad;
            this.cantidad = 0;
            for (int ter = 1; ter <= cant; ter++)
            {
                numero.cargarDatos(vector[ter]);
                if (numero.verifPrimo() == true)
                {
                    this.cantidad++;
                    vector[this.cantidad] = vector[ter];
                }
            }
        }


        //12. Ordenar los elementos de posiciones múltiplos de m.
        public void OrdenarElementosMultiplosdeM(int number)
        {
            int media = this.cantidad / number;
            for (int ter = 1; ter < media; ter++)
            {
                for (int ter2 = ter + 1; ter2 <= media; ter2++)
                {
                    if (vector[ter * number] > vector[ter2 * number])
                    {
                        this.intercambio((ter2 * number), (ter * number));
                    }
                }
            }
        }


        //13. Ordenar en sentido de “espiral interno”
        public void OrdenarEspiral()
        {
            this.ordenIntercambio();

            int cant = this.cantidad;
            int media = this.cantidad / 2;
            int ter1 = 1;
            int auxi;

            while (ter1 <= media)
            {
                auxi = vector[ter1 + 1];
                for (int ter2 = ter1; ter2 < cant - 2; ter2++)
                {
                    vector[ter2 + 1] = vector[ter2 + 2];
                }
                vector[cant] = auxi;
                cant--; ter1++;
            }
        }


        //14. Contar elementos diferentes entre el rango a y b,
        public int ContarElemDiferentes(int number1, int number2)
        {
            int conta, ele, ter1;
            conta = 0; ter1 = number1;
            this.ordenParmetros(ter1, number2);

            while (ter1 <= number2)
            {
                ele = vector[ter1];
                while (ter1 <= number2 && vector[ter1] == ele)
                {
                    ter1++;
                }
                conta++;
            }
            return conta;
        }


        //15. Encontrar el elemento mas repetido en el segmento a y b
        public void encontrarElemRepetido(int number1, int number2, ref Vec vectEle, ref Vec vectFrecu)
        {
            vectEle.cantidad = 0;
            vectFrecu.cantidad = 0;
            int ter, conta, ele, frecu, max;
            conta = 0; max = 0; ter = number1;

            this.ordenParmetros(ter, number2);
            while (ter <= number2)
            {
                frecu = 0;
                ele = vector[ter];
                while ((ter <= number2) && (vector[ter] == ele))
                {
                    ter++; frecu++;
                }
                if ((frecu > max) && (frecu != 1))
                {
                    max = frecu;
                    conta = 0;
                    conta++;

                    vectEle.vector[conta] = ele;
                    vectFrecu.vector[conta] = max;
                }
                else if ((frecu >= max) && (frecu != 1))
                {
                    conta++;
                    vectEle.vector[conta] = ele;
                    vectFrecu.vector[conta] = max;
                }
            }
            vectEle.cantidad = conta;
            vectFrecu.cantidad = conta;
        }


        //16. Encontrar la frecuencia de distribución de elementos del segmento entre a y b
        public void encontrarFrecuElem(int number1, int number2, ref Vec vectEle, ref Vec vectFrecu)
        {
            vectEle.cantidad = 0;
            vectFrecu.cantidad = 0;

            int ter1, ele, frecu;
            ter1 = number1;
            this.ordenParmetros(ter1, number2);
            while (ter1 <= number2)
            {
                frecu = 0;
                ele = vector[ter1];
                while ((ter1 <= number2) && (vector[ter1] == ele))
                {
                    ter1++; frecu++;
                }
                vectEle.CargarVectorElemento(ele);
                vectFrecu.CargarVectorElemento(frecu);
            }
        }



        //17. Encontrar elemento y frecuencia de los ELEMENTOS DE FIBONACCI.
        public void elemFrecuFibonacci(ref Vec elefibo, ref Vec frecufibo)
        {
            elefibo.cantidad = 0;
            frecufibo.cantidad = 0;
            int ter1, ele, frecu, varfibo, varA, varB;
            ter1 = 1; varA = 0; varB = 1; varfibo = 0;
            this.ordenamientoBurbuja();
            while (ter1 <= this.cantidad)
            {
                varfibo = varA + varB;
                frecu = 0;
                ele = vector[ter1];
                if (ele == varfibo)
                {
                    while ((ter1 <= this.cantidad) && (vector[ter1] == ele))
                    {
                        ter1++; frecu++;
                    }
                    elefibo.CargarVectorElemento(ele);
                    frecufibo.CargarVectorElemento(frecu);
                    varA = varB; varB = varfibo;
                }
                else if (ele < varfibo)
                {
                    ter1++;
                }
                else if (ele > varfibo)
                {
                    varA = varB; varB = varfibo;
                }
            }
        }


        //18. Segmentar el Vector en elementos repetidos y no repetidos (con frecuencia y sin frecuencia)
        public void segmentarElemRepYNoRep(int ini, int fin)
        {
            for (int ter1 = ini; ter1 < fin; ter1++)
            {
                for (int ter2 = ter1 + 1; ter2 <= fin; ter2++)
                {
                    if ((elemFrecuParam(vector[ter2], ini, fin) != 1) && (!(elemFrecuParam(vector[ter1], ini, fin) != 1)) ||
                        (elemFrecuParam(vector[ter2], ini, fin) != 1) && (elemFrecuParam(vector[ter1], ini, fin) != 1) && (vector[ter2] > vector[ter1]) ||
                        (!(elemFrecuParam(vector[ter2], ini, fin) != 1)) && (!(elemFrecuParam(vector[ter1], ini, fin) != 1)) && (vector[ter2] > vector[ter1]))
                    {
                        this.intercambio(ter2, ter1);
                    }
                }
            }
        }


        //19. Segmentar el Vector en capicúas y no capicúas
        public void segmentarCapicuasNoCapicuas()
        {
            numerosEnteros number1 = new numerosEnteros();
            numerosEnteros number2 = new numerosEnteros();

            for (int ter1 = 1; ter1 < this.cantidad; ter1++)
            {
                for (int ter2 = ter1 + 1; ter2 <= this.cantidad; ter2++)
                {
                    number1.cargarDatos(vector[ter1]);
                    number2.cargarDatos(vector[ter2]);

                    if ((number2.verifCapicua()) && (!number1.verifCapicua()) ||
                        (number2.verifCapicua()) && (number1.verifCapicua()) && (vector[ter2] < vector[ter1]) ||
                        (!number2.verifCapicua()) && (!number1.verifCapicua()) && (vector[ter2] > vector[ter1]))
                    {
                        this.intercambio(ter2, ter1);
                    }
                }
            }
        }


        //20. Intercalar primos y no primos ordenados y mientras sea posible en el rango a y b
        public void intercalarPrimYNoPirm(int ini, int fin)
        {
            numerosEnteros number1 = new numerosEnteros();
            numerosEnteros number2 = new numerosEnteros();
            bool cambio = true;

            for (int ter1 = ini; ter1 < fin; ter1++)
            {
                if (cambio == true)
                {
                    for (int ter2 = ter1 + 1; ter2 <= fin; ter2++)
                    {
                        number1.cargarDatos(vector[ter1]);
                        number2.cargarDatos(vector[ter2]);

                        if ((number2.verifPrimo()) && (!number1.verifPrimo()) ||
                        (number2.verifPrimo()) && (number1.verifPrimo()) && (vector[ter2] < vector[ter1]) ||
                        (!number2.verifPrimo()) && (!number1.verifPrimo()) && (vector[ter2] > vector[ter1]))
                        {
                            this.intercambio(ter2, ter1);
                        }
                    }
                }
                else
                {
                    for (int ter2 = ter1 + 1; ter2 <= fin; ter2++)
                    {
                        number1.cargarDatos(vector[ter1]);
                        number2.cargarDatos(vector[ter2]);

                        if ((!number2.verifPrimo()) && (number1.verifPrimo()) ||
                        (!number2.verifPrimo()) && (!number1.verifPrimo()) && (vector[ter2] < vector[ter1]) ||
                        (number2.verifPrimo()) && (number1.verifPrimo()) && (vector[ter2] > vector[ter1]))
                        {
                            this.intercambio(ter2, ter1);
                        }
                    }
                }
                cambio = !cambio;
            }
        }
    }
}
