using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class ArchivoTXTConTabuladores : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            throw new NotImplementedException();
        }
        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo)
        {
            throw new NotImplementedException();
        }
    }
}
