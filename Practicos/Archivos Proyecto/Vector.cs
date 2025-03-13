using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Archivos_Proyecto
{
    class Vector
    {
        private int Dimension = 101;
        private int cantidad;
        private int[] vector;
        private int inicio;

        public Vector()
        {
            this.cantidad = 0;
            vector = new int[Dimension];
            inicio = 0;
        }

        //Operaciones de Cargar y Descargar Vector
        public void CargarRandom(int cant,int ini,int fin)
        {
            Random rand = new Random();
            this.cantidad = cant;
            for(int idx = 1; idx <= this.cantidad; idx++)
            {
                vector[idx] = rand.Next(ini, fin + 1);
            }
        }
        public void Cargar(int n1, int i)
        {
            vector[i] = n1;
            this.cantidad = i;
        }
        public void CargarXElementos(int dato)
        {
            int idx;
            this.cantidad = dato;
            for (idx = 1; idx <= this.cantidad; idx++)
            {
                vector[idx] = Conversions.ToInteger(Interaction.InputBox("ingrese el elemento Nro" + idx));
            }
            inicio = vector[1];
        }
        public string Descargar()
        {
            string concatenar = "";
            for(int idx=1; idx <= this.cantidad; idx++)
            {
                concatenar = concatenar + vector[idx] + "|";
            }
            return concatenar;
        }
        //Funcion Intercambiar
        public void Intercambiar(int dato1,int dato2)
        {
            int aux = vector[dato1];
            vector[dato1] = vector[dato2];
            vector[dato2] = aux;
        }
        //Funcion de Ordenamiento
        public void Ordenamiento()
        {
            int posicion, desplazamiento;
            for (posicion = 1; posicion <= this.cantidad - 1; posicion++)
            {
                for (desplazamiento = posicion + 1; desplazamiento <= this.cantidad; desplazamiento++)
                {
                    if (vector[posicion] >= vector[desplazamiento])
                        Intercambiar(posicion, desplazamiento);
                }
            }
        }
        //Zona de Guardado
        public void guardar_vector(string datoArchivo)
        {
            Archivo a1 = new Archivo();
            int i;
            a1.guardar_Abrir(datoArchivo);
            vector[0] = inicio;
            a1.guardar(vector[0]);
            for (i = 1; i <= this.cantidad; i++)
                a1.guardar(vector[i]);
            a1.guardar_Cerrar();
        }

        public void leer_vector(string datoArchivo)
        {
            Archivo a1 = new Archivo();
            int i = 0;
            a1.leer_Abrir(datoArchivo);
            while (!a1.verificar_fin())
            {
                i++;
                vector[i] = a1.leer();
            }
            this.cantidad = i;
            a1.leer_Cerrar();
        }
    }
}
