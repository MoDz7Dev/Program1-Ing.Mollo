using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos_Proyecto
{
    class Archivo
    {
        public string nombre_archivo;
        public FileStream varStream;
        public BinaryReader varReader_One;
        public BinaryWriter varWriter_One;

        public Archivo()
        {
            nombre_archivo = "";

        }

        //Metodo 1:
        //Paso 1: abrir Guardar
        public void guardar_Abrir(string nuevo_NombreArchivo)
        {
            nombre_archivo = nuevo_NombreArchivo;
            varStream = new FileStream(nombre_archivo, FileMode.CreateNew, FileAccess.Write);
            varWriter_One = new BinaryWriter(varStream);
        }

        //Paso 2: Guardar
        public void guardar(int dato)
        {
            varWriter_One.Write(dato);
        }

        public void guardar(string dato)
        {
            varWriter_One.Write(dato);
        }

        //Paso 3: Cerrar Guardar
        public void guardar_Cerrar()
        {
            varWriter_One.Close();
            varStream.Close();
        }

        //Metodo 2:
        //Paso 1: Leer Abrir
        public void leer_Abrir(string nuevo_NombreArchivo)
        {
            nombre_archivo = nuevo_NombreArchivo;
            varStream = new FileStream(nombre_archivo, FileMode.Open, FileAccess.Read);
            varReader_One = new BinaryReader(varStream);          
        }

        //Paso 2: 
        public int leer()
        {
            return varReader_One.ReadInt32();
        }

        
        //Paso 3:
        public void leer_Cerrar()
        {
            varReader_One.Close();
            varStream.Close();
        }

        //Metodo:
        //Verificar fin de leer y guardar
        public bool verificar_fin()
        {
            return varStream.Position == varStream.Length;
        }

        public string Descargar(string narch1)
        {
            string concatenar = "";
            leer_Abrir(narch1);
            leer();
            while (!verificar_fin())
            {
                concatenar = concatenar + leer() + " | ";
            }
            leer_Cerrar();
            return concate;
        }

        public string leerCadena()
        {
            string cadena;
            cadena = varReader_One.ReadString();
            return cadena;
        }

        public string DescargarCad(string narch1)
        {
            string cadena = "";
            leer_Abrir(narch1);
            while (!verificar_fin())
            {
                cadena = cadena + leerCadena() + "\r\n";
            }
            leer_Cerrar();
            return cadena;
        }

        //---------------PROYECTO ARCHIVOS-------------
        //Ejercicio 1: Encontrar la Media/Promedio
        public double Ejercicio1(string nuevoArchivo)
        {
            Entero numero = new Entero();
            double suma = 0;
            int idx = 0;
            leer_Abrir(nuevoArchivo);
            leer();
            while (!verificar_fin())
            {
                numero.cargar(leer());
                suma = suma + numero.descargar();
                idx++;
            }
            leer_Cerrar();
            return Math(suma / idx);
        }

        //Ejercicio 2: Encontrar la desviación media
        public double Ejercicio2(string nuevoArchivo)
        {
            Entero nu = new Entero();
            int idx = 0;
            double desviacionMedia = 0;
            double termino;
            double media = Ejercicio1(nuevoArchivo);
            leer_Abrir(nuevoArchivo);
            leer();
            while (!verificar_fin())
            {
                nu.cargar(leer());
                termino = Math.Abs(nu.descargar() - media);
                desviacionMedia = desviacionMedia + termino;
                idx++;
            }
            leer_Cerrar();
            return Math(desviacionMedia / idx);
        }

        //Ejercicio 3: Encontrar la Desviación estándar 
        public double Ejercicio3(string nuevoArchivo)
        {
            Entero nu = new Entero();
            int idx = 0;
            double desviacionEstandar = 0;
            double termino;
            double media = Ejercicio1(nuevoArchivo);
            leer_Abrir(nuevoArchivo);
            leer();
            while (!verificar_fin())
            {
                nu.cargar(leer());
                termino = Math.Pow((Math.Abs(nu.descargar() - media)), 2);
                desviacionEstandar = desviacionEstandar + termino;
                idx++;
            }
            leer_Cerrar();
            return Math(Math.Sqrt(desviacionEstandar / (idx - 1)));
        }

        //Ejercicio 4: Operacion de Seleccion
        public void Ejercicio4(string nuevoArchivo1, string nuevoArchivo2, Archivo archivoResultante)
        {
            Entero na = new Entero();
            double notaBuena = Ejercicio1(nuevoArchivo1) + Ejercicio3(nuevoArchivo1);
            leer_Abrir(nuevoArchivo1);
            archivoResultante.guardar_Abrir(nuevoArchivo2);
            leer();
            archivoResultante.guardar(0);
            while (!verificar_fin())
            {
                na.cargar(leer());
                if (na.verifMayor(notaBuena))
                    archivoResultante.guardar(na.descargar());
            }
            leer_Cerrar();
            archivoResultante.guardar_Cerrar();
        }

        //Ejercicio 5: Cortes de Control
        public void Ejercicio5(int rango, string nuevoArchivo1, string nuevoArchivo2, Archivo archivoResultante)
        {
            Entero na = new Entero();
            int contador = 0;
            leer_Abrir(nuevoArchivo1);
            archivoResultante.guardar_Abrir(nuevoArchivo2);
            na.cargar(leer());
            int aux = na.descargar();
            int limite = aux + rango;
            while (!verificar_fin())
            {
                na.cargar(leer());
                if (na.verifMenor(limite))
                {
                    contador++;
                }
                else
                {
                    archivoResultante.guardar("Entre " + aux + " y " + (limite - 1) + " existen " + contador + " elementos.");
                    contador = 1;
                    aux = limite;
                    limite = limite + rango;
                }
            }
            archivoResultante.guardar("Entre " + aux + " y " + (limite - 1) + " existen " + contador + " elementos.");
            leer_Cerrar();
            archivoResultante.guardar_Cerrar();
        }
    }
}
