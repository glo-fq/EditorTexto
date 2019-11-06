using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class ArchivoCSV : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            return cambiarAComas(texto.getText());
        }

        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {
            texto.setText(cambiarAEspacios(textoArchivo));
            return texto;
        }

        private string cambiarAComas(string texto)
        {
            string nuevoTexto = texto.Replace(' ', ',');
            return nuevoTexto;
        }

        private string cambiarAEspacios(string texto)
        {
            string nuevoTexto = texto.Replace(',', ' ');
            return nuevoTexto;
        }
    }
}
