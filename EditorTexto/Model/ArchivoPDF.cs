using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class ArchivoPDF : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            //byte[] bytes = Encoding.UTF8.GetBytes(texto.getText());
            throw new NotImplementedException();
        }
        //Despues de abrir
        public override string convertirATexto(string textoArchivo)
        {
            
            throw new NotImplementedException();
        }
    }
}
