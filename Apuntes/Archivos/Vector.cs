using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos_Practica
{
    class Vector
    {
        const int dimension = 101;
        private int cantidad;
        private int[] vector;

        public Vector()
        {
            this.cantidad = 0;
            vector = new int[dimension];
        }

        public void CargarRandom(int cant,int ini,int fin)
        {
            Random rand = new Random();
            this.cantidad = cant;
            for(int idx = 1; idx <= this.cantidad; idx++)
            {
                vector[idx] = rand.Next(ini, fin + 1);
            }
        }

        public void CargarXElementos(int dato)
        {
            this.cantidad = this.cantidad + 1;
            vector[this.cantidad] = dato;
        }
        public string Descargar()
        {
            string concatenar = "|";
            for(int idx = 1; idx <= this.cantidad; idx++)
            {
                concatenar = concatenar + vector[idx] + "|";
            }
            return concatenar;
        }

        //Zona de Guardado
        public void GuardarVector(string datoArchivo)
        {
            Archivo archivoNuevo = new Archivo();
            archivoNuevo.guardar_abrir(datoArchivo);
            for(int idx = 1; idx <= this.cantidad; idx++)
            {
                archivoNuevo.guardar(vector[idx]);
            }
            archivoNuevo.guardar_cerrar();
        }

        public void AbrirVector(string datoArchivo)
        {
            Archivo archivoNuevo = new Archivo();
            archivoNuevo.leer_abrir(datoArchivo);
            int idx = 0;
            while (archivoNuevo.verificar_fin() == false)
            {
                idx++;
                vector[idx] = archivoNuevo.leer();
            }
            this.cantidad = idx;
            archivoNuevo.leer_cerrar();
        }

    }
}
