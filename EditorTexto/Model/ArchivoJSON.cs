using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class ArchivoJSON : Archivo
    {
        //Antes de guardar
        public override string convertirAFormatoDeseado(Texto texto)
        {
            String json = "";

            foreach (Posicion p in texto.getEstructura())
            {
                json = json + p.getColor().ToString() + "-" + p.getIniPos().ToString() + "-" + p.getFinPos().ToString() + ".\n";
            }
            json = json + "??¿¿\n";
            foreach (char c in texto.getTexto()){

            }
            throw new NotImplementedException();
        }
        //Despues de abrir
        public override Texto convertirATexto(string textoArchivo)
        {
            throw new NotImplementedException();
        }
    }
}
