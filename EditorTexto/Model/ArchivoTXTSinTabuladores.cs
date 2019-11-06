using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class ArchivoTXTSinTabuladores : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            String text = texto.getRich().Text;
            return text;
            //throw new NotImplementedException();
        }
        //Despues de abri
        public override Texto convertirATexto(string textoArchivo, Texto texto)
        {
            texto.setText(textoArchivo);
            return texto;
            
            //throw new NotImplementedException();
        }
    }
}
