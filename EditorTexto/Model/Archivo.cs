using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    abstract class Archivo
    {
        String texto="";
        public String abriArchivo(String ruta) {

            using (StreamReader file = new StreamReader(ruta)) {
                texto = file.ReadToEnd();
                file.Close();
            }
            return texto;
        }
        public void guardarComo(String ruta) {
            using (StreamWriter file = File.CreateText(ruta)) {
                file.WriteLine(texto);
                file.Close();
            }
        }
        public String getTexto() {
            return this.texto;
        }
        public void setTexto(String texto) {
            this.texto = texto;
        }
        //La idea es que este reciba el texto de abri (con todo lo que contiene) y lo cambie al que va a mostrar en pantalla
        public abstract string convertirATexto(String textoArchivo);
        //La idea es que este reciba el texto de la interfaz y lo convierta al archivo que quiera (siempre en formato string) y luego llame a guardar texto y lo guarde en ese formato
        public abstract String convertirAFormatoDeseado(Texto texto);
    }
}
