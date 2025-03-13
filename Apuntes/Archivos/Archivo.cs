using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos_Practica
{
    class Archivo
    {
        public string NombreArchivo;
        public FileStream varStream;
        public BinaryReader varReader;
        public BinaryWriter varWriter;

        public Archivo()
        {
            NombreArchivo = "";
        }

        //----------Guardar el archivo--------------------
        //Paso 1: Abrir Guardar
        public void guardar_abrir(string NuevoNombreArchivo)
        {
            this.NombreArchivo = NuevoNombreArchivo;
            varStream = new FileStream(NombreArchivo, FileMode.CreateNew, FileAccess.Write);
            varWriter = new BinaryWriter(varStream);
        }

        //Paso 2 : Guardar
        public void guardar(int dato)
        {
            varWriter.Write(dato);
        }

        //Paso 3 : Cerrar Guardar
        public void guardar_cerrar()
        {
            varWriter.Close();
            varStream.Close();
        }

        //----------Leer el Archivo-------------
        //Paso 1: Abrir Leer
        public void leer_abrir(string NuevoNombreArchivo)
        {
            this.NombreArchivo = NuevoNombreArchivo;
            varStream = new FileStream(NombreArchivo, FileMode.Open, FileAccess.Read);
            varReader = new BinaryReader(varStream);
        }

        //Paso 2: Leer
        public int leer()
        {
            return varReader.ReadInt32();
        }

        //Paso 3: Cerrar Leer
        public void leer_cerrar()
        {
            varReader.Close();
            varStream.Close();
        }

        //Verificar Cerrado de Archivos
        public bool verificar_fin()
        {
            return varStream.Position == varStream.Length;
        }

    }
}
